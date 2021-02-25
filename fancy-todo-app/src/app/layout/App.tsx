import React, { useState, useEffect } from "react";
import "./App.css";
import axios from "axios";
import NavBar from "./Navbar";
import TodoDashboard from "../../features/todos/dashboard/TodoDashboard";
import { ITodo } from "../../app/models/ITodo";
import { v4 as uuid } from "uuid";

function App() {
  const [todos, setTodos] = useState<ITodo[]>([]);
  const [selectedTodo, setSelectedTodo] = useState<ITodo | undefined>(
    undefined
  );
  const [editMode, setEditMode] = useState(false);

  useEffect(() => {
    axios
      .get<ITodo[]>("https://localhost:44326/api/todo/list")
      .then((response) => {
        console.log(response);

        setTodos(response.data);
        console.log("todos were set");
      });
  }, []);

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
    if (todo.id) {
      setTodos((prevTodos) => {
        prevTodos = [...todos.filter((t) => t.id !== todo.id)];
        prevTodos.unshift(todo);
        return prevTodos;
      });
    } else {
      setTodos([...todos, { ...todo, id: uuid() }]);
    }
    setEditMode(false);
    setSelectedTodo(todo);
  }

  function handleDeleteTodo(id: string) {
    setTodos([...todos.filter((t) => t.id !== id)]);
    setSelectedTodo(undefined);
    setEditMode(false);
  }

  return (
    <div>
      <NavBar openForm={handleFormOpen} />
      <div className="container">
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
