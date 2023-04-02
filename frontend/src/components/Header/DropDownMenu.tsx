import React, { useState } from 'react';
import { Link } from 'react-router-dom';

function DropDownMenu() {
  return (
    <div className="dropdown-menu">
      <span className="dropdown-icon">
        <i className="fa-solid fa-id-card-clip"></i>
      </span>
      <div className="dropdown-items">
        <Link to="/admin/dashboard">Dashboard</Link>
        <Link to="#">Orders</Link>
        <Link to="/profile">Profile</Link>
      </div>
    </div>
  );
}

export default DropDownMenu;
