<template>
  <div class="form-floating mb-3">
      <input type="email" class="form-control" v-model="person.email" />
      <label for="Email">Email</label>
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
export default class EmailEdit extends Vue {}
</script>
