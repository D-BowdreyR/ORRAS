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
import StudyDetails from '../../features/studies/details/StudyDetails';
import PrivateRoute from './PrivateRoute';

const {Header, Content, Footer } = Layout;

export default observer(function AppLayout() {

  const { commonStore } = useStore();

  if(!commonStore.appLoaded) return <LoadingPage/>
  
  return (
    <Layout style={{ minHeight: '100vh' }}>
      <SideNavBar />
      <Layout>
        {/* <div className="logo" /> */}
        {/* <Header style={{ background: "#fff", padding:0}} /> */}
         <TopNavBar/>
    <Layout className="site-layout">
      
      <Content style={{ margin: "16px 16px", background: "#fff" }}>
        <div style={{ padding: 24, background: "#fff", minHeight: 360 }}>
              <Switch>
                
                <PrivateRoute exact path="/dashboard" component={Dashboard} />
                <PrivateRoute exact path="/researchstudies" component={StudyDashboard} />
                <PrivateRoute exact path="/assurancerequests" component={AssuranceRequestsDashboard} />
                <PrivateRoute exact path="/clinical" component={ClinicalDashboard} />
                <PrivateRoute path='/researchstudies/:id' component={StudyDetails} />
                <PrivateRoute exact path="/errors" component={TestErrors} />
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
