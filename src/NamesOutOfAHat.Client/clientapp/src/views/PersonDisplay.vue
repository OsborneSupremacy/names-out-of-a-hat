<template>
    <div class="card mb-3" style="width: 18rem;display: inline-flex;margin: 10px;">
      <h5 class="card-header">{{ person.name }}</h5>
      <ul class="list-group list-group-flush">
        <li v-if="person.email.length > 0" class="list-group-item">📧 {{ person.email }}</li>
        <li class="list-group-item">
          <a href="#" class="btn btn-sm btn-primary">Edit</a>&nbsp;
          <a href="#" class="btn btn-sm btn-danger" @click="remove" >Delete</a>
        </li>
      </ul>
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
  methods: {
    remove () {
      this.removeFunction(this.person)
    }
  }
})
export default class PersonDisplay extends Vue {}
</script>
