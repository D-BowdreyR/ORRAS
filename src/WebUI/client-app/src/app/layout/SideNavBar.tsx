import React from 'react';
import { Container, Divider, Icon, Menu, Segment, Sidebar } from 'semantic-ui-react';

export default function SideNavBar(){
    return (
            <Sidebar style={{overflow:'scroll' }} vertical icon='labeled' animation='slide along' as={Menu} inverted visible width='thin'>
                <Divider section/>
            <Menu.Item as='a'>
                <Icon name='home'/>Home
            </Menu.Item>
            <Menu.Item as='a'>Assurance Requests
            </Menu.Item>
            <Menu.Item as='a'>Research Studies
            </Menu.Item>
            <Menu.Item as='a'>Clinical
            </Menu.Item>
            <Menu.Item as='a'>Home
            </Menu.Item>
            <Menu.Item as='a'>Home
            </Menu.Item>
        </Sidebar>
    )
}