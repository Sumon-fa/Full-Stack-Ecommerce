import { createAsyncThunk } from '@reduxjs/toolkit';
import { AxiosResponse } from 'axios';
import axiosInstance from '../../common/axiosInstance';
import { CurrentUser, Token } from '../../components/types/auth/auth';

export const login = createAsyncThunk(
  'login',
  async (user: { email: string; password: string }, thunk) => {
    try {
      const response: AxiosResponse<Token, Token> = await axiosInstance.post(
        '/api/v1/users/signin',
        user
      );
      return response.data;
    } catch (err: any) {
      return thunk.rejectWithValue({ message: err.message });
    }
  }
);
export const getCurrentUser = createAsyncThunk(
  'currentUser',
  async (data, thunkApi) => {
    try {
      const token: Token = JSON.parse(localStorage.getItem('token') || '');
      const response: AxiosResponse<CurrentUser, CurrentUser> =
        await axiosInstance.get('/api/v1/users/profile', {
          headers: {
            Authorization: `Bearer ${token}`,
          },
        });

      return response.data;
    } catch (err: any) {
      return thunkApi.rejectWithValue({ message: err.message });
    }
  }
);
