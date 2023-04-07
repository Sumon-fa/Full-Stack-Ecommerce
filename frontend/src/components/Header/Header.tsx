import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import logo from '../../assets/Shopping-logos_black.png';

import DropDownCategory from './DropDownCategory';
import TopHeader from './TopHeader';
import BottomHeader from './BottomHeader';

import Drawer from '../Drawer/Drawer';
import Search from '../Search/Search';

import { useAppSelector } from '../../hooks/reduxHook';

const Header = () => {
  const [toogle, setToogle] = useState(false);
  const [searchToogle, setSearchToogle] = useState(false);
  const { token } = useAppSelector((state) => state.auth);

  const toogleDrawer = () => {
    setToogle(!toogle);
  };

  const toogleSearch = () => {
    setSearchToogle(!searchToogle);
  };

  return (
    <>
      <div className="top-header">
        <div className="top-header__logo">
          <h1>
            <Link to="/">
              <img src={logo} alt="website logo name  Shopping" />
            </Link>
          </h1>
        </div>
        <TopHeader onToogle={toogleDrawer} />
      </div>
      <div className="bottom-header">
        <nav className="bottom-header__nav-bar">
          <BottomHeader />
          <DropDownCategory />
        </nav>
      </div>
      {toogle && !token && <Drawer onToogle={toogleDrawer} />}
    </>
  );
};

export default Header;
