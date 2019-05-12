import React, { Component } from 'react';
import './App.css';
import {Observable, Subscriber, Subscription, Observer} from 'rxjs';

interface ServiceState {
  data: string;
}

class ServiceComponent extends Component<{}, ServiceState> {

  _subscription!: Subscription;

  constructor(prop: any) {
    super(prop);
    this.state = {
      data : "Busy"
    };
  }

  fetch() : Observable<string> {
    return Observable.create((o: Observer<string>) => {
      setTimeout(() => {
        o.next('Some data');
        o.complete();
      }, 3000);
    });
  }

  componentDidMount() {
    this._subscription = this.fetch().subscribe(s => {
      this.setState({data: s})
    });
  }

  componentWillUnmount() {
    if(this._subscription) {
      this._subscription.unsubscribe();
    }
  }  

  render() {
    return (
      <div>{this.state.data}</div>
    );
  }
}


const App: React.FC = () => {
  return (
    <div className="App">
      <header className="App-header">
        <p>
          <ServiceComponent />
        </p>
      </header>
    </div>
  );
}

export default App;
