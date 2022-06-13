import api from '../api';

const auth = (usename, password) => api.post(`/auth?username=${usename}&password=${password}`);

export default {
  auth,
};
