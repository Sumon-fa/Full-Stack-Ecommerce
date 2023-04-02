import React, { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { useAppDispatch, useAppSelector } from '../../hooks/reduxHook';
import { cartActions } from '../../redux/slices/cartSlice';
import { ProductCart } from '../types/cartState';

const ProductCartItems = () => {
  const { cartItems } = useAppSelector((state) => state.cart);
  const [amount, setAmount] = useState(0);
  const [items, setItems] = useState<ProductCart>();

  const navigate = useNavigate();
  const dispatch = useAppDispatch();

  const changeHandler = (
    item: ProductCart,
    e: React.ChangeEvent<HTMLInputElement>
  ) => {
    let value = parseInt(e.target.value);
    if (value && value > 0) {
      setAmount(value);
      setItems(item);
    } else if (value < 1) {
      alert('Please enter a value greater than 0');
    }
  };

  useEffect(() => {
    if (items && amount > 0) {
      const cart = {
        ...items,
        amount: amount,
      };

      dispatch(cartActions.changeQty(cart));
    }
  }, [amount, items]);

  const removeHandler = (id: string) => {
    dispatch(cartActions.removeCartItem(id));
  };

  const navigateHandler = (id: string) => {
    navigate(`/product/${id}`);
  };

  return (
    <>
      {cartItems &&
        cartItems.map((item) => (
          <section className="product-cart" key={item.id}>
            <ul className="product-cart__products">
              <li className="product-cart__products__row">
                <div className="col left">
                  <div className="thumbnail">
                    <a href="#" onClick={() => navigateHandler(item.id)}>
                      <img src={item.pictureUrl} alt={item.name} />
                    </a>
                  </div>
                  <div className="detail">
                    <div
                      className="name"
                      onClick={() => navigateHandler(item.id)}
                    >
                      <a href="#">{item.name}</a>
                    </div>
                    <div className="description">{item.description}</div>
                    <div className="price">${item.price.toFixed(2)}/per</div>
                    <div className="price">${item.updatedPrice}</div>
                  </div>
                </div>

                <div className="col right">
                  <div className="quantity">
                    <input
                      type="number"
                      className="quantity"
                      step="1"
                      min={1}
                      defaultValue={item.amount}
                      onChange={(e) => changeHandler(item, e)}
                    />
                  </div>

                  <div
                    className="remove"
                    onClick={() => removeHandler(item.id)}
                  >
                    <svg
                      version="1.1"
                      className="close"
                      x="0px"
                      y="0px"
                      viewBox="0 0 60 60"
                      enableBackground="new 0 0 60 60"
                    >
                      <polygon points="38.936,23.561 36.814,21.439 30.562,27.691 24.311,21.439 22.189,23.561 28.441,29.812 22.189,36.064 24.311,38.186 30.562,31.934 36.814,38.186 38.936,36.064 32.684,29.812" />
                    </svg>
                  </div>
                </div>
              </li>
            </ul>
          </section>
        ))}
    </>
  );
};

export default ProductCartItems;
