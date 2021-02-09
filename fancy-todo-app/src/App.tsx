import React, { Component } from 'react';
import './App.css';
import toDoList from './to-do-list.svg';
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
      .get('https://localhost:44326/api/todo')
      .then((response) => {
        console.log(response);
        this.setState({
          values: response.data,
        });
      });
  }

  render() {
    return (
      <nav className='navbar navbar-expand-lg navbar-light bg-light'>
        <a
          className='navbar-brand medium-icon'
          href='http://localhost:8000/test'
        >
          <img src={toDoList} className='medium-icon' alt='logo' />
        </a>
        <button
          className='navbar-toggler'
          type='button'
          data-toggle='collapse'
          data-target='#navbarSupportedContent'
          aria-controls='navbarSupportedContent'
          aria-expanded='false'
          aria-label='Toggle navigation'
        >
          <span className='navbar-toggler-icon'></span>
        </button>

        <div className='collapse navbar-collapse' id='navbarSupportedContent'>
          <ul className='navbar-nav mr-auto'>
            <li className='nav-item'>
              <a className='nav-link' href='#'>
                Home <span className='sr-only'>(current)</span>
              </a>
            </li>
            <li className='nav-item'>
              <div>
                Icons made by{' '}
                <a href='https://www.freepik.com' title='Freepik'>
                  Freepik
                </a>{' '}
                from{' '}
                <a href='https://www.flaticon.com/' title='Flaticon'>
                  www.flaticon.com
                </a>
              </div>
            </li>
            <li className='nav-item dropdown'>
              <a
                className='nav-link dropdown-toggle'
                href='#'
                id='navbarDropdown'
                role='button'
                data-toggle='dropdown'
                aria-haspopup='true'
                aria-expanded='false'
              >
                Dropdown
              </a>
              <div className='dropdown-menu' aria-labelledby='navbarDropdown'>
                <a className='dropdown-item' href='#'>
                  Action
                </a>
                <a className='dropdown-item' href='#'>
                  Another action
                </a>
                <div className='dropdown-divider'></div>
                <a className='dropdown-item' href='#'>
                  Something else here
                </a>
              </div>
            </li>
          </ul>
          <form className='form-inline my-2 my-lg-0'>
            <input
              className='form-control mr-sm-2'
              type='search'
              placeholder='Search'
              aria-label='Search'
            />
            <button
              className='btn btn-outline-success my-2 my-sm-0'
              type='submit'
            >
              Search
            </button>
          </form>
        </div>
      </nav>
    );
  }
}
