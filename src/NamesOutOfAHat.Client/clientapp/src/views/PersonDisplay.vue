<template>
    <div class="card mb-3" style="width: 18rem;display: inline-flex;margin: 10px;">
      <h5 v-if="person.name.trim().length === 0" class="card-header bg-info">Edit Person</h5>
      <h5 v-if="person.name.trim().length > 0" class="card-header bg-info">{{ person.name }}</h5>
      <!-- display mode stuff -->
      <ul v-if="!editMode" class="list-group list-group-flush">
        <li v-if="person.email.length > 0" class="list-group-item">📧 {{ person.email }}</li>
        <li class="list-group-item">
          <ul v-if="people.length > 0">
            <label class="form-label"><b>🎁 Eligible Recipients</b></label>
            <div v-for="sp in people" :key="sp.id" class="form-check" style="text-align: left">
              <input class="form-check-input" type="checkbox" value="" :id="'cb_' + person.id + '_' + sp.id">
              <label class="form-check-label" :for="'cb_' + person.id + '_' + sp.id">
                {{ sp.name }}
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
        <NameEdit :person="person" />
        <EmailEdit :person="person" />
        <a href="#" class="btn btn-sm btn-primary" @click="editMode = false" >Close</a>
      </div>
    </div>
</template>

<script lang="ts" >
import { Options, Vue } from 'vue-class-component'
import Person from '@/components/Person.vue'
import NameEdit from '@/views/NameEdit.vue'
import EmailEdit from '@/views/EmailEdit.vue'

@Options({
  components: {
    NameEdit,
    EmailEdit
  },
  props: {
    person: Person,
    people: [] as Person[],
    removeFunction: (person: Person) => Boolean
  },
  data: () => ({
    editMode: Boolean(false)
  }),
  methods: {
    remove () {
      this.removeFunction(this.person)
    }
  }
})
export default class PersonDisplay extends Vue {}
</script>
