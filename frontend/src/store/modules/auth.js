import Vue from 'vue';
import Vuex from 'vuex';

import auth from '@/helper/services/auth.service';

Vue.use(Vuex);

export default {
  namespaced: true,
  state: {
    user: {},
  },
  mutations: {
    SET_USER(state, data) {
      state.user = data;
    },
  },
  actions: {
    async getUser({ commit }, [username, password]) {
      try {
        const { data } = await auth.auth(username, password);
        commit('SET_USER', data);
      } catch (error) {
        console.log(error);
        throw error;
      }
    },
  },
};
