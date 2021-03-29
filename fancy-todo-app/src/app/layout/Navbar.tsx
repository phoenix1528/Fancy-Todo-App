import React from 'react';
import toDoList from '../../to-do-list.svg';

interface IProps {
  openForm: () => void;
}

export default function NavBar({ openForm }: IProps) {
  return (
    <nav className='navbar navbar-expand-lg navbar-light bg-light sticky-top'>
      <a className='navbar-brand' href='http://localhost:3000/'>
        <img
          src={toDoList}
          alt='list-icon'
          style={{ color: 'blue', height: '30px', width: '30px' }}
        ></img>
      </a>
      <button
        className='navbar-toggler'
        type='button'
        data-toggle='collapse'
        data-target='#navbarNav'
        aria-controls='navbarNav'
        aria-expanded='false'
        aria-label='Toggle navigation'
      >
        <span className='navbar-toggler-icon'></span>
      </button>
      <div className='collapse navbar-collapse' id='navbarNav'>
        <ul className='navbar-nav'>
          <li className='nav-item active'>
            <a className='nav-link' href='http://localhost:3000/'>
              Home <span className='sr-only'>(current)</span>
            </a>
          </li>
          <li className='nav-item'>
            <button
              onClick={openForm}
              className='btn btn-outline-success'
              type='button'
            >
              Create Todo
            </button>
          </li>
        </ul>
      </div>
    </nav>
  );
}
