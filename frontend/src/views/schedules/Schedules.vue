<template>
  <v-row>
    <v-col cols="12">
      <v-card>
        <PageTitle :title="'My Schedule'" :subTitle="'Faculty Schedules'" />
        <v-col cols="4">
          <v-text-field
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
              PWD
            </v-chip>
          </template>
          <template v-slot:item.actions="{ item }">
            <v-btn
              elevation="1"
              small
              class="btn btn-info"
              color="info"
              @click="onSubjectHandled(item.instructor_id)"
              >VIEW</v-btn
            >
          </template>
        </v-data-table>
      </v-card>
    </v-col>
    <SchedulesView
      v-if="dialogSched"
      :dialog="dialogSched"
      :data="handledSubjects"
      @close="dialogSched = false"
    />
  </v-row>
</template>
<script>
import { mapActions, mapState } from 'vuex';
import PageTitle from '@/components/PageTitle.vue';
import SchedulesView from './SchedulesView.vue';

export default {
  components: { PageTitle, SchedulesView },
  data() {
    return {
      dialogSched: false,
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
    this.getInstructor();
  },
  methods: {
    ...mapActions('instructor', ['fetchInstructors', 'fetchHandledSubjects']),
    getInstructor() {
      this.fetchInstructors();
    },
    async onSubjectHandled(id) {
      this.dialogSched = true;
      try {
        const a = await this.fetchHandledSubjects(id);
      } catch (e) {
        console.log(e.message);
      }
    },
  },
  computed: {
    ...mapState('instructor', ['instructors', 'handledSubjects']),
  },
};
</script>
