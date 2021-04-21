import React from 'react'
import { Menu, Image, Container, Header, Segment } from 'semantic-ui-react';

export default function LandingPageHeader()
{
    return (
        <Menu fluid borderless>
        <Menu.Item position='left'>
          <Image
            src='/assets/radiation.svg'
            style={{ marginTop: 7 }}
            verticalAlign='top'
            size='mini'
            spaced
          />
          <Menu.Item>
            <Image
              src='/assets/orru-logo-300.png'
              style={{ marginTop: 7 }}
              verticalAlign='top'
              size='tiny'
              spaced
            />
          </Menu.Item>
        </Menu.Item>
        <Menu.Item position='right'>
          <Image
            src='/assets/ouh_logo_right_aligned_RGB.png'
            alt='Oxford University NHS Foundation Trust logo'
            style={{ marginTop: 5 }}
            verticalAlign='top'
            size='small'
          />
        </Menu.Item>
      </Menu>
    );
};