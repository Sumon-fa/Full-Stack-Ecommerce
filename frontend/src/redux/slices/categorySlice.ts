import { PayloadAction, createSlice } from '@reduxjs/toolkit';
import {
  Category,
  CategoryState,
} from '../../components/types/products/category';
import { createCategory, getCategories } from '../actions/categoryAction';

const initialState: CategoryState = {
  categories: [],
  totalCategory: 0,
  category: {
    name: '',
    pictureUrl: '',
    id: '',
  },
  isLoading: false,
  isError: null,
  isSuccess: false,
};

const categorySlice = createSlice({
  name: 'category',
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
    build.addCase(getCategories.fulfilled, (state, action) => {
      if (!action.payload) {
        return state;
      }
      state.categories = action.payload.result;
      state.totalCategory = action.payload.itemLength;
      state.isLoading = false;
      state.isError = null;
      return state;
    });
    build.addCase(getCategories.rejected, (state, action) => {
      state.isError = action.payload;
      state.isLoading = false;
    });
    build.addCase(getCategories.pending, (state, action) => {
      state.isLoading = true;
      state.isError = null;
    });

    build.addCase(
      createCategory.fulfilled,
      (state, action: PayloadAction<Category>) => {
        if (!action.payload) {
          return state;
        }
        state.category = action.payload;
        state.isLoading = false;
        state.isError = null;
        state.isSuccess = true;
        return state;
      }
    );

    build.addCase(
      createCategory.rejected,
      (state, action: PayloadAction<any>) => {
        state.isError = action.payload;
        state.isLoading = false;
        state.isSuccess = false;
      }
    );
    build.addCase(createCategory.pending, (state, action) => {
      state.isLoading = true;
      state.isError = null;
      state.isSuccess = false;
    });
  },
});
export const categoryActions = categorySlice.actions;

export default categorySlice;
