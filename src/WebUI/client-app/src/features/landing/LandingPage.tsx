import Layout, { Content } from 'antd/lib/layout/layout';
import { observer } from 'mobx-react-lite';
import React from 'react';
import { Link } from 'react-router-dom';
import {
  Button,
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
import { useStore } from '../../app/stores/store';
import LoginForm from '../users/LoginForm';
import LandingPageFooter from './LandingPageFooter';
import LandingPageHeader from './LandingPageHeader';

export default observer(function LandingPage() {
  const { modalStore } = useStore();
  
  return (
    <Layout style={{ minHeight: '100vh', background: "#fff"}}>
      <LandingPageHeader />
      <Content className='landing-image' >
        <Container>
          <Segment textAlign='center' vertical>
            <Container text>
              <Header as='h1'>ORRAS</Header>
              <Header content='Welcome to the Oxford Research Radiation Assurance Service'/>
              <Button positive onClick={() => modalStore.openModal(<LoginForm />)}>
                Login
              </Button>
              <Segment textAlign='center' vertical style={{ marginTop: 10 }}>
                <Message compact info>
                  New to us? <a href='#'>Register Here</a>
                </Message>
              </Segment>
            </Container>
          </Segment>
        </Container>
      </Content>
      <LandingPageFooter />
    </Layout>
  );
})
