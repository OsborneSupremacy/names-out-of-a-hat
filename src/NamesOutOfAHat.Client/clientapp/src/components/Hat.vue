<template>
    <div class="jumbotron">
        <h1 class="display-4">Put everyone's name in the hat!</h1>
    </div>
    <span v-if="people.length === 0" >where are the people?</span>

    <PersonDisplay v-for="person in people" :key="person.name" v-bind:person="person"/>

    <p>
      <button type="button" @click="addPerson" class="btn btn-primary">Add Person</button>
    </p>
</template>

<script lang="ts">
import { Options, Vue } from 'vue-class-component'
import Person from '@/components/Person.vue'
import PersonDisplay from '@/views/PersonDisplay.vue'

@Options({
  components: {
    PersonDisplay
  },
  data: () => ({
    people: [
      { name: 'Bob' },
      { name: 'Sue' },
      { name: 'Mike' },
      { name: 'Sally' }
    ] as Person[]
  }),
  methods: {
    addPerson () {
      this.people.push({ name: 'Another Bob' } as Person)
    }
  }
})
export default class Hat extends Vue {
}

</script>
