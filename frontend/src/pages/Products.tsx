import React, { useEffect } from 'react';
import ProductCard from '../components/Ui/ProductCard';
import { useAppDispatch } from '../hooks/reduxHook';
import { useAppSelector } from '../hooks/reduxHook';
import { getAllProducts } from '../redux/actions/productActions';
import Loader from '../components/Ui/Loader';
import { productActions } from '../redux/slices/productSlice';

const Products = () => {
  const { products, isLoading, isError } = useAppSelector(
    (state) => state.products
  );

  return (
    <>
      <ProductCard products={products} />
    </>
  );
};

export default Products;
