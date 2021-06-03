import { Layout, Space, Spin } from 'antd';
import React, { useEffect, useState } from 'react';
import { BrowserRouter as Router, Route, Switch, useLocation } from 'react-router-dom';
import { Container, Header, Icon } from 'semantic-ui-react';
import Dashboard from '../../features/dashboard/Dashboard';
import { MenuUnfoldOutlined, MenuFoldOutlined, LoadingOutlined } from '@ant-design/icons';
import LandingPage from '../../features/landing/LandingPage';
import AppLayout from './AppLayout';
import ModalContainer from '../common/modals/ModalContainer';
import { observer } from 'mobx-react-lite';
import { useStore } from '../stores/store';

function App() {
  const { commonStore, userStore } = useStore();
  
  // persist the user login by getting a locally stored token
  useEffect(() => {
    if (commonStore.token) {
      userStore.getUser().finally(() => commonStore.setAppLoaded())
    } else {
      commonStore.setAppLoaded();
    }
  }, [commonStore, userStore])

  return (
    <>
    <ModalContainer />
    <Route exact path='/' component={LandingPage} />
      <Route
        path={'/(.+)'}
        render={() => (
          <>
           <AppLayout />
          </>
        )}
      />
    </>
  );
}
export default observer(App);
