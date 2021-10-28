<template>
  <div class="form-floating mb-3">
    <input type="text" class="form-control" v-model="person.name" />
    <label for="Name">Name</label>
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
export default class NameEdit extends Vue {}
</script>
