import { Layout } from 'antd';
import React, { useEffect, useState } from 'react';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import { Container, Header, Icon } from 'semantic-ui-react';
import Dashboard from '../../features/dashboard/Dashboard';
import { MenuUnfoldOutlined, MenuFoldOutlined } from '@ant-design/icons';
import LandingPage from '../../features/landing/LandingPage';
import AppLayout from './AppLayout';

function App() {
  return (
    <>
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
export default App;
