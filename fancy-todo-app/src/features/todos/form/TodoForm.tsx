import React, { ChangeEvent, FormEvent, useState } from 'react';
import { ITodo } from '../../../app/models/ITodo';
import { format } from 'date-fns';

interface IProps {
  todo: ITodo | undefined;
  closeForm: () => void;
  createTodo: (todo: ITodo) => void;
}

function TodoForm({ todo: selectedTodo, closeForm, createTodo }: IProps) {
  const initialState = selectedTodo ?? {
    id: '',
    title: '',
    description: '',
    endDate: '',
    startDate: '',
    category: '',
    city: '',
    venue: '',
  };

  const [todo, setTodo] = useState(initialState);

  function handleSubmit(event: FormEvent) {
    event?.preventDefault();
    console.log(todo);
    createTodo(todo);
  }

  function handleIputChange(
    event: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>
  ) {
    const { name, value } = event.target;
    setTodo({ ...todo, [name]: value });
  }

  return (
    <section className='card mt-3'>
      <form className='card-body' onSubmit={handleSubmit} autoComplete='off'>
        <div>
          <h5 className='card-title'>Edit Todo</h5>
        </div>
        <div className='form-row'>
          <div className='form-group col-md-12'>
            <label htmlFor='title'>Title</label>
            <input
              type='text'
              className='form-control'
              id='title'
              placeholder='My Todo'
              value={todo.title}
              name='title'
              onChange={handleIputChange}
            />
          </div>
        </div>
        <div className='form-row'>
          <div className='form-group col-md-12'>
            <label htmlFor='description'>Description</label>
            <textarea
              className='form-control'
              id='description'
              placeholder='Todo description'
              value={todo.description}
              name='description'
              onChange={handleIputChange}
            />
          </div>
        </div>
        <div className='form-group'>
          <label htmlFor='category'>Category</label>
          <input
            type='text'
            className='form-control'
            id='category'
            placeholder='Sports Activity'
            value={todo.category}
            name='category'
            onChange={handleIputChange}
          />
        </div>
        <div className='form-group'>
          <label htmlFor='startDate'>Start Date</label>
          <input
            type='date'
            className='form-control'
            id='startDate'
            value={todo.startDate}
            name='startDate'
            onChange={handleIputChange}
          />
        </div>
        <div className='form-group'>
          <label htmlFor='endDate'>End Date</label>
          <input
            type='date'
            className='form-control'
            id='endDate'
            value={todo.endDate}
            name='endDate'
            onChange={handleIputChange}
          />
        </div>
        <div className='form-row'>
          <div className='form-group col-md-6'>
            <label htmlFor='city'>City</label>
            <input
              type='text'
              className='form-control'
              id='city'
              value={todo.city}
              name='city'
              onChange={handleIputChange}
            />
          </div>
          <div className='form-group col-md-4'>
            <label htmlFor='venue'>Venue</label>
            <input
              type='text'
              id='venue'
              className='form-control'
              placeholder='Forest'
              value={todo.venue}
              name='venue'
              onChange={handleIputChange}
            />
          </div>
        </div>
        <div className='d-flex justify-content-between'>
          <button onClick={closeForm} className='btn btn-danger'>
            Cancel
          </button>
          <button type='submit' className='btn btn-primary'>
            Submit
          </button>
        </div>
      </form>
    </section>
  );
}

export default TodoForm;
