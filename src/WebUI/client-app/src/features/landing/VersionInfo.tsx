import React from "react";
import { Icon, Table } from "semantic-ui-react";

export default function VersionInfo() {
  return (
    <Table definition>
          <Table.Header fullWidth>
              <Table.Row>
              <Table.Cell colspan='2' textAlign='center' width='2'>Clinical Software Label</Table.Cell>
              </Table.Row>
      </Table.Header>

      <Table.Body>
        <Table.Row>
          <Table.Cell textAlign='left'>
            <Icon name="industry" size='small' />
            Manufacturer
          </Table.Cell>
          <Table.Cell textAlign='left'>Medical Physics and Clinical Engineering<br/>Business and Informatics Group</Table.Cell>
        </Table.Row>
        <Table.Row>
          <Table.Cell><Icon name='time' size='small'/>Manufacture Date</Table.Cell>
          <Table.Cell>02/02/2021</Table.Cell>
        </Table.Row>
      </Table.Body>
    </Table>
  );
}
