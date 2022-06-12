import { observer } from 'mobx-react-lite';
import React from 'react';
import { useEffect } from 'react';
import { Grid, GridColumn, List } from 'semantic-ui-react';
import LoaderWithDimmer from '../../../Components/Loader/LoaderWithDimmer';
import { useShoutStore } from '../../../stores/stores';
import ShoutOutList from '../List/ShoutOutList';
import ShoutOutForm from '../Form/ShoutOutForm';

interface IShoutsDashboard {}

const ShoutsDashboard = (props: IShoutsDashboard) => {
  const shoutStore = useShoutStore();
  const { isLoading } = shoutStore;

  useEffect(() => {
    (async () => await shoutStore.loadShouts())();
  }, [shoutStore]);

  if (isLoading) {
    return <LoaderWithDimmer size='medium' content='Loading shout outs...' />;
  }

  return (
    <Grid>
      <GridColumn width={16}>
        <List>
          <ShoutOutForm />
          <ShoutOutList />
        </List>
      </GridColumn>
    </Grid>
  );
};

export default observer(ShoutsDashboard);
