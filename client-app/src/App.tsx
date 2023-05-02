import React, { useEffect, useState } from 'react';
import logo from './logo.svg';
import './App.css';
import axios from 'axios';

function App() {
  //this one is a react hook, but I don't know what it does
  const [activities, setActivities] = useState([]);

  // a "React Hook" to get the information from the api database
  useEffect(() => {
    axios.get('http://localhost:5000/api/activites').then(response => {
    console.log(response);  
    setActivities(response.data);
    })
  }, [])

  //The webpage being rendered into the browser
  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <ul>
          {activities.map((activity: any) => (
            <li key={activity.id}>
              {activity.title}
            </li>
          ))}
        </ul>
      </header>
    </div>
  );
}

export default App;
