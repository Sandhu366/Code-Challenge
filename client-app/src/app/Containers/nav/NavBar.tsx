import React from 'react';
import { NavLink } from 'react-router-dom';
import { observer } from 'mobx-react-lite';
import { Container, Menu } from 'semantic-ui-react';
import { routes } from '../Route/routeConstants';

interface INavBar {}

const NavBar = (props: INavBar) => {
  return (
    <Menu fixed='top' inverted>
      <Container>
        <Menu.Item
          as={NavLink}
          to={routes.shoutOuts}
          exact
          name='WebApp'
          position='left'
        />
        <Menu.Item
          exact
          name='Home'
          as={NavLink}
          to={routes.shoutOuts}
          position='right'
        />
      </Container>
    </Menu>
  );
};

export default observer(NavBar);
