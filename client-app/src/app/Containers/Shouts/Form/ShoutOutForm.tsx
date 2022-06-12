import { observer } from 'mobx-react-lite';
import React, { useState } from 'react';
import { FormModel } from '../../../models/Common/FormModel';
import { useShoutStore } from '../../../stores/stores';
import LoaderWithoutDimmer from '../../../Components/Loader/LoaderWithoutDimmer';
import { Grid } from 'semantic-ui-react';
import { Shout } from '../../../models/Shout';
import ShoutOutFormFields from './ShoutOutFormFields';

interface IShoutForm {}

const ShoutOutForm = (props: IShoutForm) => {
  const shoutStore = useShoutStore();
  const {
    isLoading,
    editShout,
    isSubmitting,
    submitShout,
    getSelectedShout,
  } = shoutStore;

  const [shoutOut, setShoutOut] = useState<Shout>(getSelectedShout!);

  const onChange = (key: keyof FormModel, value: any) => {
    shoutOut!.OnModelChange(key, value);
    setShoutOut(new Shout().SetData(shoutOut));
  };

  const submitHandler = () => {
    (async () => {
      await submitShout(shoutOut!);
    })();
  };

  const editHandler = () => {
    (async () => {
      await editShout(shoutOut!);
    })();
  };

  const clearHandler = () => {
    shoutOut.body = '';
  };

  if (isLoading) {
    return <LoaderWithoutDimmer active content='Loading Shout Outs...' />;
  }

  return (
    <Grid>
      <Grid.Column>
        <ShoutOutFormFields
          shoutOut={shoutOut}
          onChange={onChange}
          editHandler={editHandler}
          isSubmitting={isSubmitting}
          submitHandler={submitHandler}
          clearHandler={clearHandler}
        />
      </Grid.Column>
    </Grid>
  );
};

export default observer(ShoutOutForm);
