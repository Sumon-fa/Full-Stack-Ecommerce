import React, { useEffect, useState } from 'react';

import { ProductsProps } from '../types/products/product';
import ReactPaginate from 'react-paginate';
import { Link, useLocation } from 'react-router-dom';
import { useAppDispatch, useAppSelector } from '../../hooks/reduxHook';
import { productActions } from '../../redux/slices/productSlice';
import { getAllProducts } from '../../redux/actions/productActions';
import Search from '../Search/Search';

const ProductCard = ({ heading, products }: ProductsProps) => {
  const location = useLocation();
  const [searchToogle, setSearchToogle] = useState(false);

  const [pageNumber, setPageNumber] = useState(0);
  const productPerPage = 8;
  const { isError, totalProducts } = useAppSelector((state) => state.products);
  const dispatch = useAppDispatch();

  const toogleSearch = () => {
    setSearchToogle(!searchToogle);
  };

  useEffect(() => {
    if (isError) {
      alert(isError.message);
      dispatch(productActions.clearError());
    }
    const filter = {
      title: '',
      pageNumber: pageNumber + 1,
    };
    dispatch(getAllProducts(filter));
  }, [isError, dispatch, pageNumber]);

  const displayProducts =
    products &&
    products.map((product) => (
      <Link to={`/product/${product.id}`} key={product.id}>
        <div className="feature-product__item">
          <img src={product.pictureUrl} alt="" />
          <div className="feature-product__item__label">
            <h4 className="feature-product__item__label__heading">
              {product.name}
            </h4>
            <span>${product.price}</span>
          </div>
        </div>
      </Link>
    ));
  const pageCount = Math.ceil(totalProducts / productPerPage);
  const changePage = ({ selected }: { selected: number }) => {
    setPageNumber(selected);
  };
  return (
    <section className="feature">
      <h1>{heading}</h1>
      {location.pathname === '/' ? (
        <>
          <div className="feature-product">{displayProducts}</div>
        </>
      ) : (
        <>
          <div className="bottom-header__search" onClick={toogleSearch}>
            SEARCH <i className="fa-solid fa-magnifying-glass"></i>
          </div>
          {searchToogle && (
            <Search
              onToogleSearch={toogleSearch}
              setSearchToogle={setSearchToogle}
              pageNumber={pageNumber}
            />
          )}
          <div className="feature-product">{displayProducts}</div>
          <ReactPaginate
            previousLabel={'prev'}
            nextLabel={'next'}
            pageCount={pageCount}
            onPageChange={changePage}
            containerClassName={'paginationBttns'}
            previousLinkClassName={'previousBttn'}
            nextLinkClassName={'nextBttn'}
            disabledClassName={'paginationDisabled'}
            activeClassName={'paginationActive'}
          />
        </>
      )}
    </section>
  );
};

export default ProductCard;
