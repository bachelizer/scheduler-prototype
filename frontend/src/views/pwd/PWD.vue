<template>
  <v-row>
    <v-col cols="12">
      <v-card>
        <PageTitle :title="'PWD Scheduler'" :subTitle="'Scheduling for PWD Instructors.'" />
        <v-col>
          <v-row justify="space-between">
            <v-col cols="4" md="4" sm="2">
              <v-text-field
                id="firstname"
                v-model="search"
                outlined
                dense
                placeholder="Search ... "
                hide-details
              ></v-text-field>
            </v-col>
            <v-col lg="2" cols="4" md="2" sm="2">
              <v-btn @click="onGeneration" color="success">Generate schedule</v-btn>
            </v-col>
          </v-row>
        </v-col>

        <v-data-table :headers="headers" :items="instructors" :search="search">
          <template v-slot:item.actions="{ item }">
            <v-btn
              elevation="1"
              small
              class="btn btn-info"
              color="info"
              @click="onSubjectHandled(item.instructor_id)"
              >Subjects handled</v-btn
            >
          </template>
        </v-data-table>
      </v-card>
    </v-col>
    <PWDDialog
      v-if="dialogSched"
      :dialog="dialogSched"
      :data="handledSubjects"
      @close="dialogSched = false"
    />
    <PWDScheduleGeneration v-if="dialog" :dialog="dialog" :instructors="instructors" :handledSubjects="handledSubjects" @close="dialog = false" />
  </v-row>
</template>
<script>
import { mapState, mapActions } from 'vuex';
import PageTitle from '@/components/PageTitle.vue';
import PWDScheduleGeneration from './PWDScheduleGeneration.vue';
import PWDDialog from './PWDDialog.vue';

export default {
  components: { PageTitle, PWDScheduleGeneration, PWDDialog },
  name: 'PWD',
  data() {
    return {
      dialog: false,
      dialogSched: false,
      search: '',
      headers: [
        {
          text: 'Designation',
          sortable: false,
          value: 'designation',
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
    this.loadInstructor();
  },
  methods: {
    ...mapActions('instructor', ['fetchPWDInstructors', 'fetchHandledSubjects']),
    async loadInstructor() {
      try {
        await this.fetchPWDInstructors();
      } catch (e) {
        console.log(e.message);
      }
    },
    async onSubjectHandled(id) {
      this.dialogSched = true;
      try {
        await this.fetchHandledSubjects(id);
      } catch (e) {
        console.log(e.message);
      }
    },
    onGeneration() {
      this.dialog = true;
    },
  },
  computed: {
    ...mapState('instructor', ['instructors', 'handledSubjects']),
  },
};
</script>
