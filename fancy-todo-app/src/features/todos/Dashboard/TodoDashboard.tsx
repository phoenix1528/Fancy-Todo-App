import React from "react";
import { ITodo } from "../../../app/models/ITodo";
import TodoDetails from "../details/TodoDetails";
import TodoForm from "../form/TodoForm";
import TodoList from "./TodoList";

interface Props {
  todos: ITodo[];
}

export default function TodoDashboard({ todos }: Props) {
  return (
    <main className="d-flex justify-content-center">
      <div className="mt-5">
        <TodoList todos={todos} />
      </div>
      <div className="pl-3 mt-5">
        {todos[0] && <TodoDetails todo={todos[0]} />}
        <TodoForm />
      </div>
    </main>
  );
}
