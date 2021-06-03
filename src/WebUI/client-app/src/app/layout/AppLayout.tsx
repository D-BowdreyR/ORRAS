import { Layout } from 'antd';
import { Route, Switch } from 'react-router-dom';
import Dashboard from '../../features/dashboard/Dashboard';
import TopNavBar from './TopNavBar';
import SideNavBar from './SideNavBar';
import { observer } from 'mobx-react-lite';
import StudyDashboard from '../../features/studies/dashboard/StudyDashboard';
import AssuranceRequestsDashboard from '../../features/assurancerequests/dashboard/AssuranceRequestsDashboard';
import ClinicalDashboard from '../../features/clinical/dashboard/ClinicalDashboard';
import TestErrors from '../../features/errors/TestError';
import NotFound from '../../features/errors/NotFound';
import ServerError from '../../features/errors/ServerError';
import { useStore } from '../stores/store';
import LoadingPage from './LoadingPage';

const { Content, Footer } = Layout;

export default observer(function AppLayout() {

  const { commonStore } = useStore();

  if(!commonStore.appLoaded) return <LoadingPage/>
  
  return (
    <Layout style={{ minHeight: '100vh' }}>
      <SideNavBar />
      <Layout>
      {/* <div className="logo" /> */}
         <TopNavBar/>
    <Layout className="site-layout">
      {/* <Header className="site-layout-background" style={{ padding: 0 }} /> */}
      <Content style={{ margin: "16px 16px", background: "#fff" }}>
        <div style={{ padding: 24, background: "#fff", minHeight: 360 }}>
              <Switch>
                
                <Route exact path="/dashboard" component={Dashboard} />
                <Route exact path="/researchstudies" component={StudyDashboard} />
                <Route exact path="/assurancerequests" component={AssuranceRequestsDashboard} />
                <Route exact path="/clinical" component={ClinicalDashboard} />
                <Route exact path="/errors" component={TestErrors} />
                <Route path='/server-error' component={ServerError} />
                <Route component={NotFound} />

                
          </Switch>
        </div>
      </Content>
      <Footer style={{ textAlign: 'center', color:'slategray' }}>Copyright &copy; 2021 Oxford University Hospitals NHS Foundation Trust</Footer>
    </Layout>
  </Layout>
  </Layout>
  );
})
