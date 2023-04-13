export interface Category {
  name: string;
  pictureUrl: string;
  id: string;
}

export interface AllCategory {
  result: Category[];
  itemLength: number;
}

export interface CategoryState {
  categories: Category[];
  totalCategory: number;
  isLoading: boolean;
  isError: any;
  category: Category;
  isSuccess: boolean;
}
export interface CreateCategory {
  name: string;
  file: File | null;
}
