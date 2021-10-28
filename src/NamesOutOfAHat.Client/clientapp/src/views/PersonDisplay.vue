<template>
    <div class="card mb-3" style="width: 18rem;display: inline-flex;margin: 10px;">
      <h5 class="card-header">{{ person.name }}</h5>
      <ul class="list-group list-group-flush">
        <li v-if="person.email.length > 0" class="list-group-item">📧 {{ person.email }}</li>
        <li v-if="person.phone.length > 0" class="list-group-item">📱 {{ person.phone }}</li>
      </ul>
      <div class="card-body">
        <a href="#" class="btn btn-primary">Go somewhere</a>
      </div>
    </div>
</template>

<script lang="ts" >
import { Options, Vue } from 'vue-class-component'
import Person from '@/components/Person.vue'

@Options({
  props: {
    person: Person
  }
})
export default class PersonDisplay extends Vue {}
</script>
