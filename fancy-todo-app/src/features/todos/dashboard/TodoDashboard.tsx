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
  editMode: boolean;
  openForm: (id: string) => void;
  closeForm: () => void;
  createTodo: (todo: ITodo) => void;
  deleteTodo: (id: string) => void;
}

export default function TodoDashboard({
  todos,
  selectedTodo,
  selectTodo,
  cancelSelectTodo,
  editMode,
  openForm,
  closeForm,
  createTodo,
  deleteTodo,
}: Props) {
  return (
    <main className="d-flex justify-content-center">
      <div className="mt-5 mb-5">
        <TodoList
          todos={todos}
          selectTodo={selectTodo}
          deleteTodo={deleteTodo}
        />
      </div>
      <div className="pl-3 mt-5">
        {selectedTodo && !editMode && (
          <TodoDetails
            todo={selectedTodo}
            openForm={openForm}
            cancelSelectTodo={cancelSelectTodo}
          />
        )}
        {editMode && (
          <TodoForm
            todo={selectedTodo}
            closeForm={closeForm}
            createTodo={createTodo}
          />
        )}
      </div>
    </main>
  );
}
