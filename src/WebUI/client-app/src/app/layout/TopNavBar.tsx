import Icon, { BellOutlined, IdcardOutlined, LogoutOutlined, MailOutlined, MenuFoldOutlined, MenuUnfoldOutlined, NotificationFilled, SettingOutlined, UserOutlined } from '@ant-design/icons';
import { Menu, Popover } from 'antd';
import Avatar from 'antd/lib/avatar/avatar';
import Layout, { Header } from 'antd/lib/layout/layout';
import { observer } from 'mobx-react-lite';
import React from 'react';
import { useStore } from '../stores/store';



const { SubMenu } = Menu;

export default observer(function TopNavBar() {
  const { sideNavbarStore, userStore: {user, logout} } = useStore();
  
  
  const content = (
    <div>
      <p>Content</p>
      <p>Content</p>
    </div>
  )
  return (
    <Header style={{ background: "#fff", padding:0}} className="header">
      <div>
      {React.createElement(sideNavbarStore.sider.collapsed ? MenuUnfoldOutlined : MenuFoldOutlined, {
              className: 'trigger',
        onClick: sideNavbarStore.handleToggle
            })}
      </div>
      <Menu mode="horizontal" theme="light" className="flex-setting">
      
          <SubMenu icon={<Avatar style={{ marginRight: '5px' }} icon={<UserOutlined/>}/>} style={{float: 'right'}} title={user?.displayName}>
          <Menu.ItemGroup title="Account Settings">
              <Menu.Item icon={<IdcardOutlined />} key="setting:1">
                <a href={"/profile/"} target="_self">
                  My Profile
                </a>
              </Menu.Item>
          </Menu.ItemGroup>  
          <Menu.ItemGroup>
              <Menu.Item icon={<LogoutOutlined/>} onClick={() => logout()} key="setting:2">Sign Out</Menu.Item>
          </Menu.ItemGroup>
          
          </SubMenu>
        <Menu.Item key='notifications'>
          <Popover content={content} placement="bottomRight" title="Notifications">
          <BellOutlined style={{ fontSize: '20px' }} />
          </Popover>
        </Menu.Item>
        <Menu.Item>
                   <MailOutlined style={{ fontSize: '20px' }}/>
            </Menu.Item>
        </Menu>
      </Header>
    )
})