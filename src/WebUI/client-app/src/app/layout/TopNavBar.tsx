import Icon, { BellOutlined, DownOutlined, IdcardOutlined, LogoutOutlined, MailOutlined, MenuFoldOutlined, MenuUnfoldOutlined, NotificationFilled, SearchOutlined, SettingOutlined, UserOutlined } from '@ant-design/icons';
import { Button, Dropdown, Menu, Popover, Tooltip } from 'antd';
import Avatar from 'antd/lib/avatar/avatar';
import Layout, { Header } from 'antd/lib/layout/layout';
import { observer } from 'mobx-react-lite';
import React from 'react';
import { history } from '../..';
import NotificationTray from '../../features/notifications/NotificationTray';
import { useStore } from '../stores/store';



const { SubMenu } = Menu;

export default observer(function TopNavBar() {
  const { sideNavbarStore, userStore: {user, logout} } = useStore();
  
  const handleClickMyProfile = () => {
    history.push("/myprofile")
  }

  const accountMenu = (
    <Menu>
       <Menu.ItemGroup title="Account Settings">
            <Menu.Item icon={<IdcardOutlined style={{ fontSize: '18px' }} />} key="setting:1" onClick={() => handleClickMyProfile() }>
                  My Profile
              </Menu.Item>
      </Menu.ItemGroup>
      <Menu.Divider/>
              <Menu.Item icon={<LogoutOutlined style={{ fontSize: '15px' }}/>} onClick={() => logout()} key="setting:2">Sign Out</Menu.Item>
    </Menu>
  );


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
      <div style={{paddingLeft: '25px'}}>
      <Tooltip title="search">
      <Button shape="circle" icon={<SearchOutlined />} />
    </Tooltip>
      </div>

     
      
      <div style={{position: 'relative', marginLeft: 'auto', marginRight:'0' }}>

      <div style={{position: 'relative', float: 'right', paddingRight: '16px' }}>
        <Dropdown overlay={accountMenu} placement='bottomRight' arrow>
          <a >
        {user?.displayName} <Avatar style={{ marginLeft: '5px' }} icon={<UserOutlined/>}/> <DownOutlined />
      </a>
      </Dropdown>
        </div>
      
      
     
      <div style={{position: 'relative', float: 'right', paddingRight: '15px' }}>
          <Popover trigger='click' arrowPointAtCenter>
      <Button shape="circle" icon={<MailOutlined />} />
      </Popover>
    
      </div>

      <div style={{position: 'relative', float: 'right', paddingRight: '15px' }}>
          <Popover trigger='click' arrowPointAtCenter content={<NotificationTray/>}>
      <Button shape="circle" icon={<NotificationFilled />} />
      </Popover>
      </div>
      </div>
      </Header>
    )
})