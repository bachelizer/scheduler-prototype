<template>
  <v-row justify="center">
    <v-dialog v-model="dialog" fullscreen hide-overlay transition="dialog-bottom-transition">
      <v-card>
        <v-toolbar dark color="primary">
          <v-btn dark icon @click="$emit('close')"
            ><v-icon>{{ icons.mdiClose }}</v-icon></v-btn
          >
          <v-toolbar-title>Lecture Scheduler</v-toolbar-title>
          <v-spacer></v-spacer>
          <v-toolbar-items>
            <v-btn class="mt-2" dark text @click="$emit('close')">
              Save
            </v-btn>
          </v-toolbar-items>
        </v-toolbar>
        <v-row justify="center" class="mt-5 mb-5">
          <v-col md="2">
            <v-btn @click="generate" color="primary">Generate</v-btn>
          </v-col>
        </v-row>
        <v-progress-linear v-if="showProgress" indeterminate color="success"></v-progress-linear>

        <v-divider></v-divider>

        <v-col>
          <v-row justify="space-between">
            <v-col cols="4">
              <v-text-field
                v-model="search"
                outlined
                dense
                placeholder="Search ... "
                hide-details
              ></v-text-field>
            </v-col>
          </v-row>
        </v-col>
        <v-data-table v-if="showTable" :headers="headers" :items="offers" :search="search">
          <template v-slot:top>
            <v-toolbar flat>
              <v-toolbar-title>Generation Result</v-toolbar-title>
            </v-toolbar>
          </template>
        </v-data-table>
      </v-card>
    </v-dialog>
  </v-row>
</template>
<script>
import { mdiClose } from '@mdi/js';

export default {
  name: 'LectureScheduleGeneration',
  data() {
    return {
      showProgress: false,
      showTable: false,
      icons: {
        mdiClose,
      },
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
        { text: 'Instructor', value: 'instructor_name' },
        { text: 'Days', value: 'days', filterable: false },
        { text: 'Room', value: 'room', filterable: false },
        { text: 'Time In', value: 'time_in', filterable: false },
        { text: 'Time Out', value: 'time_out', filterable: false },
      ],
    };
  },
  props: {
    dialog: {
      type: Boolean,
      default: false,
    },
    offers: {
      type: Array,
      default: () => [],
    },
  },
  methods: {
    generate() {
      this.showProgress = true;
      setTimeout(() => {
        this.showTable = true;
        this.showProgress = false;
      }, 7000);
    },
  },
};
</script>
