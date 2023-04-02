export interface CreateProduct {
  name: string;
  price: number;
  description: string;
  file: File | null;
  categoryId: string;
}
