export interface ProductsProps {
  heading?: string;
  products: Product[];
}
export interface Product {
  name: string;
  price: number;
  pictureUrl: string;
  description: string;
  id: string;
}
