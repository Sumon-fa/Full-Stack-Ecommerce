export interface Category {
  name: string;
  pictureUrl: string;
  id: string;
}

export interface AllCategory {
  result: Category[];
  itemLength: number;
}
