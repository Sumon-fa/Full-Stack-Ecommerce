import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import { useAppSelector } from '../../hooks/reduxHook';

function DropDownMenu() {
  const { token, currentUser, isLoading } = useAppSelector(
    (state) => state.auth
  );
  return (
    <div className="dropdown-menu">
      <span className="dropdown-icon">
        <i className="fa-solid fa-id-card-clip"></i>
      </span>
      <div className="dropdown-items">
        {token && currentUser && currentUser.roles.includes('Admin') && (
          <>
            <Link to="/admin/dashboard">Dashboard</Link>
            <Link to="#">Orders</Link>
          </>
        )}
        {token && <Link to="/profile">Profile</Link>}
      </div>
    </div>
  );
}

export default DropDownMenu;
