import React, { useEffect, useState } from 'react';
import { useAppDispatch, useAppSelector } from '../../hooks/reduxHook';
import { createUser } from '../../redux/actions/userActions';
import { userActions } from '../../redux/slices/userSlice';
import Button from '../Ui/Button';
import { useNavigate } from 'react-router-dom';

const SignupForm = ({ hideSignup }: any) => {
  const [firstName, setFirstName] = useState('');
  const [lastName, setLastName] = useState('');
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [file, setAvatar] = useState<File | null>(null);

  const { isError, isSuccess } = useAppSelector((state) => state.user);
  const dispatch = useAppDispatch();

  const onChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    if (e.target.files) {
      setAvatar(e.target.files[0]);
    }
  };

  useEffect(() => {
    if (isError) {
      alert(isError.message);
      dispatch(userActions.clearError());
    }
    if (isSuccess) {
      alert('User Created Successfully.');
      dispatch(userActions.clearSuccess());
    }
  }, [isError, isSuccess]);

  const onSubmit = (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    const user = {
      firstName,
      lastName,
      email,
      password,
      file,
    };
    dispatch(createUser(user));
  };

  return (
    <>
      <form
        onSubmit={(e) => onSubmit(e)}
        className="signup-form"
        autoComplete="off"
      >
        <div className="signup-form__textfield">
          <label htmlFor="firstName">First NAME*</label>
          <br />
          <input
            type="text"
            id="firstname"
            name="firstName"
            placeholder="Your First Name"
            value={firstName}
            onChange={(e) => setFirstName(e.target.value)}
            required
          />
        </div>
        <div className="signup-form__textfield">
          <label htmlFor="lastName">Last NAME*</label>
          <br />
          <input
            type="text"
            id="lastName"
            name="lastName"
            placeholder="Your Last Name"
            value={lastName}
            onChange={(e) => setLastName(e.target.value)}
            required
          />
        </div>

        <div className="signup-form__textfield">
          <label htmlFor="email">EMAIL*</label>
          <br />
          <input
            type="email"
            id="email"
            name="email"
            placeholder="Your Email Adress"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
            required
          />
        </div>
        <div className="signup-form__textfield">
          <label htmlFor="password">PASSWORD*</label>
          <br />
          <input
            type="password"
            id="password"
            name="password"
            placeholder="••••••"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            required
          />
        </div>
        <div className="signup-form__textfield">
          <label htmlFor="password">AVATAR*</label>
          <br />
          <input
            type="file"
            name="file"
            id="file"
            accept="iamges/*"
            onChange={(e) => onChange(e)}
          />
        </div>

        <Button type="submit">SIGN UP NOW</Button>
      </form>
      <div className="return-login">
        <span onClick={hideSignup}>RETURN TO LOGIN</span>
      </div>
    </>
  );
};

export default SignupForm;
