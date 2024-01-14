import React from "react";
import ReactDOM from "react-dom";
import { StyledEngineProvider } from "@mui/material/styles";

import "./index.css";
import { About } from "./components/About";

const App = () => (
  <StyledEngineProvider injectFirst>
    <About />
  </StyledEngineProvider>  
);
ReactDOM.render(<App />, document.getElementById("app"));
