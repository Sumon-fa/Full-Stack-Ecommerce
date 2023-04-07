import { CreateProduct } from './createProduct';
import { Product } from './product';

export interface ProductState {
  products: Product[];
  totalProducts: number;
  isLoading: boolean;
  isError: any;
  product: Product;
  isSuccess: boolean;
}

export interface ProductDetailsState {
  product: Product | null;

  isLoading: boolean;
  isError: any;
}
