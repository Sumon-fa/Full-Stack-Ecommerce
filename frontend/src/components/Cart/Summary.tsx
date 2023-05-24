import React, { useEffect } from 'react';
import { useAppDispatch, useAppSelector } from '../../hooks/reduxHook';
import { createOrder } from '../../redux/actions/orderActions';
import { orderAction } from '../../redux/slices/orderSlice';

const Summary = () => {
  const { totalPrice, subTotal, cartItems } = useAppSelector(
    (state) => state.cart
  );
  const { isError, isLoading, isSuccess } = useAppSelector(
    (state) => state.order
  );
  const dispatch = useAppDispatch();

  useEffect(() => {
    if (isError) {
      alert(isError.message);
      dispatch(orderAction.clearError());
    }

    if (isSuccess) {
      alert('Orders created successfully');
      dispatch(orderAction.clearSuccess());
    }
  }, [isError, isSuccess]);

  function orderHandler() {
    const items = cartItems.map((c) => {
      return {
        productId: c.id,
        updatedPrice: c.updatedPrice,
        amount: c.amount,
      };
    });

    const order = {
      cartItems: items,
    };

    dispatch(createOrder(order));
  }

  return (
    <section className="summary-container">
      <div className="summary-container__summary">
        <ul>
          <li>
            Subtotal <span>${subTotal.toFixed(2)}</span>
          </li>

          <li>
            VAT<span>24%</span>
          </li>
          <li className="summary-container__summary__total">
            Total <span>${totalPrice.toFixed(2)}</span>
          </li>
        </ul>
      </div>

      <div className="summary-container__checkout">
        <button onClick={orderHandler} type="button">
          Check Out
        </button>
      </div>
    </section>
  );
};

export default Summary;
