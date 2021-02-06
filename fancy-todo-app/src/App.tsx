import React, { Component } from 'react';
import logo from './logo.svg';
import './App.css';
import axios from 'axios';

interface IValue {
  id: number;
  name: string;
}

export default class App extends Component {
  state = {
    values: [],
  };

  componentDidMount() {
    axios
      .get('https://localhost:44326/api/WeatherForecast/values')
      .then((response) => {
        this.setState({
          values: response.data,
        });
      });
  }

  render() {
    return (
      <div className='App'>
        <header className='App-header'>
          <img src={logo} className='App-logo' alt='logo' />
          <ul>
            {this.state.values.map((value: IValue) => (
              <li>
                {value.id}:{value.name}
              </li>
            ))}
          </ul>
        </header>
      </div>
    );
  }
}
