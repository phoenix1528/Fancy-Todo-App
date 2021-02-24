import React from "react";

function TodoForm() {
  return (
    <section className="card mt-3">
      <form className="card-body">
        <div>
          <h5 className="card-title">Edit Todo</h5>
        </div>
        <div className="form-row">
          <div className="form-group col-md-6">
            <label htmlFor="title">Title</label>
            <input
              type="text"
              className="form-control"
              id="title"
              placeholder="My Todo"
            />
          </div>
          <div className="form-group col-md-6">
            <label htmlFor="description">Description</label>
            <input
              type="text"
              className="form-control"
              id="description"
              placeholder="Todo description"
            />
          </div>
        </div>
        <div className="form-group">
          <label htmlFor="category">Category</label>
          <input
            type="text"
            className="form-control"
            id="category"
            placeholder="Sports Activity"
          />
        </div>
        <div className="form-group">
          <label htmlFor="startDate">Start Date</label>
          <input type="date" className="form-control" id="startDate" />
        </div>
        <div className="form-group">
          <label htmlFor="endDate">End Date</label>
          <input type="date" className="form-control" id="endDate" />
        </div>
        <div className="form-row">
          <div className="form-group col-md-6">
            <label htmlFor="city">City</label>
            <input type="text" className="form-control" id="city" />
          </div>
          <div className="form-group col-md-4">
            <label htmlFor="venue">Venue</label>
            <input
              type="text"
              id="venue"
              className="form-control"
              placeholder="Forest"
            />
          </div>
        </div>
        <div className="d-flex justify-content-between">
          <button type="submit" className="btn btn-danger">
            Cancel
          </button>
          <button type="button" className="btn btn-primary">
            Submit
          </button>
        </div>
      </form>
    </section>
  );
}

export default TodoForm;
