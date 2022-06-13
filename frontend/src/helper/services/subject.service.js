import api from '../api';

const fetchOfferedSubjects = () => api.get('/subject/offered');

const fetchLaboratorySubjects = () => api.get('/subject/offered');

const fetchLectureSubjects = () => api.get('/subject/lecture');

export default {
  fetchOfferedSubjects,
  fetchLaboratorySubjects,
  fetchLectureSubjects,
};
