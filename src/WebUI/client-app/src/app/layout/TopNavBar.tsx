import Icon, { BellOutlined, IdcardOutlined, LogoutOutlined, MailOutlined, NotificationFilled, SettingOutlined, UserOutlined } from '@ant-design/icons';
import { Menu, Popover } from 'antd';
import Avatar from 'antd/lib/avatar/avatar';
import { Header } from 'antd/lib/layout/layout';
import React from 'react';



const { SubMenu } = Menu;

export default function TopNavBar() {
    
  const content = (
    <div>
      <p>Content</p>
      <p>Content</p>
    </div>
  )
  return (
        <Header style={{background: "#fff"}} className="header">
        <div className="logo" />
        <Menu mode="horizontal" theme="light" className="flex-setting">
          <SubMenu icon={<Avatar style={{ marginRight: '5px' }} icon={<UserOutlined/>}/>} style={{float: 'right'}} title="Username">
          <Menu.ItemGroup title="Account Settings">
              <Menu.Item icon={<IdcardOutlined />} key="setting:1">
                <a href={"/profile/"} target="_self">
                  My Profile
                </a>
              </Menu.Item>
          </Menu.ItemGroup>  
          <Menu.ItemGroup>
              <Menu.Item icon={<LogoutOutlined/>} key="setting:2">
                <a href={"/accounts/logout/"} target="_self">
                  Signout
                </a>
            </Menu.Item>
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
}