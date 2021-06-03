import { Space, Spin } from 'antd';
import Layout from 'antd/lib/layout/layout';
import React from 'react';

interface Props {}

export default function LoadingPage({}: Props) {
  return (
    <div
      style={{
        position: 'absolute',
        left: '50%',
        top: '50%',
        transform: 'translate(-50%, -50%)',
      }}
    >
          <Spin size='large' tip="Loading app..."/>
          
    </div>
  );
}
