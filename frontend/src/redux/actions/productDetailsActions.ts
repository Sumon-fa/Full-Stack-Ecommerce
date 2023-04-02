import { createAsyncThunk } from '@reduxjs/toolkit';
import { AxiosResponse } from 'axios';
import { Product } from '../../components/types/products/product';
import axiosInstance from '../../common/axiosInstance';

export const getSingleProducts = createAsyncThunk(
  'getSingleProduct',
  async (id: string, thunk) => {
    try {
      const response: AxiosResponse<Product, Product> = await axiosInstance.get(
        `/api/v1/products/${id}`
      );
      return response.data;
    } catch (err: any) {
      return thunk.rejectWithValue({ message: err.message });
    }
  }
);
