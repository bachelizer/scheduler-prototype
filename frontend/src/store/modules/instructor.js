import Vue from 'vue';
import Vuex from 'vuex';

import instructor from '@/helper/services/instructor.service';

import * as auth from './auth';

import utilities from '../../helper/utilities';

Vue.use(Vuex);

export default {
  namespaced: true,
  state: {
    instructors: [],
    handledSubjects: [],
  },
  mutations: {
    SET_INSTRUCTOR(state, data) {
      state.instructors = data;
    },
    SET_HANDLED_SUBJECTS(state, data) {
      const a = data.filter(x => {
        return x.time_in !== 'TBA' && x.room.includes('TBA') === false;
      });
      console.log(a);
      state.handledSubjects = a;
    },
  },
  actions: {
    async fetchInstructors({ commit }) {
      try {
        const { data } = await instructor.fetchInstructors();
        const id = this.state.auth.user.instructor_id;
        const instruc = utilities.getInstructor(id, data);
        commit('SET_INSTRUCTOR', instruc);
      } catch (error) {
        console.log(error);
        throw error;
      }
    },
    async fetchAllInstructors({ commit }) {
      try {
        const { data } = await instructor.fetchInstructors();
        const { course_id } = this.state.auth.user;

        const list = data.filter(x => x.course_id === course_id);
        commit('SET_INSTRUCTOR', course_id ? list : data);
      } catch (error) {
        console.log(error);
        throw error;
      }
    },
    async fetchPWDInstructors({ commit }) {
      try {
        const { data } = await instructor.fetchPWDInstructors();
        commit('SET_INSTRUCTOR', data);
      } catch (error) {
        console.log(error);
        throw error;
      }
    },
    async fetchHandledSubjects({ commit }, id) {
      try {
        const { data } = await instructor.fetchHandledSubjects(id);
        commit('SET_HANDLED_SUBJECTS', data);
      } catch (error) {
        console.log(error);
        throw error;
      }
    },
  },
  modules: {
    auth,
  },
};
