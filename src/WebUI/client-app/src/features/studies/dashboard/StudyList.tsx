import { Breadcrumb, Card, List } from 'antd';
import { Table } from 'formik-antd';
import { observer } from 'mobx-react-lite';
import React, { useEffect } from 'react';
import { NavLink } from 'react-router-dom';
import { Study } from '../../../app/models/study';
import { useStore } from '../../../app/stores/store';
import StudyListItem from './StudyListItem';

export default observer(function StudyList() {
    const { studyStore } = useStore();
    const { loadStudies, studyRegistry, studiesByDate, loadingInitial } = studyStore;
    
    useEffect(() => {
        if (studyRegistry.size <= 1) loadStudies();
      }, [studyRegistry.size, loadStudies])
        
        
    return (

        <div className='dashboard'>
           
            <List loading={loadingInitial}>
                {studiesByDate.map((study: Study) => (
                    <List.Item key={study.id}>
                        <List.Item.Meta
                            title={<NavLink to={`researchstudies/${study.id}`}>{study.shortTitle}</NavLink>}
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
    )
})