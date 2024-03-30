import { useState } from "react";

export const CounterState = () => {
    const [count, setCount] = useState(0);

    console.log("Render CounterState");

    return (
        <div>
            <div>Current Value {count}</div>
            <div>
                <button onClick={() => setCount(count - 1)}>Decrement</button>
                <button onClick={() => setCount(count + 1)}>Increment</button>
            </div>
        </div>
    );
}