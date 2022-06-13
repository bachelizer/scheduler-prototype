import api from '../api';

const fetchInstructors = () => api.get('/instructor');

const fetchPWDInstructors = () => api.get('/instructor/pwd');

export default {
  fetchInstructors,
  fetchPWDInstructors,
};
