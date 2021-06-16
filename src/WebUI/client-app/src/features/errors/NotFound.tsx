import { Button, Result } from 'antd';
import React from 'react';

export default function NotFound() {

    return (
        <Result
            status='404'
            title='404'
            subTitle='We have looked everywhere, but we could not find this.'
            extra={<Button type="primary">Go Back Home</Button>}

        />
    )
    
}