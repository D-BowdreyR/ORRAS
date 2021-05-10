import { Footer } from 'antd/lib/layout/layout';
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
    <Footer style={{ textAlign: 'center' }}>
      <LandingPageVersionInfo />
      <div style={{marginTop:'2px', color: 'slategray'}}>
      Copyright &copy; 2021 Oxford University Hospitals NHS Foundation Trust
      </div>
        </Footer>
  );
}
