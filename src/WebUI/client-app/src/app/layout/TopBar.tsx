
import React from 'react';
import { Link } from 'react-router-dom';
import { Button, Container, Dropdown, DropdownItem, Icon, Input, Label, Menu } from 'semantic-ui-react';

export default function TopBar() {
    return (
        <Container>
              <Menu fixed='top' borderless>
            <Menu.Item as='a'>
                        <Icon name='bars'/>
            </Menu.Item>
            <Menu.Menu position='right'>
                <Menu.Item>
                    <Input icon='search' placeholder='Search...'/>
                </Menu.Item>
            <Menu.Item position='right' as='a'>
                <Icon name='bell' size='large'/> Notifications
                </Menu.Item>
                <Menu.Item position='right' as='a'>
                    <Icon name='mail' size='large' /> Messages
            </Menu.Item>
            <Menu.Item position='right'>
                <Icon name='user circle outline' size='big' />
                <Dropdown pointing='top right' text='username' icon='dropdown'>
                    <Dropdown.Menu>
                        <Dropdown.Item as={Link} to='/profile' text='My Profile' icon='address card outline' />
                        <Dropdown.Divider />
                        <Dropdown.Item text='signout' icon='power off'/>
                    </Dropdown.Menu>
                </Dropdown>
            </Menu.Item>
            </Menu.Menu>
        </Menu>
        </Container>
        
    )
}