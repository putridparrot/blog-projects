import React from "react";
import { theme } from "../theme";

export const ThemeContext = React.createContext(theme);

export function ThemeProvider(props: any) {
  return (
    <ThemeContext.Provider value={props.theme}>
      {props.children}
    </ThemeContext.Provider>
  );
}