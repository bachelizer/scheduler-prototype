<template>
  <v-row justify="center">
    <v-dialog v-model="dialog" fullscreen hide-overlay transition="dialog-bottom-transition">
      <v-card>
        <v-toolbar dark color="primary">
          <v-btn dark icon @click="$emit('close')"
            ><v-icon>{{ icons.mdiClose }}</v-icon></v-btn
          >
          <v-toolbar-title>PWD Scheduler</v-toolbar-title>
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

        <v-data-table
          v-if="showTable"
          :headers="dessertHeaders"
          :items="desserts"
          :single-expand="singleExpand"
          item-key="instructor_id"
          show-expand
          class="elevation-2"
          @item-expanded="loadDetails"
        >
          <template v-slot:top>
            <v-toolbar flat>
              <v-toolbar-title>Generation Result</v-toolbar-title>
            </v-toolbar>
          </template>
          <template v-slot:expanded-item="{ headers, item }">
            <td :colspan="headers.length" class="mt-3 mb-3">
              <div class="row mt-3 mb-3">
                <table width="1500px" style="margin-left: 10%;" class="text-left">
                  <thead>
                    <th>Subject Code</th>
                    <th>Course</th>
                    <th>Year</th>
                    <th>Section</th>
                    <th>Days</th>
                    <th>Time In</th>
                    <th>Time Out</th>
                  </thead>
                  <tbody>
                    <tr v-for="(i, index) in item.scheddules" :key="index">
                      <td>{{ i.subjectCode }}</td>
                      <td>{{ i.course }}</td>
                      <td>{{ i.year }}</td>
                      <td>{{ i.section }}</td>
                      <td>{{ i.days }}</td>
                      <td>{{ i.time_in }}</td>
                      <td>{{ i.time_out }}</td>
                    </tr>
                  </tbody>
                </table>
              </div>
            </td>
          </template>
        </v-data-table>
      </v-card>
    </v-dialog>
  </v-row>
</template>
<script>
import { mdiClose } from '@mdi/js';

export default {
  name: 'PWDScheduleGeneration',
  data() {
    return {
      showProgress: false,
      showTable: false,
      icons: {
        mdiClose,
      },
      expanded: [],
      singleExpand: true,
      dessertHeaders: [
        {
          text: 'Designation',
          sortable: false,
          value: 'designation',
        },
        { text: 'Lastname', value: 'last_name' },
        { text: 'Firstname', value: 'first_name' },
        { text: 'Middlename', value: 'middlename', filterable: false },
        { text: 'Institute of', value: 'institute_title', filterable: false },
      ],
      desserts: [
        {
          instructor_id: 1,
          designation: 'Ms.',
          last_name: 'Instructor1',
          first_name: 'One',
          middlename: 'D',
          institute_title: 24,
          scheddules: [
            {
              subjectCode: 'ISS 1',
              course: 'BSIT',
              year: 1,
              section: 'A',
              days: 'T TH',
              time_in: '8:00',
              time_out: '9:30',
            },
            {
              subjectCode: 'IT 01',
              course: 'BSIT',
              year: 1,
              section: 'A',
              days: 'M W F',
              time_in: '8:00',
              time_out: '9:30',
            },
            {
              subjectCode: 'IT 01',
              course: 'BSIT',
              year: 1,
              section: 'A',
              days: 'M W F',
              time_in: '8:00',
              time_out: '9:30',
            },
            {
              subjectCode: 'IT 01',
              course: 'BSIT',
              year: 1,
              section: 'A',
              days: 'M W F',
              time_in: '8:00',
              time_out: '9:30',
            },
          ],
        },
        {
          instructor_id: 2,
          designation: 'Engr.',
          last_name: 'Instructor2',
          first_name: 'Two',
          middlename: 'D',
          institute_title: 24,
          scheddules: [
            {
              subjectCode: 'ISS 1',
              course: 'BSIT',
              year: 1,
              section: 'A',
              days: 'T TH',
              time_in: '8:00',
              time_out: '9:30',
            },
            {
              subjectCode: 'IT 01',
              course: 'BSIT',
              year: 1,
              section: 'A',
              days: 'M W F',
              time_in: '8:00',
              time_out: '9:30',
            },
            {
              subjectCode: 'IT 01',
              course: 'BSIT',
              year: 1,
              section: 'A',
              days: 'M W F',
              time_in: '8:00',
              time_out: '9:30',
            },
            {
              subjectCode: 'IT 01',
              course: 'BSIT',
              year: 1,
              section: 'A',
              days: 'M W F',
              time_in: '8:00',
              time_out: '9:30',
            },
          ],
        },
        {
          instructor_id: 3,
          designation: 'Mr.',
          last_name: 'Instructor3',
          first_name: 'Three',
          middlename: 'D',
          institute_title: 24,
          scheddules: [
            {
              subjectCode: 'ISS 1',
              course: 'BSIT',
              year: 1,
              section: 'A',
              days: 'T TH',
              time_in: '8:00',
              time_out: '9:30',
            },
            {
              subjectCode: 'IT 01',
              course: 'BSIT',
              year: 1,
              section: 'A',
              days: 'M W F',
              time_in: '8:00',
              time_out: '9:30',
            },
            {
              subjectCode: 'IT 01',
              course: 'BSIT',
              year: 1,
              section: 'A',
              days: 'M W F',
              time_in: '8:00',
              time_out: '9:30',
            },
            {
              subjectCode: 'IT 01',
              course: 'BSIT',
              year: 1,
              section: 'A',
              days: 'M W F',
              time_in: '8:00',
              time_out: '9:30',
            },
          ],
        },
      ],
    };
  },
  props: {
    dialog: {
      type: Boolean,
      default: false,
    },
  },
  methods: {
    loadDetails({ item }) {
      return this.desserts.filter(x => x.instructor_id == item.instructor_id);
    },
    generate() {
      this.showProgress = true;
      setTimeout(() => {
        this.showTable = true;
        this.showProgress = false;
      }, 5000);
    },
  },
};
</script>
