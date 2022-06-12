import React from 'react';
import { observer } from 'mobx-react-lite';
import { FormModel } from '../../../models/Common/FormModel';
import { Button, Form, Segment } from 'semantic-ui-react';
import InputField from '../../../Components/Input/InputField';
import { Shout } from '../../../models/Shout';

interface IShoutOutFormFields {
  shoutOut: Shout;
  isSubmitting: boolean;
  editHandler: () => void;
  clearHandler: () => void;
  submitHandler: () => void;
  onChange: (key: keyof FormModel, value: any) => void;
}

const ShoutOutFormFields = ({
  shoutOut,
  onChange,
  editHandler,
  isSubmitting,
  submitHandler,
  clearHandler,
}: IShoutOutFormFields) => {
  return (
    <Segment>
      <Form onSubmit={shoutOut?.id ? editHandler : submitHandler}>
        <InputField
          name='Body'
          placeholder='Enter shout out here!'
          value={shoutOut?.body}
          onModelChange={onChange}
        />
        <Button.Group fluid>
          <Button
            positive
            type='submit'
            content='Save'
            loading={isSubmitting}
          />
          <Button.Or />
          <Button content='Clear' onClick={clearHandler} />
        </Button.Group>
      </Form>
    </Segment>
  );
};

export default observer(ShoutOutFormFields);
