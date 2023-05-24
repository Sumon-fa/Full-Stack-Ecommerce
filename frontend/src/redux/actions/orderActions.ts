import { createAsyncThunk } from '@reduxjs/toolkit';
import axios, { AxiosResponse } from 'axios';
import axiosInstance from '../../common/axiosInstance';
import { NewOrderItems, Orders } from '../../components/types/order';
import { Token } from '../../components/types/auth/auth';

export const createOrder = createAsyncThunk(
  'createOrder',
  async (order: NewOrderItems, thunk) => {
    try {
      const token: Token = JSON.parse(localStorage.getItem('token') || '');
      const response: AxiosResponse<Orders, Orders> = await axiosInstance.post(
        '/api/v1/orders',
        order,
        {
          headers: {
            'Content-Type': 'application/json',
            Authorization: `Bearer ${token}`,
          },
        }
      );
      return response.data;
    } catch (err: any) {
      return thunk.rejectWithValue({ message: err.message });
    }
  }
);
