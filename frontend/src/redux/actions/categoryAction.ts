import { createAsyncThunk } from '@reduxjs/toolkit';
import axios, { AxiosResponse } from 'axios';
import {
  AllCategory,
  Category,
  CreateCategory,
} from '../../components/types/products/category';
import axiosInstance from '../../common/axiosInstance';
import { Token } from '../../components/types/auth/auth';
export const getCategories = createAsyncThunk(
  'getCategories',
  async (data, thunk) => {
    try {
      const response: AxiosResponse<AllCategory, AllCategory> =
        await axiosInstance.get('/api/v1/categories');
      return response.data;
    } catch (err: any) {
      return thunk.rejectWithValue({ message: err.message });
    }
  }
);
export const createCategory = createAsyncThunk(
  'createProduct',
  async (category: CreateCategory, thunk) => {
    try {
      const token: Token = JSON.parse(localStorage.getItem('token') || '');

      const response: AxiosResponse<Category, Category> =
        await axiosInstance.post('/api/v1/categories', category, {
          headers: {
            'Content-Type': 'multipart/form-data',
            Authorization: `Bearer ${token}`,
          },
        });
      return response.data;
    } catch (err: any) {
      return thunk.rejectWithValue({ message: err.message });
    }
  }
);
