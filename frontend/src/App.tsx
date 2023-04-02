import React, { useEffect } from 'react';
import { Route, Routes } from 'react-router-dom';
import ProtectedRoute from './components/Routes/ProtectedRoute';

import { useAppDispatch, useAppSelector } from './hooks/reduxHook';
import { getCurrentUser } from './redux/actions/authAction';

import Header from './components/Header/Header';
import Footer from './components/Footer/Footer';

import Home from './pages/Home';
import Products from './pages/Products';
import ProductDetails from './pages/ProductDetails';
import NotFound from './pages/NotFound';
import CategorizedProducts from './pages/CategorizedProducts';
import Profile from './pages/Profile';
import CartPage from './pages/CartPage';
import NewProduct from './pages/admin/NewProduct';
import Dashboard from './pages/admin/Dashboard';
import AllProducts from './pages/admin/AllProducts';
import AllUsers from './pages/admin/AllUsers';

const App = () => {
  const { token } = useAppSelector((state) => state.auth);
  const dispatch = useAppDispatch();
  useEffect(() => {
    if (token) {
      dispatch(getCurrentUser());
    }
  }, [token]);
  return (
    <>
      <header>
        <Header />
      </header>

      <main>
        <Routes>
          <Route path="/" element={<Home />} />

          <Route path="/products" element={<Products />} />
          {token && <Route path="/admin/dashboard" element={<Dashboard />} />}
          {token && (
            <Route path="/admin/product/create" element={<NewProduct />} />
          )}

          <Route path="/product/:id" element={<ProductDetails />} />

          <Route
            path="/category/:id/products"
            element={<CategorizedProducts />}
          />
          <Route path="/product/cart" element={<CartPage />} />

          <Route
            path="/profile"
            element={
              <ProtectedRoute>
                <Profile />
              </ProtectedRoute>
            }
          />

          {/*Admin*/}
          <Route
            path="/admin/dashboard"
            element={
              <ProtectedRoute>
                <Dashboard />
              </ProtectedRoute>
            }
          />

          <Route
            path="/admin/product/create"
            element={
              <ProtectedRoute>
                <NewProduct />
              </ProtectedRoute>
            }
          />

          <Route
            path="/admin/products"
            element={
              <ProtectedRoute>
                <AllProducts />
              </ProtectedRoute>
            }
          />
          <Route
            path="/admin/users"
            element={
              <ProtectedRoute>
                <AllUsers />
              </ProtectedRoute>
            }
          />

          <Route path="*" element={<NotFound />}></Route>
        </Routes>
      </main>

      <Footer />
    </>
  );
};

export default App;
