import { createAsyncThunk } from '@reduxjs/toolkit';
import { AxiosResponse } from 'axios';
import axiosInstance from '../../common/axiosInstance';
import { Category } from '../../components/types/products/category';

export const getCategories = createAsyncThunk(
  'getCategories',
  async (data, thunk) => {
    try {
      const response: AxiosResponse<Category[], Category[]> =
        await axiosInstance.get('/api/v1/categories');
      return response.data;
    } catch (err: any) {
      return thunk.rejectWithValue({ message: err.message });
    }
  }
);
