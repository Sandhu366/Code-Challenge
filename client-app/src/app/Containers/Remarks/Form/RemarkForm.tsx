import { observer } from 'mobx-react-lite';
import React, { useState } from 'react';
import { Form, Button, Grid } from 'semantic-ui-react';
import TextAreaField from '../../../Components/TextArea/TextAreaField';
import { FormModel } from '../../../models/Common/FormModel';
import { Remark } from '../../../models/Remark';
import { useRemarkStore } from '../../../stores/stores';

interface IRemarkForm {
  shoutId: number;
}

const RemarkForm = ({ shoutId }: IRemarkForm) => {
  const remarkStore = useRemarkStore();
  const { getSelectedRemark, submitRemark } = remarkStore;

  const [remark, setRemark] = useState<Remark>(getSelectedRemark!);

  const onChange = (key: keyof FormModel, value: any) => {
    remark!.OnModelChange(key, value);
    let newRemark = { ...remark };
    newRemark.shoutId = shoutId;
    setRemark(new Remark().SetData(remark));
  };

  const handleSubmit = () => {
    (async () => {
      await submitRemark(remark!);
    })();
  };

  return (
    <Grid>
      <Grid.Column>
        <Form onSubmit={handleSubmit}>
          <TextAreaField
            rows={5}
            name='body'
            value={remark?.body}
            onModelChange={onChange}
            placeholder={'Add remark here!'}
          />
          <Button
            content='Add Remark'
            labelPosition='left'
            icon='add'
            primary
          />
        </Form>
      </Grid.Column>
    </Grid>
  );
};

export default observer(RemarkForm);
