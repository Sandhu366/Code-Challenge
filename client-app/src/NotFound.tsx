import React from 'react';
import { Segment, Button, Header, Icon } from 'semantic-ui-react';
import { Link } from 'react-router-dom';
import { observer } from 'mobx-react-lite';
import { routes } from './app/Containers/Route/routeConstants';

const NotFound = () => {
  return (
    <Segment placeholder>
      <Header icon>
        <Icon name='search' />
        Oops - we've looked everywhere but couldn't find this.
      </Header>
      <Segment.Inline>
        <Button as={Link} to={routes.shoutOuts} primary>
          Return to Shout Outs page
        </Button>
      </Segment.Inline>
    </Segment>
  );
};

export default observer(NotFound);
