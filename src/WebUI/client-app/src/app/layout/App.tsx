import { useEffect } from 'react';
import { Route } from 'react-router-dom';
import LandingPage from '../../features/landing/LandingPage';
import AppLayout from './AppLayout';
import ModalContainer from '../common/modals/ModalContainer';
import { observer } from 'mobx-react-lite';
import { useStore } from '../stores/store';

function App() {
  const { commonStore, userStore } = useStore();
  
  // persist the user login by getting a locally stored token
  useEffect(() => {
    if (commonStore.token) {
      userStore.getUser().finally(() => commonStore.setAppLoaded())
    } else {
      commonStore.setAppLoaded();
    }
  }, [commonStore, userStore])

  return (
    <>
    <ModalContainer />
    <Route exact path='/' component={LandingPage} />
      <Route
        path={'/(.+)'}
        render={() => (
          <>
           <AppLayout />
          </>
        )}
      />
    </>
  );
}
export default observer(App);
