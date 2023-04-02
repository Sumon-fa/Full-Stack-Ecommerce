import React, { useEffect } from 'react';
import { useAppDispatch, useAppSelector } from '../../hooks/reduxHook';
import { userActions } from '../../redux/slices/userSlice';
import { getAllUsers } from '../../redux/actions/userActions';

const AllUsers = () => {
  const { users, isError } = useAppSelector((state) => state.user);

  const dispatch = useAppDispatch();

  useEffect(() => {
    if (isError) {
      alert(isError.message);
      dispatch(userActions.clearError());
    }
    dispatch(getAllUsers());
  }, [isError, dispatch]);

  return (
    <div className="all-users">
      <table>
        <thead>
          <tr>
            <th>ID</th>
            <th>Name</th>
            <th>Email</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {users &&
            users.map((user) => (
              <tr key={user.id}>
                <td>{user.id}</td>
                <td>{`${user.firstName} ${user.lastName}`}</td>
                <td>{user.email}</td>
                <td>
                  <button>
                    <i className="fa fa-edit"></i>
                  </button>
                  <button>
                    <i className="fa fa-trash"></i>
                  </button>
                </td>
              </tr>
            ))}
        </tbody>
      </table>
    </div>
  );
};

export default AllUsers;
