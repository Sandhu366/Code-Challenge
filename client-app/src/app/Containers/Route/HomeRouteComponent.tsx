import React from 'react';
import { Route } from 'react-router-dom';
import { routes } from './routeConstants';
import { observer } from 'mobx-react-lite';
import LandingPage from '../LandingPage/LandingPage';

interface IHomeRoute {}

const HomeRouteComponent = (props: IHomeRoute) => {
  return (
    <>
      <Route path={routes.shoutOuts} render={() => <LandingPage />} />
    </>
  );
};

export default observer(HomeRouteComponent);
