<template>
  <v-row>
    <v-col cols="12">
      <v-card>
        <PageTitle :title="'Rooms'" :subTitle="'List of Rooms.'" />
        <v-col cols="4">
          <v-text-field
            v-model="search"
            outlined
            dense
            placeholder="Search ..."
            hide-details
          ></v-text-field>
        </v-col>
        <v-data-table :items="rooms" :headers="headers" :search="search">
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
              @click="onInformation(item)"
              >Information</v-btn
            >
          </template>
        </v-data-table>
      </v-card>
    </v-col>
    <rooms-form v-if="dialog" :dialog="dialog" @close="dialog = false" :data="data"> </rooms-form>
  </v-row>
</template>
<script>
import { mapActions, mapState } from 'vuex';

import PageTitle from '@/components/PageTitle.vue';
import RoomsForm from './RoomsForm.vue';

export default {
  components: { PageTitle, RoomsForm },
  data() {
    return {
      data: {},
      dialog: false,
      search: '',
      headers: [
        {
          text: 'College',
          align: 'start',
          value: 'institute_title',
          filterable: false,
        },
        { text: 'Room', value: 'room' },
        { text: 'Category', value: 'category' },
        { text: 'Actions', value: 'actions', filterable: false },
      ],
    };
  },
  created() {
    this.loadRooms();
  },
  methods: {
    ...mapActions({
      fetchRooms: 'room/fetchRooms',
    }),
    loadRooms() {
      this.fetchRooms();
    },
    onInformation(item) {
      this.dialog = true;
      this.data = item;
    },
  },
  computed: {
    ...mapState({
      rooms: state => state.room.rooms,
    }),
  },
};
</script>
