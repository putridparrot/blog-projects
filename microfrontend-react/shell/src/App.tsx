import React, { Suspense, lazy } from "react";
import ReactDOM from "react-dom";
import { StyledEngineProvider } from "@mui/material/styles";

import "./index.css";

import { Box, CssBaseline, createTheme, darken } from "@mui/material";
import { Loading } from "./components/Loading";
import { ErrorBoundary } from "react-error-boundary";
import { ThemeProvider } from "@emotion/react";
import { blueGrey } from "@mui/material/colors";

//import { About } from "about/About";
//import { NavBar } from "navbar/NavBar";
//import { Header } from "header/Header";

const About = React.lazy(() =>
  import("about/About").then((module) => ({ default: module.About }))
);
const NavBar = React.lazy(() =>
  import("navbar/NavBar").then((module) => ({ default: module.NavBar }))
);
const Header = React.lazy(() =>
  import("header/Header").then((module) => ({ default: module.Header }))
);

const Slow = lazy(() => import("./components/Slow"));

const theme = createTheme({
  palette: {
    mode: "light",    
    primary: blueGrey
  },
});

const App = () => (
  <ThemeProvider theme={theme}>
    <CssBaseline />
    <ErrorBoundary fallback={<div>Something went wrong</div>}>
      <Suspense fallback={<Loading />}>
        <StyledEngineProvider injectFirst>
          <Box sx={{ display: "flex" }}>
            <Header />
            <NavBar />
            <div className="center-screen">
              <About />
              <Slow />
            </div>
          </Box>
        </StyledEngineProvider>
      </Suspense>
    </ErrorBoundary>
  </ThemeProvider>
);
ReactDOM.render(<App />, document.getElementById("app"));
