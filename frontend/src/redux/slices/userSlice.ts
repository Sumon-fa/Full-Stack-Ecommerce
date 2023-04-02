import { createSlice, PayloadAction } from '@reduxjs/toolkit';
import { User, UserState } from '../../components/types/auth/auth';
import { createUser, getAllUsers } from '../actions/userActions';

const initialState: UserState = {
  user: {},
  isLoading: false,
  isError: null,
  isSuccess: false,
  users: [],
};

const userSlice = createSlice({
  name: 'user',
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
      createUser.fulfilled,
      (state, action: PayloadAction<User>) => {
        if (!action.payload) {
          return state;
        }
        if ('message' in action.payload) {
          state.isError = action.payload;
          console.log(state.isError);
          return state;
        }
        state.user = action.payload;
        state.isLoading = false;
        state.isError = null;
        state.isSuccess = true;

        return state;
      }
    );
    build.addCase(createUser.rejected, (state, action: PayloadAction<any>) => {
      state.isError = action.payload;
      state.isLoading = false;
      state.isSuccess = false;
    });
    build.addCase(createUser.pending, (state, action) => {
      state.isLoading = true;
      state.isError = null;
      state.isSuccess = false;
    });

    build.addCase(
      getAllUsers.fulfilled,
      (state, action: PayloadAction<User[]>) => {
        if (!action.payload) {
          return state;
        }
        state.isSuccess = true;
        state.users = action.payload;
        state.isLoading = false;
        state.isError = null;

        return state;
      }
    );
    build.addCase(getAllUsers.rejected, (state, action: PayloadAction<any>) => {
      state.isError = action.payload;
      state.users = [];
      state.isLoading = false;
    });
    build.addCase(getAllUsers.pending, (state, action) => {
      state.isLoading = true;
      state.isError = null;
    });
  },
});
export const userActions = userSlice.actions;

export default userSlice;
