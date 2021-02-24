import React from "react";
import { ITodo } from "../../../app/models/ITodo";
import sports from "../../../../src/sports.jpg";
import { format } from "date-fns";

interface Props {
  todos: ITodo[];
  selectTodo: (id: string) => void;
  cancelSelectTodo: () => void;
}

export default function TodoList({
  todos,
  selectTodo,
  cancelSelectTodo,
}: Props) {
  return (
    <section>
      {todos.map((todo) => (
        <div className="card mt-3" key={todo.id}>
          <div className="card-body">
            <h5 className="card-title">{todo.title}</h5>
            <p className="card-text">{todo.description}</p>
            <p className="card-text">
              <small className="text-muted">
                Von {format(new Date(todo.startDate), "dd MMM yyyy HH:mm")} bis{" "}
                {format(new Date(todo.endDate), "dd MMM yyyy HH:mm")}
              </small>
            </p>
            <div className="d-flex justify-content-between">
              <button
                className="btn btn-danger"
                onClick={() => cancelSelectTodo()}
              >
                Cancel
              </button>
              <button
                className="btn btn-primary"
                onClick={() => selectTodo(todo.id)}
              >
                Details
              </button>
            </div>
          </div>
          <img
            className="card-img-bottom"
            src={sports}
            style={{ color: "blue", height: "200px", width: "auto" }}
            alt="Card image cap"
          />
        </div>
      ))}
    </section>
  );
}
