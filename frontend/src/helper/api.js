import axios from 'axios';

axios.defaults.headers.common['Access-Control-Allow-Origin'] = 'http://localhost:8080';

// return axiosInstance;
const data = parsedUrl => {
  if (parsedUrl === 'http://localhost:8080') {
    return 'http://localhost:5000';
  }
 
  return null;
};

export default axios.create({
  baseURL: data(window.location.origin),
  withCredentials: true,
  headers: {
    'Content-Type': 'application/json',
  },
  credentials: 'include',
});
