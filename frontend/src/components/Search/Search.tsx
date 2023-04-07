import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';

import { useAppDispatch } from '../../hooks/reduxHook';
import { getAllProducts } from '../../redux/actions/productActions';

import { SearchProps } from '../types/header/search';
import SearchModal from '../Ui/SearchModal';

const Search = ({
  onToogleSearch,
  setSearchToogle,
  pageNumber,
}: SearchProps) => {
  const [title, setTitle] = useState('');
  const dispatch = useAppDispatch();

  const searchByTitleHandler = () => {
    const filter = {
      title,
      pageNumber: pageNumber + 1,
    };
    dispatch(getAllProducts(filter));
    setSearchToogle(false);
    setTitle('');
  };
  const searchByEnterKey = (e: React.KeyboardEvent<HTMLInputElement>) => {
    const filter = {
      title,
      pageNumber: pageNumber + 1,
    };
    if (e.key === 'Enter') {
      dispatch(getAllProducts(filter));
      setSearchToogle(false);
      setTitle('');
    }
  };
  return (
    <SearchModal onToogleSearch={onToogleSearch}>
      <input
        onKeyPress={(e) => searchByEnterKey(e)}
        type="text"
        aria-label="search"
        placeholder="Search products..."
        onChange={(e) => {
          setTitle(e.target.value);
        }}
      />
      <i
        className="fa-solid fa-magnifying-glass"
        onClick={searchByTitleHandler}
      ></i>
    </SearchModal>
  );
};

export default Search;
