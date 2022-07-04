<template>
  <v-row justify="center">
    <v-dialog v-model="dialog" persistent max-width="1000px">
      <v-card>
        <v-card-title>
          <span class="text-h5">Handled Subjects</span>
        </v-card-title>
        <v-card-text>
          <v-container>
            <v-simple-table>
              <template v-slot:default>
                <thead>
                  <tr>
                    <th class="text-left">
                      Subject
                    </th>
                    <th class="text-left">
                      Course
                    </th>
                    <th class="text-left">
                      Class
                    </th>
                    <th class="text-left">
                      Days
                    </th>
                    <th class="text-left">
                      Room
                    </th>
                    <th class="text-left">
                      Time
                    </th>
                  </tr>
                </thead>
                <tbody>
                  <tr v-for="(item, index) in data" :key="index">
                    <td>{{ item.subject }}</td>
                    <td>{{ item.course_title }} - {{ item.year_level }}{{ item.section }}</td>
                    <td>{{ item.class }}</td>
                    <td>{{ isSchedGen ? item.days : '?' }}</td>
                    <td>{{ isSchedGen ? item.room : '?'}}</td>
                    <td>{{ isSchedGen ? `${item.time_in} - ${item.time_out}` : '?'}} </td>
                  </tr>
                </tbody>
              </template>
            </v-simple-table>
          </v-container>
        </v-card-text>
        <v-card-actions>
          <v-spacer></v-spacer>
            <v-btn elevation="1"
              :disabled="!isSchedGen"
              class="btn btn-info"
              color="info"
              href="file/SCHEDULE.xlsx"
              download
              >Download</v-btn>
          <v-btn color="default" outlined @click="$emit('close')">
            Close
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </v-row>
</template>
<script>
import { mapState } from 'vuex';

export default {
  name: 'PWDDialog',
  props: {
    dialog: {
      type: Boolean,
      default: false,
    },
    data: {
      type: Array,
      default: () => [],
    },
  },
  computed: {
    ...mapState('subject', ['isSchedGen']),
  },
};
</script>
