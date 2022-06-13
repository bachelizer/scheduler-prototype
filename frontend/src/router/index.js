import Vue from 'vue';
import VueRouter from 'vue-router';

Vue.use(VueRouter);

const routes = [
  // {
  //   path: '/',
  //   redirect: 'instructors',
  // },
  // {
  //   path: '/dashboard',
  //   name: 'dashboard',
  //   component: () => import('@/views/dashboard/Dashboard.vue'),
  // },
  // {
  //   path: '/typography',
  //   name: 'typography',
  //   component: () => import('@/views/typography/Typography.vue'),
  // },
  // {
  //   path: '/icons',
  //   name: 'icons',
  //   component: () => import('@/views/icons/Icons.vue'),
  // },
  // {
  //   path: '/cards',
  //   name: 'cards',
  //   component: () => import('@/views/cards/Card.vue'),
  // },
  // {
  //   path: '/simple-table',
  //   name: 'simple-table',
  //   component: () => import('@/views/simple-table/SimpleTable.vue'),
  // },
  // {
  //   path: '/form-layouts',
  //   name: 'form-layouts',
  //   component: () => import('@/views/form-layouts/FormLayouts.vue'),
  // },
  // {
  //   path: '/pages/account-settings',
  //   name: 'pages-account-settings',
  //   component: () => import('@/views/pages/account-settings/AccountSettings.vue'),
  // },
  {
    path: '/',
    name: 'pages-login',
    component: () => import('@/views/pages/Login.vue'),
    meta: {
      layout: 'blank',
    },
  },
  // {
  //   path: '/pages/register',
  //   name: 'pages-register',
  //   component: () => import('@/views/pages/Register.vue'),
  //   meta: {
  //     layout: 'blank',
  //   },
  // },
  // {
  //   path: '/error-404',
  //   name: 'error-404',
  //   component: () => import('@/views/Error.vue'),
  //   meta: {
  //     layout: 'blank',
  //   },
  // },

  // start of custom
  {
    path: '/pwd-scheduler',
    name: 'pwd-scheduler',
    component: () => import('@/views/pwd/PWD.vue'),
  },
  {
    path: '/laboratory',
    name: 'laboratory',
    component: () => import('@/views/laboratory/Laboratory.vue'),
  },
  {
    path: '/lecture',
    name: 'lecture',
    component: () => import('@/views/lecture/Lecture.vue'),
  },
  {
    path: '/instructors',
    name: 'instructors',
    component: () => import('@/views/instructor/Instructor.vue'),
  },
  {
    path: '/rooms',
    name: 'rooms',
    component: () => import('@/views/rooms/Rooms.vue'),
  },
  {
    path: '/offered-subejects',
    name: 'offered-subjects',
    component: () => import('../views/offered-subjects/OfferedSubjects.vue'),
  },
  {
    path: '/schedule',
    name: 'schedule',
    component: () => import('../views/schedules/Schedules.vue')
  },
  {
    path: '*',
    redirect: 'error-404',
  },
];

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes,
});

export default router;
