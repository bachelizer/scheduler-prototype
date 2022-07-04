import Vue from 'vue';
import Vuex from 'vuex';

import createPersistedState from 'vuex-persistedstate';

import instructor from './modules/instructor';
import room from './modules/room';
import subject from './modules/subject';
import auth from './modules/auth';

Vue.use(Vuex);

export default new Vuex.Store({
  plugins: [
    createPersistedState({
      storage: window.sessionStorage,
      paths: ['auth', 'subject.isPwdGen', 'subject.isSchedGen'],
    }),
  ],
  state: {},
  mutations: {},
  actions: {},
  modules: {
    instructor,
    room,
    subject,
    auth,
  },
});
