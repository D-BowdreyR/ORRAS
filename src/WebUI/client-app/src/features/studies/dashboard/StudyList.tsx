import { observer } from 'mobx-react-lite';
import React from 'react';
import StudyListItem from './StudyListItem';

export default observer(function StudyList() {
    return (
        <>
            <h2>Study List</h2>
            <StudyListItem/>
        </>
    )
})