import axios from 'axios';

const axiosInstance = axios.create({
  baseURL: 'https://shopping-backend.azurewebsites.net',
});
export default axiosInstance;
