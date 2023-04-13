import React, { useEffect } from 'react';
import ProductCard from '../components/Ui/ProductCard';
import { useAppDispatch } from '../hooks/reduxHook';
import { useAppSelector } from '../hooks/reduxHook';
import { getAllProducts } from '../redux/actions/productActions';

const Products = () => {
  const { products } = useAppSelector((state) => state.products);

  return (
    <>
      <ProductCard products={products} />
    </>
  );
};

export default Products;
