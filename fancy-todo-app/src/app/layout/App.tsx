import React, { useState, useEffect } from "react";
import "./App.css";
import axios from "axios";
import NavBar from "./Navbar";
import TodoDashboard from "../../features/todos/dashboard/TodoDashboard";
import { ITodo } from "../../app/models/ITodo";

function App() {
  const [todos, setTodos] = useState<ITodo[]>([]);

  useEffect(() => {
    axios
      .get<ITodo[]>("https://localhost:44326/api/todo/list")
      .then((response) => {
        console.log(response);

        setTodos(response.data);
        console.log("todos were set");
      });
  }, []);

  return (
    <div>
      <NavBar />
      <div className="container">
        <TodoDashboard todos={todos} />
      </div>
    </div>
  );
}

export default App;
