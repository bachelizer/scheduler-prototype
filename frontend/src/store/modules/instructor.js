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
  },
  mutations: {
    SET_INSTRUCTOR(state, data) {
      state.instructors = data;
    },
  },
  actions: {
    async fetchInstructors({ commit }) {
      try {
        const { data } = await instructor.fetchInstructors();
        const id = this.state.auth.user.instructor_id;
        const instruc = utilities.getInstructor(id, data);
        console.log(instruc);
        commit('SET_INSTRUCTOR', instruc);
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
  },
  modules: {
    auth,
  },
};
