import { observer } from 'mobx-react-lite';
import React from 'react';
import { Card } from 'semantic-ui-react';
import { useShoutStore } from '../../../stores/stores';
import ShoutOutCard from '../Card/ShoutOutCard';

interface IShoutOutList {}

const ShoutOutList = (props: IShoutOutList) => {
  const shoutStore = useShoutStore();
  const { shouts } = shoutStore;

  return (
    <>
      <Card.Group>
        {shouts.map((shout, index) => (
          <ShoutOutCard shout={shout} key={index} />
        ))}
      </Card.Group>
    </>
  );
};

export default observer(ShoutOutList);
