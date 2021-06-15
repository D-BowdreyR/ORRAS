import { Layout, Menu } from 'antd';
import { NavLink, useHistory } from 'react-router-dom';
import {
  ContainerOutlined,
  DashboardOutlined,
  EditOutlined,
  ExclamationCircleOutlined,
  HomeOutlined,
  LineChartOutlined,
  MedicineBoxOutlined,
  PieChartOutlined,
  ToolOutlined,
} from '@ant-design/icons';
import React, { useEffect, useState } from 'react';
import { useStore } from '../stores/store';
import { observer } from 'mobx-react-lite';

const { Header, Sider } = Layout;

export default observer(function SideNavBar() {
  const { sideNavbarStore } = useStore();
  const {handleToggle, setCollapse} = sideNavbarStore
  
  useEffect(() => {
    window.innerWidth <= 760 ? setCollapse(true) : setCollapse(false);
  }, []);

  return (
    <Sider collapsedWidth={70} collapsible collapsed={sideNavbarStore.sider.collapsed} onCollapse={() => handleToggle()}>
      <div className="logo"/>
      <Menu theme='dark' defaultSelectedKeys={['/home']} mode='inline'>
        <Menu.Item key='/home' icon={<HomeOutlined />}>
          <NavLink to='/home'>
            <span>Home</span>
          </NavLink>
        </Menu.Item>
        <Menu.Item key='/assurancerequests' icon={<EditOutlined />}>
          <NavLink to='/assurancerequests'>
            <span>Assurance Requests</span>
          </NavLink>
        </Menu.Item>
        <Menu.Item key='/researchstudies' icon={<ContainerOutlined />}>
          <NavLink to='/researchstudies'>
            <span>Research Studies</span>
          </NavLink>
        </Menu.Item>
        <Menu.SubMenu key='/clinicalsubmenu' icon={<MedicineBoxOutlined />} title='Clinical'>
        <Menu.Item key='/clinical' icon={<MedicineBoxOutlined />}>
          <NavLink to='/clinical'>
            <span>Dashboard</span>
            </NavLink>
          </Menu.Item>
          <Menu.Item key='/clinical2' icon={<MedicineBoxOutlined />}>
          <NavLink to='/clinical/participants'>
            <span>Participants</span>
            </NavLink>
        </Menu.Item>
        </Menu.SubMenu>
        <Menu.SubMenu key='/admincentre' icon={<ToolOutlined />} title='Admin Centre'>
        <Menu.Item key='/errors' icon={<ExclamationCircleOutlined />}>
          <NavLink to='/errors'>
            <span>Test Errors</span>
            </NavLink>
          </Menu.Item>
        </Menu.SubMenu>
      </Menu>
    </Sider>
  );
})
