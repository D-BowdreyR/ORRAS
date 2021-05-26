import { Layout, Menu } from 'antd';
import { NavLink, useHistory } from 'react-router-dom';
import {
  ContainerOutlined,
  DashboardOutlined,
  EditOutlined,
  HomeOutlined,
  LineChartOutlined,
  MedicineBoxOutlined,
  PieChartOutlined,
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
    <Sider collapsible collapsed={sideNavbarStore.sider.collapsed} onCollapse={() => handleToggle()}>
      <div className="logo" />
      <Menu theme='dark' defaultSelectedKeys={['/dashboard']} mode='inline'>
        <Menu.Item key='/dashboard' icon={<DashboardOutlined />}>
          <NavLink to='/dashboard'>
            <span>Dashboard</span>
          </NavLink>
        </Menu.Item>
        <Menu.Item key='/assurancerequests' icon={<EditOutlined />}>
          <NavLink to='/dashboard'>
            <span>Assurance Requests</span>
          </NavLink>
        </Menu.Item>
        <Menu.Item key='/researchstudies' icon={<ContainerOutlined />}>
          <NavLink to='/dashboard'>
            <span>Research Studies</span>
          </NavLink>
        </Menu.Item>
        <Menu.Item key='/clinical' icon={<MedicineBoxOutlined />}>
          <NavLink to='/dashboard'>
            <span>Clinical</span>
          </NavLink>
        </Menu.Item>
      </Menu>
    </Sider>
  );
})
