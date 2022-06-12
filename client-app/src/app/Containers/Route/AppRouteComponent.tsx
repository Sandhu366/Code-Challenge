import React from 'react';
import { Route, Switch } from 'react-router-dom';
import NotFound from '../../../NotFound';
import { routes } from './routeConstants';
import { observer } from 'mobx-react-lite';
import ShoutsDashboard from '../Shouts/Dashboard/ShoutsDashboard';
import ShoutOutDetail from '../Shouts/Detail/ShoutOutDetail';

interface IAppRouteComponent {}

const AppRouteComponent = (props: IAppRouteComponent) => {
  return (
    <Switch>
      <Route path={routes.shoutOutDetails} component={ShoutOutDetail} /> 
      <Route path={routes.shoutOuts} exact component={ShoutsDashboard} />
      <Route component={NotFound} />
    </Switch>
  );
};

export default observer(AppRouteComponent);
