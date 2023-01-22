import { useEffect, useState } from 'react';
import '../layout/styles.css'
import axios from 'axios';
import { Container } from 'semantic-ui-react';
import ActivityDashboard from '../features/activities/dashboard/ActivityDashboard';
import NavBar from './NavBar';
import { Activity } from '../models/activity';

function App() {
  const [activities, setActivities] = useState<Activity[]>([]);
  const [selectedActivity, setSelectedActivity] = useState<Activity | undefined>(undefined);

  useEffect(() => {
    axios.get('https://localhost:5000/api/activities')
      .then(response => {
        setActivities(response.data);
      })
  }, []);

  const handleSelectActivity = (id : string) => {
    setSelectedActivity(activities.find(x => x.id === id));
  }

  const handleCancelSelectActivity = () => {
    setSelectedActivity(undefined);
  }

  return (
    <>
      <NavBar />
      <Container style={{marginTop:'7em'}}>
        <ActivityDashboard 
          activities={activities}
          selectedActivity = {selectedActivity}
          selectActivity = {handleSelectActivity}
          cancelSelectActivity = {handleCancelSelectActivity}
          />
      </Container>
    </>
  );
}

export default App;