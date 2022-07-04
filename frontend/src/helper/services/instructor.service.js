import api from '../api';

const fetchInstructors = () => api.get('/instructor');

const fetchPWDInstructors = () => api.get('/instructor/pwd');

const fetchHandledSubjects = instructor_id =>
  api.get(`/subject/handled-subject?instructor_id=${instructor_id}`);

export default {
  fetchInstructors,
  fetchPWDInstructors,
  fetchHandledSubjects,
};
