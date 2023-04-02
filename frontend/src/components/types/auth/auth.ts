export interface User {
  firstName: string;
  lastName: string;
  email: string;
  pictureUrl: string;
  id: number;
}

export interface UserState {
  user: User | {};
  isLoading: boolean;
  isError: any;
  isSuccess: boolean;
  users: User[];
}
export interface CreateUserWithForm {
  firstName: string;
  lastName: string;
  email: string;
  password: string;
  file: File | null;
}

export interface Image {
  originalname: string;
  filename: string;
  location: string;
}
export interface Token {
  token: string;
}

export interface AuthState {
  token: string;
  isLoading: boolean;
  isError: any;
  isSuccess: boolean;
  currentUser: CurrentUser | '';
}
export interface CurrentUser {
  firstName: string;
  lastName: string;
  email: string;
  pictureUrl: string;
  id: number;
  role: string[];
}
