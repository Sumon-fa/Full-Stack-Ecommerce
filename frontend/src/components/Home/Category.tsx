import React from 'react';
import { useNavigate } from 'react-router-dom';
import { useAppSelector } from '../../hooks/reduxHook';

const Category = () => {
  const { categories } = useAppSelector((state) => state.categories);
  const navigate = useNavigate();
  const categoryByProductHandler = (id: string) => {
    navigate(`category/${id}/products`);
  };
  return (
    <section className="category" id="category">
      {categories.map((cate) => (
        <div
          key={cate.id}
          onClick={() => categoryByProductHandler(cate.id)}
          className="category__card-item"
          style={{ backgroundImage: `url(${cate.pictureUrl})` }}
        >
          <div className="category__card-item__label">{cate.name}</div>
        </div>
      ))}
    </section>
  );
};

export default Category;
