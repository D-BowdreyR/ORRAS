import { Alert, Button, List, Result } from 'antd';
import React from 'react';

interface Props {
    errors: any
 }

export default function ValidationErrors({errors}: Props) {
    
    return (
        <Alert
            message="Validation Errors"
            showIcon
            type="error"
            description={(<>
                {errors && (
                    <List>
                        {errors?.map((err: any, i: any) => {
                            <List.Item key={i}>{err}</List.Item>
                        })}
                    </List>
                )}
            </>)} />
    )
}