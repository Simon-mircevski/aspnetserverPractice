import React, { useState } from "react";

export default function App() {
  const [posts, setPosts] = useState([]);

  function getPosts() {
    const url = "https://localhost:7110/get-all-posts";

    fetch(url, {
      method: "GET",
    })
      .then((response) => response.json())
      .then((posts) => {
        console.log(posts);
        setPosts(posts);
      })
      .catch((error) => {
        console.log(error);
        alert(error);
      });
  }

  return (
    <div className="container">
      <div className="row min-vh-100">
        <div className="col d-flex flex-column justify-content-center align-items-center">
          <div>
            <h1>ASP.NET Core Tutorial</h1>

            <div className="mt-5">
              <button
                onClick={getPosts}
                className="btn btn-dark btn-large w-100"
              >
                Get Posts from server
              </button>
              <button
                onClick={() => {}}
                className="btn btn-secondary btn-large w-100 mt-4"
              >
                Create New Post
              </button>
            </div>
          </div>

          {posts.length > 0 && renderPostsTable()}
        </div>
      </div>
    </div>
  );

  function renderPostsTable() {
    return (
      <div className="table-responsive mt-5">
        <table className="table table-bordered border-dark">
          <thead>
            <tr>
              <th scope="col">PostId (PK)</th>
              <th scope="col">Title</th>
              <th scope="col">Content</th>
              <th scope="col">CRUD Operations</th>
            </tr>
          </thead>
          <tbody>
            {posts.map((post) => (
              <tr key={post.postId}>
                <th scope="col">{post.postId}</th>
                <td>{post.title}</td>
                <td>{post.content}</td>
                <td>
                  <button className="btn btn-dark btn-large mx-3 my-3">
                    Update
                  </button>
                  <button className="btn btn-dark btn-large mx-3 my-3">
                    Delete
                  </button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>

        <button onClick={() => setPosts([])} className="btn btn-dark btn-large w-100">Empty React posts array </button>
      </div>
    );
  }
}
