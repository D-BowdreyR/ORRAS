import React from 'react';
import {
  Container,
  Divider,
  Grid,
  Header,
  List,
  Segment,
} from 'semantic-ui-react';
import LandingPageVersionInfo from './LandingPageVersionInfo';
export default function LandingPageBanner() {
  return (
    <div className="landing-footer">
      <Segment inverted>
        <Container>
          <Grid divided stackable>
            <Grid.Row>
              <Grid.Column width={4}>
                <Header inverted as='h4' content='About' />
                <List inverted link>
                  <List.Item as='a'>Item 1</List.Item>
                  <List.Item as='a'>Item 2</List.Item>
                  <List.Item as='a'>Item 3</List.Item>
                </List>
              </Grid.Column>
              <Grid.Column width={4}>
                <Header inverted as='h4' content='Services' />
                <List inverted link>
                  <List.Item as='a'>Item 1</List.Item>
                  <List.Item as='a'>Item 2</List.Item>
                  <List.Item as='a'>Item 3</List.Item>
                </List>
              </Grid.Column>
              <Grid.Column width={7}>
                <LandingPageVersionInfo />
              </Grid.Column>
            </Grid.Row>
          </Grid>
        </Container>
          </Segment>
        </div>
  );
}
