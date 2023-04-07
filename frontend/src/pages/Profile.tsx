import React, { useEffect } from 'react';
import { useAppDispatch, useAppSelector } from '../hooks/reduxHook';
import { getCurrentUser } from '../redux/actions/authAction';
import { userActions } from '../redux/slices/userSlice';
import Loader from '../components/Ui/Loader';
const Profile = () => {
  const { currentUser, isLoading, isError } = useAppSelector(
    (state) => state.auth
  );
  const dispatch = useAppDispatch();

  useEffect(() => {
    if (isError) {
      alert(isError.message);
      dispatch(userActions.clearError());
    }
  }, [isError, alert]);

  useEffect(() => {
    dispatch(getCurrentUser());
  }, []);

  return (
    <>
      {isLoading && <Loader />}
      {!isLoading && !isError && currentUser && (
        <div className="profile">
          <img
            className="profile__image"
            src={currentUser.pictureUrl}
            alt={currentUser.lastName}
          />
          <div className="profile__content">
            <h3 className="profile__content__name">
              Name: {currentUser.firstName + ' ' + currentUser.lastName}
            </h3>
            <h3 className="profile__content__email">
              Email: {currentUser.email}
            </h3>
            <h3 className="profile__content__role">
              Role: {currentUser.roles[0]}
            </h3>
          </div>
        </div>
      )}
    </>
  );
};

export default Profile;
