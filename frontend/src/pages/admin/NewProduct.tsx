import React, { useEffect, useState } from 'react';
import { useAppDispatch, useAppSelector } from '../../hooks/reduxHook';
import { productActions } from '../../redux/slices/productSlice';
import { createProduct } from '../../redux/actions/productActions';
import { useNavigate } from 'react-router-dom';

const NewProduct = () => {
  const [name, setName] = useState('');
  const [description, setDescription] = useState('');
  const [file, setFile] = useState<File | null>(null);
  const [categoryId, setCategoryId] = useState('');
  const [price, setPrice] = useState(0);

  const dispatch = useAppDispatch();
  const navigate = useNavigate();
  const { categories } = useAppSelector((state) => state.categories);
  const { isError, isSuccess } = useAppSelector((state) => state.products);

  const onChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    if (e.target.files) {
      setFile(e.target.files[0]);
    }
  };

  useEffect(() => {
    if (isError) {
      alert(isError.message);
      dispatch(productActions.clearError());
    }
    if (isSuccess) {
      dispatch(productActions.clearSuccess());
      navigate('/admin/products');
    }
  }, [isError, isSuccess]);

  const handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();

    const product = {
      name,
      description,
      file,
      categoryId,
      price,
    };
    dispatch(createProduct(product));
  };

  return (
    <div className="create-product">
      <h2>Create Product</h2>
      <form onSubmit={(e) => handleSubmit(e)}>
        <label htmlFor="name">Name:</label>
        <input
          type="text"
          id="name"
          value={name}
          onChange={(e) => setName(e.target.value)}
        />

        <label htmlFor="description">Description:</label>
        <textarea
          id="description"
          value={description}
          onChange={(e) => setDescription(e.target.value)}
        />
        <label htmlFor="file">Image:</label>
        <input
          type="file"
          name="file"
          id="file"
          accept="iamges/*"
          onChange={(e) => onChange(e)}
        />
        <label htmlFor="category">Category:</label>
        <select
          id="category"
          value={categoryId}
          onChange={(e) => setCategoryId(e.target.value)}
        >
          <option value="">Select a Category</option>
          {categories.map((c) => (
            <option key={c.id} value={c.id}>
              {c.name}
            </option>
          ))}
        </select>

        <label htmlFor="price">Price:</label>
        <input
          type="number"
          id="price"
          value={price}
          onChange={(e) => setPrice(parseInt(e.target.value))}
        />
        <button type="submit">Create</button>
      </form>
    </div>
  );
};

export default NewProduct;
