import { Layout, Menu } from 'antd';
import { NavLink, useHistory } from 'react-router-dom';
import {
  HomeOutlined,
  LineChartOutlined,
  PieChartOutlined,
} from '@ant-design/icons';
import React, { useEffect, useState } from 'react';

const { Header, Sider } = Layout;

export default function SideNavBar() {
  const [collapse, setCollapse] = useState(false);

  useEffect(() => {
    window.innerWidth <= 760 ? setCollapse(true) : setCollapse(false);
  }, []);

  const handleToggle = () => {
    collapse ? setCollapse(false) : setCollapse(true);
  };

  return (
    <Sider collapsible collapsed={collapse} onCollapse={handleToggle}>
      {/* <div className="logo" /> */}
      <Menu theme='dark' defaultSelectedKeys={['/dashboard']} mode='inline'>
        <Menu.Item key='/dashboard' icon={<PieChartOutlined />}>
          <NavLink to='/dashboard'>
            <span>Dashboard</span>
          </NavLink>
        </Menu.Item>
        <Menu.Item key='/assurancerequests' icon={<PieChartOutlined />}>
          <NavLink to='/dashboard'>
            <span>Assurance Requests</span>
          </NavLink>
        </Menu.Item>
        <Menu.Item key='/researchstudies' icon={<PieChartOutlined />}>
          <NavLink to='/dashboard'>
            <span>Research Studies</span>
          </NavLink>
        </Menu.Item>
        <Menu.Item key='/clinical' icon={<PieChartOutlined />}>
          <NavLink to='/dashboard'>
            <span>Clinical</span>
          </NavLink>
        </Menu.Item>
      </Menu>
    </Sider>
  );
}
