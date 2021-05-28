import { Button, Result, Typography } from 'antd';
import React from 'react';
import { useStore } from '../../app/stores/store';

export default function ServerError() {
    const { commonStore } = useStore();
    const { Paragraph, Text } = Typography
    
  return (
    <Result
      status='500'
      title='Internal Server Error'
      subTitle='Sorry, something went wrong on our end'
      extra={<Button type='primary'>Go Back Home</Button>}
      >
          {/* if error information exists show it */}
          { commonStore.error && (
              <div className='desc'>
                  <Paragraph>
                      <Text
                          strong
                          style={{
                              fontSize: 16,
                          }}
                      >
                          {commonStore.error?.title}
                      </Text>
                  </Paragraph>
                  <Paragraph>
                      {commonStore.error?.details && (<code style={{ marginTop: '10px' }}>{commonStore.error?.details}</code>)}
                  </Paragraph>
              </div>
          )}
    </Result>
  );
}