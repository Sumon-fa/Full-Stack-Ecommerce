import React, { useEffect, useState } from 'react';
import { useAppDispatch, useAppSelector } from '../../hooks/reduxHook';
import { productActions } from '../../redux/slices/productSlice';
import { getAllProducts } from '../../redux/actions/productActions';

const AllProducts = () => {
  const { products, isError } = useAppSelector((state) => state.products);

  const dispatch = useAppDispatch();

  /* useEffect(() => {
    if (isError) {
      alert(isError.message);
      dispatch(productActions.clearError());
    }
    dispatch(getAllProducts());
  }, [isError, dispatch]);*/

  return (
    <div className="all-products">
      <table>
        <thead>
          <tr>
            <th>ID</th>
            <th>Name</th>
            <th>Price</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {products &&
            products.map((product) => (
              <tr key={product.id}>
                <td>{product.id}</td>
                <td>{product.name}</td>
                <td>${product.price}</td>
                <td>
                  <button>
                    <i className="fa fa-edit"></i>
                  </button>
                  <button>
                    <i className="fa fa-trash"></i>
                  </button>
                </td>
              </tr>
            ))}
        </tbody>
      </table>
    </div>
  );
};

export default AllProducts;
