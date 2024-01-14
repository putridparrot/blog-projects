import React from "react";
import ReactDOM from "react-dom";
import { StyledEngineProvider } from "@mui/material/styles";

import "./index.css";
import { Header } from "./components/Header";

const App = () => (
  <StyledEngineProvider injectFirst>
    <Header />
  </StyledEngineProvider>  
);
ReactDOM.render(<App />, document.getElementById("app"));
