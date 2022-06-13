import Vue from 'vue';
import Vuex from 'vuex';

import room from '@/helper/services/room.service';

Vue.use(Vuex);

export default {
  namespaced: true,
  state: {
    rooms: [],
  },
  mutations: {
    SET_ROOMS(state, data) {
      state.rooms = data;
    },
  },
  actions: {
    async fetchRooms({ commit }) {
      try {
        const { data } = await room.fetchRooms();
        commit('SET_ROOMS', data);
      } catch (error) {
        console.log(error);
        throw error;
      }
    },
  },
};
