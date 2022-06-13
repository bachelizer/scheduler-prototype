<template>
  <v-row justify="center">
    <v-dialog v-model="dialog" persistent max-width="600px">
      <v-card>
        <v-card-title>
          <span class="text-h5">Instructor form</span>
        </v-card-title>
        <v-card-text>
          <v-container>
            <v-row>
              <v-col cols="12" sm="4" md="2">
                <v-text-field
                  label="Designation"
                  v-model="data.designation"
                  required
                ></v-text-field>
              </v-col>
              <v-col cols="12" sm="6" md="4">
                <v-text-field
                  label="Last Name"
                  v-model="data.last_name"
                  hint="example of helper text only on focus"
                ></v-text-field>
              </v-col>
              <v-col cols="12" sm="6" md="4">
                <v-text-field
                  v-model="data.first_name"
                  label="First Name"
                  hint="example of persistent helper text"
                  required
                ></v-text-field>
              </v-col>
              <v-col cols="12" sm="6" md="2">
                <v-text-field
                  v-model="data.middle_name"
                  label="Midlle Initial"
                  hint="example of persistent helper text"
                  required
                ></v-text-field>
              </v-col>
              <v-col cols="12" sm="6">
                <v-select
                  v-model="data.institute_title"
                  :items="['CEIS', 'CTE', 'CA', 'CAS']"
                  label="College of"
                  required
                ></v-select>
              </v-col>
              <v-switch
                v-model="data.isPWD"
                inset
                :label="`is PWD? :${data.isPWD ? 'YES' : 'NO'}`"
              ></v-switch>
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
  name: 'InstructorForm',
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
