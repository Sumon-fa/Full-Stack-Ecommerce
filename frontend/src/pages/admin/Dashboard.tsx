import React from 'react';
import { Link } from 'react-router-dom';

const Dashboard = () => {
  return (
    <div className="dashboard">
      <div className="sidebar">
        <ul>
          <li>
            <Link to="/admin/products">Products</Link>
          </li>
          <li>
            <Link to="/admin/product/create">Create Product</Link>
          </li>
          <li>
            <Link to="/admin/users">Users</Link>
          </li>
        </ul>
      </div>
      <div className="content">
        <h1>Welcome to the Dashboard!</h1>
        <p>Use the links in the sidebar to navigate.</p>
      </div>
    </div>
  );
};

export default Dashboard;
