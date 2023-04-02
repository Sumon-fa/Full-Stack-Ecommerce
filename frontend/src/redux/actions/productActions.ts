import { createAsyncThunk } from '@reduxjs/toolkit';
import axios, { AxiosResponse } from 'axios';
import axiosInstance from '../../common/axiosInstance';
import { Product } from '../../components/types/products/product';
import { CreateProduct } from '../../components/types/products/createProduct';
import { Token } from '../../components/types/auth/auth';

export const getAllProducts = createAsyncThunk(
  'getAllProducts',
  async (title: string | undefined, thunkApi) => {
    try {
      let link = 'https://shopping-backend.azurewebsites.net/api/v1/products';

      if (title) {
        link = `https://shopping-backend.azurewebsites.net/api/v1/products?searchKeyWord=${title}`;
      }
      const response: AxiosResponse<Product[], Product[]> = await axios.get(
        link
      );

      return response.data;
    } catch (err: any) {
      return thunkApi.rejectWithValue({ message: err.message });
    }
  }
);

export const getProductsByCategoryId = createAsyncThunk(
  'getProductsByCategoryId',
  async (id: string, thunkApi) => {
    try {
      const response: AxiosResponse<Product[], Product[]> =
        await axiosInstance.get(`/api/v1/categories/${id}/products`);
      return response.data;
    } catch (err: any) {
      return thunkApi.rejectWithValue({ message: err.message });
    }
  }
);

export const createProduct = createAsyncThunk(
  'createUser',
  async (product: CreateProduct, thunk) => {
    try {
      const token: Token = JSON.parse(localStorage.getItem('token') || '');

      const response: AxiosResponse<Product, Product> =
        await axiosInstance.post('/api/v1/products', product, {
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
