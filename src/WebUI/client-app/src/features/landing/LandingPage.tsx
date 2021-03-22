import React from "react";
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
} from "semantic-ui-react";
import VersionInfo from "./VersionInfo";

export default function LandingPage() {
  return (
    <Grid columns='equal'>
      <Grid.Row>
        <Grid.Column>
          <Grid.Row>
            <Container>
              <Segment textAlign='left' vertical>
                <Image
                  src='/assets/radiation.svg'
                  style={{ marginTop: 7 }}
                  verticalAlign='top'
                  size='mini'
                  spaced
                />
                <Image
                  src='/assets/OUH_LOGO_WEB-VERSION_RGB.png'
                  alt='Oxford University NHS Foundation Trust logo'
                  style={{ marginTop: 5 }}
                  verticalAlign='top'
                  size='small'
                />
              </Segment>
            </Container>
          </Grid.Row>
        </Grid.Column>
      </Grid.Row>
      <Grid.Row>
        <GridColumn>
          <Container>
            <Segment textAlign='center' vertical>
              <Container text>
                <Header as='h1'>ORRA</Header>
                <Header content='Welcome to Oxford Radiation Research Assurance' />
                <Button positive>Sign in</Button>
                <Segment textAlign='center' vertical style={{marginTop:10}}>
                  <Message compact info>
                    New to us? <a href='#'>Register Here</a>
                  </Message>
                </Segment>
              </Container>
            </Segment>
          </Container>
        </GridColumn>
          </Grid.Row>
          <Grid.Row>
              <Grid.Column />
            <Grid.Column/>
          <Grid.Column verticalAlign='bottom'>
        <Container>
            <Segment style={{marginRight:20}}>
            <VersionInfo/>              
          </Segment>
        </Container>
      </Grid.Column>
          </Grid.Row>
      
    </Grid>
  );
}
