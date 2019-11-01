import React from 'react';
import { ThemeProvider } from './components/ThemeProvider';
import { Button } from './components/Button';
import { myTheme } from './myTheme';
import { theme } from './theme';

const App: React.FC = () => {
  return (
    <ThemeProvider theme={theme}>
      <div className="App">
        <Button>Themed Button</Button>
      </div>
    </ThemeProvider>
  );
}

export default App;
