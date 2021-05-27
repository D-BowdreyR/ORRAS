import { DatabaseFilled } from '@ant-design/icons';
import { Breadcrumb, Card, List } from 'antd';
import { Content } from 'antd/lib/layout/layout';
import axios from 'axios';
import { observer } from 'mobx-react-lite';
import React, { useEffect, useState } from 'react'
import agent from '../../app/api/agent';
import { Study } from '../../app/models/study';
import { useStore } from '../../app/stores/store';

export default observer(function Dashboard() {
    const { studyStore } = useStore();
    const { loadStudies, studyRegistry, studiesByDate, loadingInitial } = studyStore;
    
    useEffect(() => {
        if (studyRegistry.size <= 1) loadStudies();
      }, [studyRegistry.size, loadStudies])
    
    return (
        <div className='dashboard'>
            <Breadcrumb style={{ margin: '16px 0' }}>
              <Breadcrumb.Item>Dashboard</Breadcrumb.Item>
            </Breadcrumb>
            <List loading={loadingInitial}>
                {studiesByDate.map((study: Study) => (
                    <List.Item key={study.id}>
                        <List.Item.Meta
                            title={study.shortTitle}
                            description={study.longTitle}
                        />
                    </List.Item>
            ))}
            </List>
            
            <div className="site-layout-background" style={{ padding: 24, minHeight: 360 }}>
                <ul>

              </ul>
            </div>
        </div>
    );
})