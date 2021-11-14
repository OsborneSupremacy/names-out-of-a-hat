<template>
    <div class="card mb-3" style="width: 18rem;display: inline-flex;margin: 10px;">
      <h5 v-if="giver.person.name.trim().length === 0" class="card-header bg-info">Edit Person</h5>
      <h5 v-if="giver.person.name.trim().length > 0" class="card-header bg-info">{{ giver.person.name }}</h5>
      <!-- display mode stuff -->
      <ul v-if="!editMode" class="list-group list-group-flush">
        <li v-if="giver.person.email.length > 0" class="list-group-item">📧 {{ giver.person.email }}</li>
        <li class="list-group-item">
          <ul v-if="giver.recipients.length > 0">
            <label class="form-label"><b>🎁 Eligible Recipients</b></label>
            <div v-for="recipient in giver.recipients" :key="recipient.id" class="form-check" style="text-align: left">
              <input class="form-check-input" type="checkbox" :checked="recipient.eligible" :id="'cb_' + giver.person.id + '_' + recipient.id">
              <label class="form-check-label" :for="'cb_' + giver.person.id + '_' + recipient.id">
                {{ recipient.person.name }}
              </label>
            </div>
          </ul>
        </li>
        <li class="list-group-item">
          <a href="#" class="btn btn-sm btn-primary" @click="editMode = true" >Edit</a>&nbsp;
          <a href="#" class="btn btn-sm btn-danger" @click="remove" >Remove</a>
        </li>
      </ul>
      <!-- edit mode stuff -->
      <div v-if="editMode" class="card-body">
        <NameEdit :person="giver.person" />
        <EmailEdit :person="giver.person" />
        <a href="#" class="btn btn-sm btn-primary" @click="editMode = false" >Close</a>
      </div>
    </div>
</template>

<script lang="ts" >
import { Options, Vue } from 'vue-class-component'
import NameEdit from '@/views/NameEdit.vue'
import EmailEdit from '@/views/EmailEdit.vue'
import Giver from '@/components/Giver.vue'

@Options({
  components: {
    NameEdit,
    EmailEdit
  },
  props: {
    giver: Giver,
    removeFunction: (giver: Giver) => Boolean
  },
  data: () => ({
    editMode: Boolean(false)
  }),
  methods: {
    remove () {
      this.removeFunction(this.giver)
    }
  }
})
export default class GiverDisplay extends Vue {}
</script>
