import { ITodo } from '../../../app/models/ITodo';
import sports from '../../../../src/sports.jpg';
import {
  dateFormatterDe,
  dateFormatterEn,
} from '../../../app/constants/DateFormatters';

interface Props {
  todos: ITodo[];
  selectTodo: (id: string) => void;
  deleteTodo: (id: string) => void;
}

export default function TodoList({ todos, selectTodo, deleteTodo }: Props) {
  return (
    <section>
      {todos.map((todo) => (
        <div className='card mt-3' key={todo.id}>
          <div className='card-body'>
            <h5 className='card-title'>{todo.title}</h5>
            <p className='card-text'>{todo.description}</p>
            <p className='card-text'>
              <small className='text-muted'>
                Von {dateFormatterDe.format(todo.startDate)} bis{' '}
                {dateFormatterEn.format(todo.endDate)}
              </small>
            </p>
            <div className='d-flex justify-content-end'>
              <button
                className='btn btn-danger'
                onClick={() => deleteTodo(todo.id)}
              >
                Delete
              </button>
              <button
                className='btn btn-primary'
                onClick={() => selectTodo(todo.id)}
              >
                Details
              </button>
            </div>
          </div>
          <img
            className='card-img-bottom'
            src={sports}
            style={{ color: 'blue', height: '200px', width: 'auto' }}
            alt='sports category'
          />
        </div>
      ))}
    </section>
  );
}
