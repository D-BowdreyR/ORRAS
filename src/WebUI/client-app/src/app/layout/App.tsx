import React from "react";
import { Route, Switch } from "react-router-dom";
import { Container, Header, Icon } from "semantic-ui-react";
import Dashboard from "../../features/dashboard/Dashboard";
import LandingPage from "../../features/landing/LandingPage";
import SideNavBar from "./SideNavBar";
import TopBar from "./TopBar";

function App() {
  return (
    <>
      <Route exact path='/' component={LandingPage} />
      <Route
        path={'/(.+)'}
        render={() => (
          <>
            <TopBar />
            <SideNavBar/>
            <Container style={{marginTop: '7em'}}>
              <Switch>
                <Route exact path='/dashboard' component={Dashboard}/>
            </Switch>
            </Container>
          </>
        )}
      />
    </>
  );
}
export default App;
