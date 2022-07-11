<template>
  <v-row justify="center">
    <v-dialog v-model="dialog" persistent max-width="600px">
      <v-card>
        <v-card-title>
          <span class="text-h5">Offered Subject Information</span>
        </v-card-title>
        <v-card-text>
          <v-container>
            <v-row>
              <v-col cols="12" sm="6" md="6">
                <v-text-field
                  readonly
                  label="Subject code"
                  v-model="data.subject"
                  required
                ></v-text-field>
              </v-col>
              <v-col cols="12" sm="6" md="6">
                <!-- <v-text-field
                  label="Assigned Instructor"
                  v-model="data.instructor_name"
                ></v-text-field> -->
                <v-autocomplete
                  :readonly="user.role === 'registrar'"
                  label="Assigned Instructor"
                  :items="instructors"
                  v-model="data.instructor_id"
                  :item-text="item => `${item.last_name}, ${item.first_name}`"
                  item-value="instructor_id"
                ></v-autocomplete>
              </v-col>
              <v-col cols="12" sm="6" md="4">
                <v-text-field
                  readonly
                  label="Course"
                  v-model="data.course_title"
                  persistent-hint
                  required
                ></v-text-field>
              </v-col>
              <v-col cols="12" sm="6" md="4">
                <v-text-field
                  readonly
                  label="Year level"
                  v-model="data.year_level"
                  required
                ></v-text-field>
              </v-col>
              <v-col cols="12" sm="6" md="4">
                <v-text-field
                  readonly
                  label="Section"
                  v-model="data.section"
                  required
                ></v-text-field>
              </v-col>

              <!-- <v-col cols="12" sm="6" md="4">
                <v-text-field
                  label="Days"
                  v-model="data.days"
                  persistent-hint
                  required
                ></v-text-field>
              </v-col>
              <v-col cols="12" sm="6" md="4">
                <v-text-field label="Room" v-model="data.room" required></v-text-field>
              </v-col>
              <v-col cols="12" sm="6" md="2">
                <v-text-field label="Time In" v-model="data.time_in" required></v-text-field>
              </v-col>
              <v-col cols="12" sm="6" md="2">
                <v-text-field label="Time Out" v-model="data.time_out" required></v-text-field>
              </v-col> -->
            </v-row>
          </v-container>
        </v-card-text>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn color="default" outlined @click="$emit('close')">
            Close
          </v-btn>
          <v-btn color="success" outlined @click="$emit('assign', [data.instructor_id, data.schedule_id])">
            Save
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </v-row>
</template>
<script>
import { mapState } from 'vuex';

export default {
  name: 'OfferedSubjectsForm',
  props: {
    dialog: {
      type: Boolean,
      default: false,
    },
    data: {
      type: Object,
      default: () => {},
    },
    instructors: {
      type: Array,
      default: () => [],
    },
  },
  computed: {
    ...mapState('auth', ['user']),
  },
};
</script>
