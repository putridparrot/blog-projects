import React from "react";
import ReactDOM from "react-dom";

import "./index.css";
import { NavBar } from "./components/NavBar";

const App = () => (
  <NavBar />
);
ReactDOM.render(<App />, document.getElementById("app"));
