import React, { useEffect, useState } from 'react';
import './App.css';
import { HubConnectionBuilder } from '@microsoft/signalr';


function App() {
  const [message, setMessage] = useState("");

  useEffect(() => {
    const connection = new HubConnectionBuilder()
      .withUrl("http://localhost:5021/notifications")
      .build();
  
    connection.start();  
    connection.on("NotifyMe", data => {
      setMessage(data);
    });
  }, [])  

  return (
    <div className="App">
      {message}
    </div>
  );
}

export default App;
