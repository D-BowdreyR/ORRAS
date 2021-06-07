import { DatabaseFilled } from '@ant-design/icons';
import { Breadcrumb, Card, List } from 'antd';
import { Content } from 'antd/lib/layout/layout';
import axios from 'axios';
import { observer } from 'mobx-react-lite';
import React, { useEffect, useState } from 'react'
import { NavLink } from 'react-router-dom';
import agent from '../../app/api/agent';
import { Study } from '../../app/models/study';
import { useStore } from '../../app/stores/store';

export default observer(function Dashboard() {
    
    return (
        <div className='dashboard'>
         Dashboard
        </div>
    );
})