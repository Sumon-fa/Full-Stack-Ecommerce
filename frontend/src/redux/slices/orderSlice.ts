import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { Product } from '../../components/types/products/product';
import { ProductDetailsState } from '../../components/types/products/productState';
import { getSingleProducts } from '../actions/productDetailsActions';
import { Orders, OrderState } from '../../components/types/order';
import { createOrder } from '../actions/orderActions';

const initialState: OrderState = {
  myOrders: null,
  isLoading: false,
  isError: null,
  isSuccess: false,
};

const orderSlice = createSlice({
  name: 'orders',
  initialState: initialState,
  reducers: {
    clearError(state) {
      state.isError = null;
    },
    clearSuccess(state) {
      state.isSuccess = false;
    },
  },
  extraReducers: (build) => {
    build.addCase(
      createOrder.fulfilled,
      (state, action: PayloadAction<Orders>) => {
        if (!action.payload) {
          return state;
        }
        if ('message' in action.payload) {
          state.isError = action.payload;
          state.isLoading = false;
          return state;
        }
        state.myOrders = action.payload;
        state.isLoading = false;
        state.isError = null;
        state.isSuccess = true;
        return state;
      }
    );
    build.addCase(createOrder.rejected, (state, action: PayloadAction<any>) => {
      state.isError = action.payload;
      state.isLoading = false;
      state.isSuccess = false;
    });
    build.addCase(createOrder.pending, (state, action) => {
      state.isLoading = true;
      state.isError = null;
      state.isSuccess = false;
    });
  },
});
export const orderAction = orderSlice.actions;

export default orderSlice;
