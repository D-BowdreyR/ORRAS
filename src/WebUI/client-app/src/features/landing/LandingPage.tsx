import { Button, Space } from 'antd';
import Layout, { Content } from 'antd/lib/layout/layout';
import { observer } from 'mobx-react-lite';
import React from 'react';
import { Link } from 'react-router-dom';
import {
  Container,
  Header,
  Segment,
  Image,
  Message,
  Icon,
  Grid,
  GridColumn,
  List,
  Menu,
  GridRow,
} from 'semantic-ui-react';
import CommonStore from '../../app/stores/commonStore';
import { useStore } from '../../app/stores/store';
import LoginForm from '../users/LoginForm';
import LandingPageFooter from './LandingPageFooter';
import LandingPageHeader from './LandingPageHeader';
import { history } from "../..";
import { Typography } from 'antd';

const { Title, Text } = Typography;

export default observer(function LandingPage() {
  const { modalStore, userStore: {isLoggedIn} } = useStore();
  
  const handleClick = () => {
    history.push("/home");
  }

  return (
    <Layout style={{ minHeight: '100vh', background: "#fff"}} className='layout'>
      <LandingPageHeader />
      <Content className='landing-image' >
        <Container>
          <Segment textAlign='center' vertical>
            <Container text>
            <Space direction='vertical' size="middle" align='center'>
              <Title level={1}>ORRAS</Title>
              <Title level={4}>Welcome to the Oxford Research Radiation Assurance Service</Title>
              
              {isLoggedIn ? (
                <>
                  <Text type='success'>You are already logged in</Text>
                    <Button type="primary" shape="round" onClick={() => handleClick()}>Enter</Button>
              
                </>  ) : ( <>
                <Button type="primary" shape="round" onClick={() => modalStore.openModal(<LoginForm />)}>
                Login
              </Button>
              <Segment textAlign='center' vertical style={{ marginTop: 10 }}>
                <Message compact info>
                  New to us? <a href='#'>Register Here</a>
                    </Message>
              </Segment>
              </>
              )}
              </Space>
              
            </Container>
          </Segment>
        </Container>
      </Content>
      <LandingPageFooter />
    </Layout>
  );
})
