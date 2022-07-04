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
        <v-data-table :items="subjectNotTBA" :headers="headers" :search="search">
          <template v-slot:item.middlename="{ item }">
            {{ item.middle_name }}
            <v-chip v-if="item.isPWD" class="ma-2" x-small color="success" text-color="white">
              PWD
            </v-chip>
          </template>
          <template v-slot:item.day="{ item }">{{ isSchedGen ? item.days : '?' }}</template>
          <template v-slot:item.in="{ item }">{{ isSchedGen ? item.time_in : '?' }}</template>
          <template v-slot:item.out="{ item }">{{isSchedGen ? item.time_out : '?'}}</template>
          <!-- <template v-slot:item.actions="{ item }">
            <v-btn
              elevation="1"
              small
              class="btn btn-info"
              color="info"
              @click="onInformation(item)"
              >Information</v-btn
            >
          </template> -->
        </v-data-table>
      </v-card>
    </v-col>
  </v-row>
</template>
<script>
import { mapActions, mapState } from 'vuex';

import PageTitle from '@/components/PageTitle.vue';

export default {
  components: { PageTitle },
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
        { text: 'Days', value: 'day', filterable: false },
        { text: 'Time-in', value: 'in', filterable: false },
        { text: 'Time-out', value: 'out', filterable: false },
        { text: 'Instructor', value: 'instructor_name' },
        // { text: 'Actions', value: 'actions', filterable: false },
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
      isSchedGen: state => state.subject.isSchedGen,
    }),
    subjectNotTBA() {
      return this.offers.filter(x => {
        return x.time_in !== 'TBA';
      });
    },
  },
};
</script>
