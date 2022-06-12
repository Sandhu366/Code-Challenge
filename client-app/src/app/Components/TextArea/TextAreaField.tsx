import { observer } from 'mobx-react-lite';
import React from 'react';
import { Form } from 'semantic-ui-react';
import IInputProps from '../IInputProps';

interface ITextAreaField extends IInputProps {
  rows: number;
}

const TextAreaField = ({
  rows,
  name,
  value,
  placeholder,
  onModelChange,
}: ITextAreaField) => {
  const onChange = (event: any) => {
    const { name, value } = event.target;
    onModelChange(name, value);
  };

  return (
    <Form.TextArea
      rows={rows}
      name={name}
      value={value}
      onChange={onChange}
      placeholder={placeholder}
    />
  );
};

export default observer(TextAreaField);
