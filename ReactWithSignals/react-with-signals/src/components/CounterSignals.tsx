import React from 'react';
import { effect, useSignal } from "@preact/signals-react";


export const CounterSignals = () => {
    const count = useSignal(0);
    
    // effect(() => console.log(`effect: ${count.value}`));

    console.log("Render CounterSignals");

    return (
        <div>
            <div>Current Value {count}</div>
            <div>
                <button onClick={() => count.value--}>Decrement</button>
                <button onClick={() => count.value++}>Increment</button>
            </div>
        </div>
    );
}