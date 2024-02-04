import { useState } from 'react'
import './App.css';
import { Counter } from './components/Counter';
import { Pokemon } from './components/Pokemon';

const pokemon = ['bulbasaur', 'pikachu', 'ditto', 'bulbasaur']

function App() {
  const [pollingInterval, setPollingInterval] = useState(0)

  return (
    <div className="App">
      <header className="App-header">
        <Counter />

        <div>
        {pokemon.map((poke, index) => (
          <Pokemon key={index} name={poke} pollingInterval={pollingInterval} />
        ))}
      </div>
      </header>
    </div>
  );
}

export default App;
