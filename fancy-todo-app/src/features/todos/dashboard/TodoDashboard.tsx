import React from "react";
import { ITodo } from "../../../app/models/ITodo";
import TodoDetails from "../details/TodoDetails";
import TodoForm from "../form/TodoForm";
import TodoList from "./TodoList";

interface Props {
  todos: ITodo[];
  selectedTodo: ITodo | undefined;
  selectTodo: (id: string) => void;
  cancelSelectTodo: () => void;
}

export default function TodoDashboard({
  todos,
  selectedTodo,
  selectTodo,
  cancelSelectTodo,
}: Props) {
  return (
    <main className="d-flex justify-content-center">
      <div className="mt-5">
        <TodoList
          todos={todos}
          selectTodo={selectTodo}
          cancelSelectTodo={cancelSelectTodo}
        />
      </div>
      <div className="pl-3 mt-5">
        {selectedTodo && <TodoDetails todo={selectedTodo} />}
        <TodoForm />
      </div>
    </main>
  );
}
