import { Fragment, useEffect, useState } from 'react';
import axios from 'axios';
import List from 'semantic-ui-react/dist/commonjs/elements/List';
import { Activity } from '../models/activity';
import NavBar from './NavBar';
import { Container } from 'semantic-ui-react';

function App() {
  const [activities, setActivities] = useState<Activity[]>([]);

  useEffect(() => {
    axios.get<Activity[]>('https://localhost:5000/api/activities')
      .then(response => {
        setActivities(response.data);
      })
  }, []);

  return (
    <>
      <NavBar />
      <Container style={{marginTop: '7em'}}>
        <List>
          {
            activities.map(activity => (
              <List.Item key={activity.id}>
                {activity.title}
              </List.Item>
            ))
          }
        </List>
      </Container>
    </>
  );
}

export default App;
