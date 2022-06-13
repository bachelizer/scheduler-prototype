<template>
  <v-row justify="center">
    <v-dialog v-model="dialog" persistent max-width="600px">
      <v-card>
        <v-card-title>
          <span class="text-h5">Rooms form</span>
        </v-card-title>
        <v-card-text>
          <v-container>
            <v-row>
              <v-col col>
                <v-text-field label="College" v-model="data.institute_title"></v-text-field>
              </v-col>
              <v-col col>
                <v-text-field v-model="data.room" label="Room"></v-text-field>
              </v-col>

              <v-col cols="12" sm="6">
                <v-select
                  v-model="data.category"
                  :items="['lec', 'lab', 'agri_lab', 'com_lab', 'engr_lab']"
                  label="Subject category"
                  required
                ></v-select>
              </v-col>
            </v-row>
          </v-container>
        </v-card-text>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn color="default" outlined @click="$emit('close')">
            Close
          </v-btn>
          <v-btn color="success" outlined @click="$emit('close')">
            Save
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </v-row>
</template>
<script>
export default {
  name: 'RoomsForm',
  props: {
    dialog: {
      type: Boolean,
      default: false,
    },
    data: {
      type: Object,
      default: () => {},
    },
  },
};
</script>
