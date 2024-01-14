import React from "react";
import ReactDOM from "react-dom";
import { StyledEngineProvider } from "@mui/material/styles";

import "./index.css";

import { About } from "about/About";
import { NavBar } from "navbar/NavBar";
import { Header } from "header/Header";
import { Box, CssBaseline } from "@mui/material";

const App = () => (
  <StyledEngineProvider injectFirst>
    <Box sx={{ display: "flex" }}>
      <CssBaseline />
      <Header />
      <NavBar />
      <div className="center-screen">
        <About />
      </div>
    </Box>
  </StyledEngineProvider>
);
ReactDOM.render(<App />, document.getElementById("app"));
