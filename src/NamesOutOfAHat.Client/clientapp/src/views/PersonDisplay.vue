<template>
    <div class="card mb-3" style="width: 18rem;display: inline-flex;margin: 10px;">
      <h5 v-if="person.name.trim().length === 0" class="card-header">Edit Person</h5>
      <h5 v-if="person.name.trim().length > 0" class="card-header">{{ person.name }}</h5>
      <!-- display mode stuff -->
      <ul v-if="!editMode" class="list-group list-group-flush">
        <li v-if="person.email.length > 0" class="list-group-item">📧 {{ person.email }}</li>
        <li class="list-group-item">
          <a href="#" class="btn btn-sm btn-primary" @click="editMode = true" >Edit</a>&nbsp;
          <a href="#" class="btn btn-sm btn-danger" @click="remove" >Delete</a>
        </li>
      </ul>
      <!-- edit mode stuff -->
      <div v-if="editMode" class="card-body">
        <div class="form-floating mb-3">
          <input type="text" class="form-control" v-model="person.name" />
          <label for="Name">Name</label>
        </div>
        <div class="form-floating mb-3">
          <input type="email" class="form-control" v-model="person.email" />
          <label for="Email">Email</label>
        </div>
        <a href="#" class="btn btn-sm btn-primary" @click="editMode = false" >Close</a>
      </div>
    </div>
</template>

<script lang="ts" >
import { Options, Vue } from 'vue-class-component'
import Person from '@/components/Person.vue'

@Options({
  props: {
    person: Person,
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
