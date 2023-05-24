export interface NewOrderItems {
  cartItems: Items[];
}

interface Items {
  productId: string;
  updatedPrice: number;
  amount: number;
}

export interface Orders {
  cartItems: Items[];

  customer: string;
  status: string;
  id: string;
}

export interface OrderState {
  isLoading: boolean;
  isError: any;
  myOrders: Orders | null;
  isSuccess: boolean;
}
