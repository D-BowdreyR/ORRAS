import { Button, Result } from 'antd';
import React from 'react';


export default function NotAuthorised() {

    return (
        <Result
            status='403'
            title='403'
            subTitle='You are not authorised to access this page'
            extra={<Button type="primary">Go Back Home</Button>}

        />
    )
    
}