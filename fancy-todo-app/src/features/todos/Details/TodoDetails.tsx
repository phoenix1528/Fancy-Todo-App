import React from "react";
import sports from "../../../../src/sports.jpg";
import { ITodo } from "../../../app/models/ITodo";
import { format } from "date-fns";

interface Props {
    todo: ITodo;
}

export default function TodoDetails({todo}: Props) {
  return (
    <section className="card mt-3" style={{ width: "18rem" }}>
      <img className="card-img-top" src={sports} alt="Card image cap" />
      <div className="card-body">
        <h5 className="card-title">{todo.title}</h5>
        <p className="card-text">
        {todo.description}
        </p>
      </div>
      <ul className="list-group list-group-flush">
        <li className="list-group-item">{todo.category}</li>
        <li className="list-group-item">{todo.city}</li>
        <li className="list-group-item">{todo.venue}</li>
        <li className="list-group-item">Von {format(new Date(todo.startDate), "dd MMM yyyy HH:mm")}</li>
        <li className="list-group-item">bis {format(new Date(todo.endDate), "dd MMM yyyy HH:mm")}</li>
      </ul>
      <div className="card-body d-flex justify-content-between">
        <button className="btn btn-success">
          Edit Todo
        </button>
        <button className="btn btn-danger">
          Delete Todo
        </button>
      </div>
    </section>
  );
}
