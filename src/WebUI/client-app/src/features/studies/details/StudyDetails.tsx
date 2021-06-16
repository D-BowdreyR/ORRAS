import { AuditOutlined, BookFilled, BookTwoTone, CommentOutlined, EllipsisOutlined, ExperimentOutlined, FileTextOutlined, MessageOutlined, PaperClipOutlined } from '@ant-design/icons';
import { Button, Card, Col, Descriptions, Divider, Menu, PageHeader, Row, Space, Spin, Tabs, Tag } from 'antd';
import { observer } from 'mobx-react-lite';
import React, { useEffect } from 'react';
import { useParams } from 'react-router-dom';
import { useStore } from '../../../app/stores/store';

export default observer(function StudyDetails() {
    const { studyStore } = useStore();
    const { loadStudy, studyRegistry, studiesByDate, loadingInitial, selectedStudy: study } = studyStore;
    
  const { id } = useParams<{ id: string }>();
  
    function callback(key: any) {
        console.log(key);
    }
    
    useEffect(() => {
      if (id) loadStudy(id);
    }, [id, loadStudy])
    
    if (loadingInitial || !study) return <Spin tip='Loading...'/>;
    
  return (
  <div>
        <PageHeader
        className="study-page-header"
      ghost={false}
      onBack={() => window.history.back()}
      title={(<Space><BookTwoTone style={{fontSize:'21px'}} />Study</Space>)}
            subTitle={study.acronym}
        tags={<>
          <Tag color='orange'>Awaiting Approval</Tag> <Tag color='red'>a second tag</Tag>
        </>}
      extra={[
        <Button key="3">Operation</Button>,
        <Button key="2">Operation</Button>,
        <Button key="1" type="primary">
          Primary
        </Button>,
      ]}
    >
      <Descriptions title="Basic Details" size="small" column={3}>
          <Descriptions.Item label="Oxford PID"><a>{study.localPID || "-"}</a></Descriptions.Item>
        <Descriptions.Item label="est. Start Date">
          {study.estimatedStartDate}
        </Descriptions.Item>
          <Descriptions.Item label="Record Created">{study.created}</Descriptions.Item>
          <Descriptions.Item label="IRAS PID">{study.irasProjectID}</Descriptions.Item>
          <Descriptions.Item label="HRA Ref">{study.hraReference}</Descriptions.Item>
          <Descriptions.Item label="another property">-</Descriptions.Item>

          <Descriptions.Item label="Lead Site">Site Name Here</Descriptions.Item>
        <Descriptions.Item label="Study Type">
                    Study Category Here
        </Descriptions.Item>
        <Descriptions.Item label="Chief Investigator">-</Descriptions.Item>
                <Descriptions.Item label="Long Title" span={3}>
                    {study.longTitle}
        </Descriptions.Item>

          
        </Descriptions>
            </PageHeader>
    <div style={{paddingTop: '10px'}}>
        <Tabs defaultActiveKey="1" onChange={callback} type='card'>
            <Tabs.TabPane tab={<span><FileTextOutlined/>More Details</span>} key="1">
                More Details Goes here
                 <Row gutter={[24,24]}>
                    <Col span={4}>
                        <Menu mode='vertical-left' title="Menu">
                            <Menu.Item>Details</Menu.Item>
                        </Menu>
                    </Col>
                    <Col span={20}>
                    <Card title="Detail"></Card>
                    </Col>
                 </Row>
                <Row gutter={[24, 24]}>
                <Col span={4}>
                    </Col>
                    <Col span={20}>
                    <Card title="People"></Card>
                    </Col>
                </Row>
                

                
    </Tabs.TabPane >
    <Tabs.TabPane  tab={<span><ExperimentOutlined/>Protocol</span>} key="2">
                Protocol and Procedure Details goes here
    </Tabs.TabPane >
    <Tabs.TabPane  tab={<span><PaperClipOutlined/>Documents</span>} key="3">
                All associated documents goes here
    </Tabs.TabPane >
    <Tabs.TabPane  tab={<span><AuditOutlined/>Approvals</span>}key="4">
                details of approvals goes here
    </Tabs.TabPane >
    <Tabs.TabPane  tab={<span><CommentOutlined/>Comments</span>} key="5">
                Thread of Comments goes here
    </Tabs.TabPane >
        </Tabs>
        </div>
    </div>)
})