import React from 'react';
import ReactDOM from 'react-dom';
import * as serviceWorker from './serviceWorker';
import { Provider } from 'react-redux'
import { createStore } from 'redux'
import counterReducer from './reducers/counterReducer';
import CounterLink from './containers/CounterContainer';

const store = createStore(counterReducer);

ReactDOM.render(
    <Provider store={store}>
        <CounterLink />
    </Provider>, 
    document.getElementById('root')
);

serviceWorker.unregister();
