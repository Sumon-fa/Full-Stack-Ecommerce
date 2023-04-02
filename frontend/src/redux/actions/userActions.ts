import { createAsyncThunk } from '@reduxjs/toolkit';
import axios, { AxiosResponse } from 'axios';
import {
  CreateUserWithForm,
  Token,
  User,
} from '../../components/types/auth/auth';
import axiosInstance from '../../common/axiosInstance';

export const createUser = createAsyncThunk(
  'createUser',
  async (user: CreateUserWithForm, thunk) => {
    try {
      const userData: AxiosResponse<User, User> = await axiosInstance.post(
        '/api/v1/users/signup',
        user,
        {
          headers: {
            'Content-Type': 'multipart/form-data',
          },
        }
      );
      return userData.data;
    } catch (err: any) {
      return thunk.rejectWithValue({ message: err.message });
    }
  }
);

export const getAllUsers = createAsyncThunk(
  'allUser',
  async (data, thunkApi) => {
    try {
      const token: Token = JSON.parse(localStorage.getItem('token') || '');

      const response: AxiosResponse<User[], User[]> = await axiosInstance.get(
        `/api/v1/users`,
        {
          headers: {
            Authorization: `Bearer ${token}`,
          },
        }
      );

      return response.data;
    } catch (err: any) {
      return thunkApi.rejectWithValue({ message: err.message });
    }
  }
);
