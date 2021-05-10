import React from "react";
import { Icon, List } from "semantic-ui-react";

export default function LandingPageVersionInfo() {
  return (
    <List horizontal>
    <List.Item>
      <Icon name='industry' />
      <List.Content>
        <List.Header>Manufacturer</List.Header>
        <List.Description as='a' href='https://ouh.nhs.uk/medphys/' target='_blank'>
        Medical Physics and Clinical Engineering
        </List.Description>
      </List.Content>
    </List.Item>
    <List.Item>
      <Icon name='github' />
      <List.Content>
        <List.Header>Manufacture Date</List.Header>
          <List.Description as='a' href='https://github.com/D-BowdreyR/ORRAS' target='_blank'>
            See GitHub Repo
        </List.Description>
      </List.Content>
      </List.Item>
      <List.Item>
      <Icon name='code branch' />
      <List.Content>
        <List.Header>Version</List.Header>
          <List.Description>
            Version: 0.0.0
        </List.Description>
      </List.Content>
      </List.Item>
      <List.Item>
      <Icon name='book' />
      <List.Content>
        <List.Header>Documentation</List.Header>
          <List.Description as='a' href='https://d-bowdreyr.github.io/ORRAS/#/' target='_blank'>
            View Our Documentation
        </List.Description>
      </List.Content>
    </List.Item>
  </List>
  );
}
