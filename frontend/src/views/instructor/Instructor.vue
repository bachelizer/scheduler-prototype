<template>
  <v-row>
    <v-col cols="12">
      <v-card>
        <PageTitle :title="'Instructor'" :subTitle="'List of Instructors.'" />
        <v-col cols="4">
          <v-text-field
            id="firstname"
            v-model="search"
            outlined
            dense
            placeholder="Search ..."
            hide-details
          ></v-text-field>
        </v-col>
        <v-data-table :items="instructors" :headers="headers" :search="search">
          <template v-slot:item.middlename="{ item }">
           {{ item.middle_name }}
           <v-chip v-if="item.isPWD" class="ma-2" x-small color="success" text-color="white">
              PWD </v-chip
            >
          </template>
          <template v-slot:item.actions="{ item }">
            <v-btn
              elevation="1"
              small
              class="btn btn-info"
              color="info"
              @click="onInformation(item)"
              >Information</v-btn
            >
          </template>
        </v-data-table>
      </v-card>
    </v-col>
    <instructor-form
    v-if="dialog"
    :dialog="dialog"
    :data="data"
    @close ="dialog = false"
    ></instructor-form>
  </v-row>
</template>
<script>
import { mapActions, mapState } from 'vuex';

import PageTitle from '@/components/PageTitle.vue';
import InstructorForm from './InstructorForm.vue';

export default {
  components: { PageTitle, InstructorForm },
  data() {
    return {
      dialog: false,
      data: {},
      search: '',
      headers: [
        {
          text: 'Designation',
          align: 'start',
          sortable: false,
          value: 'designation',
          filterable: false,
        },
        { text: 'Lastname', value: 'last_name' },
        { text: 'Firstname', value: 'first_name' },
        { text: 'Middlename', value: 'middlename', filterable: false },
        { text: 'Institute of', value: 'institute_title', filterable: false },
        { text: 'Actions', value: 'actions', filterable: false },
      ],
    };
  },
  created() {
    this.loadInstructors();
  },
  methods: {
    ...mapActions({
      fetchInstructors: 'instructor/fetchInstructors',
    }),
    loadInstructors() {
      this.fetchInstructors();
    },
    onInformation(item) {
      this.dialog = true;
      this.data = item;
    },
  },
  computed: {
    ...mapState({
      instructors: state => state.instructor.instructors,
    }),
  },
};
</script>
