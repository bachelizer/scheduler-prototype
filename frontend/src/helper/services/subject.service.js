import api from '../api';

const fetchOfferedSubjects = () => api.get('/subject/offered');

const fetchLaboratorySubjects = () => api.get('/subject/offered');

const fetchLectureSubjects = () => api.get('/subject/lecture');

const assignInstructor = ([instructorID, scheduleId]) => api.post(`/subject?instructorID=${instructorID}&scheduleId=${scheduleId}`);

export default {
  fetchOfferedSubjects,
  fetchLaboratorySubjects,
  fetchLectureSubjects,
  assignInstructor,
};
