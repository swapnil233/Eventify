import { useEffect, useState } from 'react';
import '../layout/styles.css'
import axios from 'axios';
import { Container, Header } from 'semantic-ui-react';
import ActivityDashboard from '../features/activities/dashboard/ActivityDashboard';
import NavBar from './NavBar';

function App() {
  const [activities, setActivities] = useState([]);

  useEffect(() => {
    axios.get('https://localhost:5000/api/activities')
      .then(response => {
        setActivities(response.data);
      })
  }, []);

  return (
    <>
      <NavBar />
      <Container style={{marginTop:'7em'}}>
        <ActivityDashboard activities={activities}/>
      </Container>
    </>
  );
}

export default App;