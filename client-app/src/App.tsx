import './App.css';
import React from 'react';
import 'semantic-ui-css/semantic.min.css';
import { observer } from 'mobx-react-lite';
import { ToastContainer } from 'react-toastify';
import HomeRouteComponent from './app/Containers/Route/HomeRouteComponent';

function App() {
  return (
    <>
      <ToastContainer position='bottom-right' />
      <HomeRouteComponent />
    </>
  );
}

export default observer(App);
