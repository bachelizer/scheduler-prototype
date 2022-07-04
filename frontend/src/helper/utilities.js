/* eslint-disable eqeqeq */
/* eslint-disable no-plusplus */
const getByProgram = (course, payload) => {
  let data = [];
  if (course != null) {
    const splitCourse = course.split(' ');
    for (let i = 0; i < splitCourse.length; i++) {
      for (let x = 0; x < payload.length; x++) {
        if (payload[x].course_id == splitCourse[i]) {
          data.push(payload[x]);
        }
      }
    }
  } else {
    data = payload;
  }
  return data;
};

const getInstructor = (id, payload) => {
  if (id) {
    return payload.filter((x) => x.instructor_id === id);
  }
  return payload;
};

export default {
  getByProgram,
  getInstructor,
};
