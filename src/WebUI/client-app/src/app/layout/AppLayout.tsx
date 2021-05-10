import {
  HomeOutlined,
  LineChartOutlined,
  MenuFoldOutlined,
  MenuUnfoldOutlined,
  PieChartOutlined,
  SettingOutlined,
  UploadOutlined,
  UserOutlined,
  VideoCameraOutlined,
} from '@ant-design/icons';
import { Layout, Menu } from 'antd';
import React, { useEffect, useState } from 'react';
import { NavLink, Redirect, Route, Switch } from 'react-router-dom';
import Dashboard from '../../features/dashboard/Dashboard';
import TopNavBar from './TopNavBar';
import SideNavBar from './SideNavBar';

const { Header, Sider, Content, Footer } = Layout;
const { SubMenu } = Menu;

export default function AppLayout() {
  
  


  return (
    <Layout style={{ minHeight: '100vh' }}>
    <TopNavBar/>
      <Layout>
          {/* <div className="logo" /> */}
         <SideNavBar/>
    <Layout className="site-layout">
      {/* <Header className="site-layout-background" style={{ padding: 0 }} /> */}
      <Content style={{ margin: "16px 16px", background: "#fff" }}>
        <div style={{ padding: 24, background: "#fff", minHeight: 360 }}>
          <Switch>
                <Route exact path="/dashbaord" component={Dashboard}>
            </Route>
          </Switch>
        </div>
      </Content>
      <Footer style={{ textAlign: 'center', color:'slategray' }}>Copyright &copy; 2021 Oxford University Hospitals NHS Foundation Trust</Footer>
    </Layout>
  </Layout>
  </Layout>
  );
}
