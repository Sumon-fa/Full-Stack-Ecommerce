import { Category } from './products/category';
import { Product } from './products/product';

export interface ProductCart {
  id: string;
  name: string;
  price: number;
  pictureUrl: string;
  description: string;
  amount: number;
  updatedPrice: number;
}

export interface CartState {
  cartItems: ProductCart[];
  totalPrice: number;
  subTotal: number;
}
