<template>
  <v-row>
    <v-col cols="12">
      <v-card>
        <PageTitle :title="'Lecture Scheduler'" :subTitle="'Scheduling of lecture subjects.'" />
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
    <lecture-schedule-generation
      v-if="dialog"
      :dialog="dialog"
      @close="dialog = false"
      :offers="offers"
    ></lecture-schedule-generation>
  </v-row>
</template>
<script>
import { mapActions, mapState } from 'vuex';
import PageTitle from '@/components/PageTitle.vue';
import LectureScheduleGeneration from './LectureScheduleGeneration.vue';

export default {
  components: { PageTitle, LectureScheduleGeneration },
  data() {
    return {
      search: '',
      dialog: false,
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
    ...mapActions('subject', ['fetchLectureSubjects']),
    loadSubjects() {
      this.fetchLectureSubjects();
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
