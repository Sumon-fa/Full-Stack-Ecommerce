import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import {
  GetAllProducts,
  Product,
} from '../../components/types/products/product';
import { ProductState } from '../../components/types/products/productState';
import {
  createProduct,
  getAllProducts,
  getProductsByCategoryId,
} from '../actions/productActions';

const initialState: ProductState = {
  products: [],
  totalProducts: 0,
  product: {
    name: '',
    price: 0,
    description: '',
    pictureUrl: '',
    id: '',
  },
  isLoading: false,
  isError: null,
  isSuccess: false,
};

const productSlice = createSlice({
  name: 'allProduct',
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
      getAllProducts.fulfilled,
      (state, action: PayloadAction<GetAllProducts>) => {
        if (!action.payload) {
          return state;
        }
        state.products = action.payload.result;
        state.totalProducts = action.payload.itemLength;
        state.isLoading = false;
        state.isError = null;
        return state;
      }
    );
    build.addCase(
      getAllProducts.rejected,
      (state, action: PayloadAction<any>) => {
        state.isError = action.payload;
        state.isLoading = false;
      }
    );
    build.addCase(getAllProducts.pending, (state, action) => {
      state.isLoading = true;
      state.isError = null;
    });
    build.addCase(
      createProduct.fulfilled,
      (state, action: PayloadAction<Product>) => {
        if (!action.payload) {
          return state;
        }
        state.product = action.payload;
        state.isLoading = false;
        state.isError = null;
        state.isSuccess = true;
        return state;
      }
    );
    build.addCase(
      createProduct.rejected,
      (state, action: PayloadAction<any>) => {
        state.isError = action.payload;
        state.isLoading = false;
        state.isSuccess = false;
      }
    );
    build.addCase(createProduct.pending, (state, action) => {
      state.isLoading = true;
      state.isError = null;
      state.isSuccess = false;
    });
    build.addCase(
      getProductsByCategoryId.fulfilled,
      (state, action: PayloadAction<GetAllProducts>) => {
        if (!action.payload) {
          return state;
        }
        state.products = action.payload.result;
        state.totalProducts = action.payload.itemLength;
        state.isLoading = false;
        state.isError = null;
        return state;
      }
    );
    build.addCase(
      getProductsByCategoryId.rejected,
      (state, action: PayloadAction<any>) => {
        state.isError = action.payload;
        state.isLoading = false;
      }
    );
    build.addCase(getProductsByCategoryId.pending, (state, action) => {
      state.isLoading = true;
      state.isError = null;
    });
  },
});
export const productActions = productSlice.actions;

export default productSlice;
