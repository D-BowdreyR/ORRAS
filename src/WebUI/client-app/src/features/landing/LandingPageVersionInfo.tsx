import React from "react";
import { Icon, List } from "semantic-ui-react";

export default function LandingPageVersionInfo() {
  return (
    <List horizontal>
      <List.Item>
      <List.Content>
        <List.Header><Icon name='industry'/>Manufacturer</List.Header>
        <List.Description as='a' href='https://ouh.nhs.uk/medphys/' target='_blank'>
        Medical Physics and Clinical Engineering
        </List.Description>
      </List.Content>
    </List.Item>
    <List.Item >
      <List.Content>
        <List.Header><Icon name='github'/>Manufacture Date</List.Header>
          <List.Description as='a' href='https://github.com/D-BowdreyR/ORRAS' target='_blank'>
            See GitHub Repo
        </List.Description>
      </List.Content>
      </List.Item>
      <List.Item>
      <List.Content>
        <List.Header><Icon name='code branch'/>Release</List.Header>
          <List.Description>
            Version: 0.0.0
        </List.Description>
      </List.Content>
      </List.Item>
      <List.Item>
      <List.Content>
        <List.Header><Icon name='book'/>Documentation</List.Header>
          <List.Description as='a' href='https://d-bowdreyr.github.io/ORRAS/#/' target='_blank'>
            Read Our Docs
        </List.Description>
      </List.Content>
    </List.Item>
  </List>
  );
}
