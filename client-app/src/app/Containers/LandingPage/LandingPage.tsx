import React from 'react';
import { observer } from 'mobx-react-lite';
import { Container } from 'semantic-ui-react';
import AppRouteComponent from '../Route/AppRouteComponent';
import NavBar from '../nav/NavBar';

interface ILandingPage {}

const LandingPage = (props: ILandingPage) => {
  return (
    <>
      <NavBar />
      <Container style={{ marginTop: '7em' }}>
        <AppRouteComponent />
      </Container>
    </>
  );
};

export default observer(LandingPage);
