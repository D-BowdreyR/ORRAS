
import { Breadcrumb } from 'antd';
import Title from 'antd/lib/typography/Title';
import { observer } from 'mobx-react-lite';
import React from 'react';
import StudyList from './StudyList';

export default observer(function StudyDashboard() {
    return (
        <>
             <Breadcrumb style={{ margin: '16px 0' }}>
                <Breadcrumb.Item>ORRAS</Breadcrumb.Item>
                <Breadcrumb.Item>Research Studies</Breadcrumb.Item>
            </Breadcrumb>
        <Title>Studies Dashboard</Title>
            <StudyList />
        </>
    )
})