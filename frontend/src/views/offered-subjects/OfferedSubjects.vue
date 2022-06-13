<template>
  <v-row>
    <v-col cols="12">
      <v-card>
        <PageTitle
          :title="'Offered Subjects'"
          :subTitle="'List of Offered Subjects for the current academic year.'"
        />
        <v-col cols="4">
          <v-text-field
            v-model="search"
            outlined
            dense
            placeholder="Search ..."
            hide-details
          ></v-text-field>
        </v-col>
        <v-data-table :items="offers" :headers="headers" :search="search">
          <template v-slot:item.middlename="{ item }">
            {{ item.middle_name }}
            <v-chip v-if="item.isPWD" class="ma-2" x-small color="success" text-color="white">
              PWD
            </v-chip>
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
    <offered-subjects-form
      v-if="dialog"
      :dialog="dialog"
      :data="data"
      @close="dialog = false"
    ></offered-subjects-form>
  </v-row>
</template>
<script>
import { mapActions, mapState } from 'vuex';

import PageTitle from '@/components/PageTitle.vue';
import OfferedSubjectsForm from './OfferedSubjectsForm.vue';

export default {
  components: { PageTitle, OfferedSubjectsForm },
  data() {
    return {
      dialog: false,
      data: {},
      search: '',
      headers: [
        {
          text: 'Subject',
          align: 'start',
          value: 'subject',
        },
        { text: 'Course', value: 'course_title' },
        { text: 'Year', value: 'year_level' },
        { text: 'Section', value: 'section', filterable: false },
        { text: 'Class', value: 'class', filterable: false },
        { text: 'Days', value: 'days', filterable: false },
        { text: 'Time-in', value: 'time_in', filterable: false },
        { text: 'Time-out', value: 'time_out', filterable: false },
        { text: 'Instructor', value: 'instructor_name' },
        { text: 'Actions', value: 'actions', filterable: false },
      ],
    };
  },
  created() {
    this.loadOffers();
  },
  methods: {
    ...mapActions({
      fetchOffers: 'subject/fetchOfferSubjects',
    }),
    loadOffers() {
      this.fetchOffers();
    },
    onInformation(item) {
      this.dialog = true;
      this.data = item;
    },
  },
  computed: {
    ...mapState({
      offers: state => state.subject.offers,
    }),
  },
};
</script>
