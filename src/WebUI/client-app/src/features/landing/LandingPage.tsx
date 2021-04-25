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
import LandingPageFooter from './LandingPageFooter';
import LandingPageHeader from './LandingPageHeader';
import VersionInfo from './LandingPageVersionInfo';

export default function LandingPage() {
  return (
    <div>
        <LandingPageHeader/>
      <Container>
        <Segment textAlign='center' vertical>
          <Container text>
            <Header as='h1'>ORRAS</Header>
            <Header content='Welcome to the Oxford Radiation Research Assurance Service' />
            <Button as={Link} to='/dashboard'  positive>Sign in</Button>
            <Segment textAlign='center' vertical style={{ marginTop: 10 }}>
              <Message compact info>
                New to us? <a href='#'>Register Here</a>
              </Message>
            </Segment>
          </Container>
        </Segment>
      </Container>
        <LandingPageFooter/>
    </div>
  );
}
