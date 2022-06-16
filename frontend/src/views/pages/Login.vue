<template>
  <div class="auth-wrapper auth-v1">
    <div class="auth-inner">
      <v-card class="auth-card">
        <!-- logo -->
        <v-card-title class="d-flex align-center justify-center py-7">
          <router-link to="/" class="d-flex align-center">
            <v-img
              :src="require('@/assets/images/logos/logo.png')"
              max-height="30px"
              max-width="30px"
              alt="logo"
              contain
              class="me-3 "
            ></v-img>

            <h2 class="text-2xl font-weight-semibold">
              Scheduler
            </h2>
          </router-link>
        </v-card-title>

        <!-- title -->
        <v-card-text>
          <p class="text-2xl font-weight-semibold text--primary mb-2">
            Welcome to Scheduler! 👋🏻
          </p>
          <!-- <p class="mb-2">
            Please sign-in to your account and start the adventure
          </p> -->
        </v-card-text>

        <!-- login form -->
        <v-card-text>
          <v-form>
            <v-text-field v-model="username" outlined hide-details class="mb-3"></v-text-field>

            <v-text-field
              v-model="password"
              outlined
              :type="isPasswordVisible ? 'text' : 'password'"
              label="Password"
              placeholder="············"
              :append-icon="isPasswordVisible ? icons.mdiEyeOffOutline : icons.mdiEyeOutline"
              hide-details
              @click:append="isPasswordVisible = !isPasswordVisible"
            ></v-text-field>

            <div class="d-flex align-center justify-space-between flex-wrap">
              <v-checkbox label="Remember Me" hide-details class="me-3 mt-1"> </v-checkbox>

              <!-- forgot link -->
              <a href="javascript:void(0)" class="mt-1">
                Forgot Password?
              </a>
            </div>

            <v-btn @click="signIn" block color="primary" class="mt-6">
              Login
            </v-btn>
          </v-form>
        </v-card-text>
      </v-card>
      <v-alert v-if="invalid" dense outlined type="error" class="mt-2">
        Invalid Account..
      </v-alert>
    </div>

    <!-- background triangle shape  -->
    <img
      class="auth-mask-bg"
      height="173"
      :src="require(`@/assets/images/misc/mask-${$vuetify.theme.dark ? 'dark' : 'light'}.png`)"
    />

    <!-- tree -->
    <v-img class="auth-tree" width="247" height="185" src="@/assets/images/misc/tree.png"></v-img>

    <!-- tree  -->
    <v-img
      class="auth-tree-3"
      width="377"
      height="289"
      src="@/assets/images/misc/tree-3.png"
    ></v-img>
  </div>
</template>

<script>
// eslint-disable-next-line object-curly-newline
import { mdiEyeOutline, mdiEyeOffOutline } from '@mdi/js';
import { ref } from '@vue/composition-api';
import { mapActions } from 'vuex';

// import { useRouter } from '@/utils';

// const { route } = useRouter();

export default {
  setup() {
    const isPasswordVisible = ref(false);

    return {
      isPasswordVisible,
      icons: {
        mdiEyeOutline,
        mdiEyeOffOutline,
      },
    };
  },
  data() {
    return {
      username: '',
      password: '',
      invalid: false,
    };
  },
  methods: {
    ...mapActions('auth', ['getUser']),
    async signIn() {
      // console.log(this.username, this.password)
      try {
        await this.getUser([this.username, this.password]);
        this.$router.push({ name: 'schedule' });
      } catch (error) {
        console.log(error);
        this.invalid = true;
      }
    },
  },
};
</script>

<style lang="scss">
@import '~@/plugins/vuetify/default-preset/preset/pages/auth.scss';
</style>
