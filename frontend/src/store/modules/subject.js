import Vue from 'vue';
import Vuex from 'vuex';

import * as auth from './auth';

import subject from '@/helper/services/subject.service';
import utilities from '@/helper/utilities';

Vue.use(Vuex);

export default {
  namespaced: true,
  state: {
    offers: [],
    isPwdGen: false,
    isSchedGen: false,
  },
  mutations: {
    SET_OFFERED(state, payload) {
      const course = this.state.auth.user.fkcourseidPC;
      const list = utilities.getByProgram(course, payload);
      state.offers = list;
    },
    SET_PWD_GENERATE(state) {
      state.isPwdGen = true;
    },
    SET_SCHED_GENERATE(state) {
      state.isSchedGen = true;
    },
  },
  actions: {
    async fetchOfferSubjects({ commit }) {
      try {
        const { data } = await subject.fetchOfferedSubjects();
        commit('SET_OFFERED', data);
      } catch (error) {
        console.log(error);
        throw error;
      }
    },
    async fetchLaboratorySubjects({ commit }) {
      try {
        const { data } = await subject.fetchLaboratorySubjects();
        commit('SET_OFFERED', data);
      } catch (error) {
        console.log(error);
        throw error;
      }
    },
    async fetchLectureSubjects({ commit }) {
      try {
        const { data } = await subject.fetchLectureSubjects();
        commit('SET_OFFERED', data);
      } catch (error) {
        console.log(error);
        throw error;
      }
    },

    setPwdGen({ commit }) {
      commit('SET_PWD_GENERATE');
    },
    setSchedGen({ commit }) {
      commit('SET_SCHED_GENERATE');
    },
  },
  modules: {
    auth,
  },
};
