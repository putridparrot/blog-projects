import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import { BrowserRouter, Route } from 'react-router-dom'
import * as serviceWorker from './serviceWorker';
import About from './components/About';
import Home from './components/Home';

ReactDOM.render((    
    <BrowserRouter>
        <Route exact path="/" component={Home} />
        <Route exact path="/home" component={Home} />
        <Route exact path="/about" component={About} />
  </BrowserRouter>), 
    document.getElementById('root'));

serviceWorker.unregister();
