import React from 'react';
import { CounterState } from './components/CounterState';
import { CounterSignals } from './components/CounterSignals';

function App() {
  return (
    <div className="App">
      <CounterState />
      <CounterSignals />
    </div>
  );
}

export default App;
