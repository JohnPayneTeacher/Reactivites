import React, { useEffect, useState } from 'react';
import logo from './logo.svg';
import './App.css';
import axios from 'axios';
import { Header, List } from 'semantic-ui-react';

function App() {
  //this one is a react hook, but I don't know what it does
  const [activities, setActivities] = useState([]);

  // a "React Hook" to get the information from the api database
  useEffect(() => {
    axios.get('http://localhost:5000/api/activities').then(response => {
    setActivities(response.data);
    })
  }, [])

  //The webpage being rendered into the browser
  return (
    <div>
      <Header as='h2' icon='users' content='Reactivities' />
        <List>
          {activities.map((activity: any) => (
            <List.Item key={activity.id}>
              {activity.title}
            </List.Item>
          ))}
        </List>
    </div>
  );
}

export default App;
