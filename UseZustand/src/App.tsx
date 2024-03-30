import './App.css';
import { useCounterStore } from "./store";

function App() {
  const { counter, increment, decrement } = useCounterStore();
  
  return (
    <div className="App">
      <button onClick={increment}>+</button>
      <div>{counter}</div>
      <button onClick={decrement}>-</button>
    </div>
  );
}

export default App;
