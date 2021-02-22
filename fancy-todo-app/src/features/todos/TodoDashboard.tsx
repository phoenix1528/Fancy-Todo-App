import React from 'react';
import { ITodo } from '../../app/models/ITodo';

interface Props {
    todos: ITodo[];
}

export default function TodoDashboard({todos}: Props) {
    return (
        <ul>
          {todos.map((todo) => {
            return (
              <li key={todo.id}>
                <span>{todo.title}</span>
                <br />
                <span>{todo.category}</span>
                <br />
                <span>{todo.city}</span>
                <br />
                <span>{todo.description}</span>
                <br />
                <span>{todo.startDate}</span>
                <br />
                <span>{todo.endDate}</span>
                <br />
                <span>{todo.venue}</span>
              </li>
            );
          })}
        </ul>
    );
}