import React from 'react';
import { Navigate } from 'react-router-dom';
import { useAppSelector } from '../../hooks/reduxHook';

interface Role {
  children: JSX.Element;
  isAdmin: boolean;
}

const ProtectedRoute = ({ children, isAdmin }: Role) => {
  const { token, currentUser, isLoading } = useAppSelector(
    (state) => state.auth
  );

  if (token && !isAdmin) {
    return children;
  }
  if (isAdmin && currentUser && currentUser.roles.includes('Admin')) {
    return children;
  }

  return <Navigate to="/" replace />;
};
export default ProtectedRoute;
