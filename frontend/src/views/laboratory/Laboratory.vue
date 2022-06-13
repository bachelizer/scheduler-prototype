<template>
  <v-row>
    <v-col cols="12">
      <v-card>
        <PageTitle
          :title="'Laboratory Scheduler'"
          :subTitle="'Scheduling of laboratory subjects.'"
        />
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
            <v-col cols="2">
              <v-btn @click="onGeneration" color="success">Generate schedule</v-btn>
            </v-col>
          </v-row>
        </v-col>

        <v-data-table :headers="headers" :items="offers" :search="search">
          <!-- <template v-slot:item.actions="{ item }">
            <v-btn
              elevation="1"
              small
              class="btn btn-info"
              color="info"
              @click="onSubjectHandled(item.instructor_id)"
              >Subjects handled</v-btn
            >
          </template> -->
        </v-data-table>
      </v-card>
    </v-col>
    <laboratory-schedule-generation
      v-if="dialog"
      :dialog="dialog"
      @close="dialog = false"
      :offers="offers"
    ></laboratory-schedule-generation>
  </v-row>
</template>
<script>
import { mapActions, mapState } from 'vuex';
import PageTitle from '@/components/PageTitle.vue';
import LaboratoryScheduleGeneration from './LaboratoryScheduleGeneration.vue';

export default {
  components: { PageTitle, LaboratoryScheduleGeneration },
  data() {
    return {
      dialog: false,
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
      ],
    };
  },
  created() {
    this.loadSubjects();
  },
  methods: {
    ...mapActions('subject', ['fetchLaboratorySubjects']),
    loadSubjects() {
      this.fetchLaboratorySubjects();
    },
    onGeneration() {
      this.dialog = true;
    },
  },
  computed: {
    ...mapState('subject', ['offers']),
  },
};
</script>
