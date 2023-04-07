import React, { useEffect } from 'react';
import ProductCard from '../Ui/ProductCard';

import Loader from '../Ui/Loader';

import { useAppSelector } from '../../hooks/reduxHook';

const FeaturedProducts = () => {
  const { products, isLoading, isError } = useAppSelector(
    (state) => state.products
  );

  return (
    <>
      <ProductCard
        heading="Featured Products"
        products={products.slice(0, 4)}
      />
    </>
  );
};

export default FeaturedProducts;
