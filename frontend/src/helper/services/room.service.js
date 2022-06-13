import api from '../api';

const fetchRooms = () => api.get('/room');

export default {
  fetchRooms,
};
