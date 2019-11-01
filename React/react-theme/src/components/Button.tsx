import React from "react";
import { ThemeContext } from "./ThemeProvider";

export const Button = (props: any) => (
  <ThemeContext.Consumer>
    {theme => (
      <button style={theme.button} {...props}>
        {props.children}
      </button>
    )}
  </ThemeContext.Consumer>
);