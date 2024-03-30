import { create } from "zustand";
import { devtools, persist } from "zustand/middleware"
import type {} from "@redux-devtools/extension";

interface CounterState {
    counter: number;
    increment: () => void;
    decrement: () => void;
}

export const useCounterStore = create<CounterState>()(
    devtools (
        persist (
            set => ({
                counter: 0,
                increment: () => set(state => ({ counter: state.counter + 1 })),
                decrement: () => set(state => ({ counter: state.counter - 1 })),
            }),
            {
                name: "counter-store",
            }
        )
    )
);