import { observer } from 'mobx-react-lite';
import React from 'react';
import StudyList from './StudyList';

export default observer(function StudyDashboard() {
    return (
        <>
        <h1>Study Dashboard</h1>
            <StudyList />
        </>
    )
})