import { createAsyncThunk } from '@reduxjs/toolkit';
import axios, { AxiosResponse } from 'axios';
import {
  GetAllProducts,
  Product,
} from '../../components/types/products/product';
import { CreateProduct } from '../../components/types/products/createProduct';
import { Token } from '../../components/types/auth/auth';
import axiosInstance from '../../common/axiosInstance';

export const getAllProducts = createAsyncThunk(
  'getAllProducts',
  async (filter: { title: string; pageNumber: number }, thunkApi) => {
    try {
      console.log(filter.pageNumber);
      const pageSize = 8;
      let link = `/api/v1/products?page=${filter.pageNumber}&pageSize=${pageSize}&searchKeyWord=${filter.title}`;

      const response: AxiosResponse<GetAllProducts, GetAllProducts> =
        await axiosInstance.get(link);

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
      const response: AxiosResponse<GetAllProducts, GetAllProducts> =
        await axiosInstance.get(`/api/v1/categories/${id}/products`);
      return response.data;
    } catch (err: any) {
      return thunkApi.rejectWithValue({ message: err.message });
    }
  }
);

export const createProduct = createAsyncThunk(
  'createProduct',
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
