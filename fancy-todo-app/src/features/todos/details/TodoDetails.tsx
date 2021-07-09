import sports from '../../../../src/sports.jpg';
import { ITodo } from '../../../app/models/ITodo';

interface Props {
  todo: ITodo;
  openForm: (id: string) => void;
  cancelSelectTodo: () => void;
}

export default function TodoDetails({
  todo,
  cancelSelectTodo,
  openForm,
}: Props) {
  return (
    <section className='card mt-3' style={{ width: '18rem' }}>
      <img className='card-img-top' src={sports} alt='todo' />
      <div className='card-body'>
        <h5 className='card-title'>{todo.title}</h5>
        <p className='card-text'>{todo.description}</p>
      </div>
      <ul className='list-group list-group-flush'>
        <li className='list-group-item'>{todo.category}</li>
        <li className='list-group-item'>{todo.city}</li>
        <li className='list-group-item'>{todo.venue}</li>
        <li className='list-group-item'>Von {todo.startDate}</li>
        <li className='list-group-item'>bis {todo.endDate}</li>
      </ul>
      <div className='card-body d-flex justify-content-between'>
        <button onClick={cancelSelectTodo} className='btn btn-danger'>
          Cancel
        </button>
        <button onClick={() => openForm(todo.id)} className='btn btn-success'>
          Edit Todo
        </button>
      </div>
    </section>
  );
}
