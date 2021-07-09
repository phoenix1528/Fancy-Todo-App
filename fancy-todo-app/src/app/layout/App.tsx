import { useState, useEffect } from 'react';
import './App.css';
import NavBar from './Navbar';
import TodoDashboard from '../../features/todos/dashboard/TodoDashboard';
import { ITodo } from '../../app/models/ITodo';
import { v4 as uuid } from 'uuid';
import agent from '../api/agent';
import LoadingComponent from './LoadingComponent';

function App() {
  const [todos, setTodos] = useState<ITodo[]>([]);
  const [selectedTodo, setSelectedTodo] =
    useState<ITodo | undefined>(undefined);
  const [editMode, setEditMode] = useState(false);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    agent.Todos.list().then((response) => {
      setTodos(response);
      setLoading(false);
    });
  }, [todos]);

  function handleSelectedTodo(id: string) {
    setSelectedTodo(todos.find((t) => t.id === id));
  }

  function handleCancelSelectedTodo() {
    setSelectedTodo(undefined);
  }

  function handleFormOpen(id?: string) {
    id ? handleSelectedTodo(id) : handleCancelSelectedTodo();
    setEditMode(true);
  }

  function handleFormClose() {
    setEditMode(false);
  }

  function handleCreateTodo(todo: ITodo) {
    setLoading(true);
    if (todo.id) {
      agent.Todos.update(todo).then(() => {
        setTodos((prevTodos) => {
          prevTodos = [...todos.filter((t) => t.id !== todo.id)];
          prevTodos.unshift(todo);
          return prevTodos;
        });
        setEditMode(false);
        setSelectedTodo(todo);
        setLoading(false);
      });
    } else {
      todo.id = uuid();
      agent.Todos.create(todo).then(() => {
        setTodos([...todos, todo]);
        setEditMode(false);
        setSelectedTodo(todo);
        setLoading(false);
      });
    }
  }

  function handleDeleteTodo(id: string) {
    setLoading(true);
    agent.Todos.delete(id).then(() => {
      setTodos([...todos.filter((t) => t.id !== id)]);
      setSelectedTodo(undefined);
      setEditMode(false);
      setLoading(false);
    });
  }

  return (
    <div>
      {loading && <LoadingComponent />}
      <NavBar openForm={handleFormOpen} />
      <div className='container'>
        <TodoDashboard
          todos={todos}
          selectedTodo={selectedTodo}
          selectTodo={handleSelectedTodo}
          cancelSelectTodo={handleCancelSelectedTodo}
          editMode={editMode}
          openForm={handleFormOpen}
          closeForm={handleFormClose}
          createTodo={handleCreateTodo}
          deleteTodo={handleDeleteTodo}
        />
      </div>
    </div>
  );
}

export default App;
