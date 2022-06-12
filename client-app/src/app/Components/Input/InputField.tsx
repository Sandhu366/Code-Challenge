import { observer } from 'mobx-react-lite';
import React from 'react';
import { Form } from 'semantic-ui-react';
import IInputProps from '../IInputProps';

interface IInputField extends IInputProps {}

const InputField = ({
  name,
  type,
  value,
  placeholder,
  onModelChange,
}: IInputField) => {
  const onChange = (event: any) => {
    const { name, value } = event.target;
    onModelChange(name, value);
  };

  return (
    <Form.Input
      type={type}
      name={name}
      value={value}
      onChange={onChange}
      placeholder={placeholder}
    />
  );
};

export default observer(InputField);
