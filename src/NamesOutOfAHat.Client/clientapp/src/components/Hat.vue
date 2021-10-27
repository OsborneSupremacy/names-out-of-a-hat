<template>
    <div class="jumbotron">
        <h1 class="display-4">Put everyone's name in the hat!</h1>
    </div>

    <PersonDisplay v-for="person in people" :key="person.name" :person="person"/>
    <PersonAdd v-if="addingPerson" :person="personBeingAdded" :cancelFunction="cancelAdd" />

    <p v-if="!addingPerson" >
      <button type="button" @click="addPerson" class="btn btn-primary">Add Person</button>
    </p>
</template>

<script lang="ts">
import { Options, Vue } from 'vue-class-component'
import Person from '@/components/Person.vue'
import PersonDisplay from '@/views/PersonDisplay.vue'
import PersonAdd from '@/views/PersonAdd.vue'

@Options({
  components: {
    PersonDisplay,
    PersonAdd
  },
  data: () => ({
    addingPerson: Boolean(false),
    personBeingAdded: { name: '' } as Person,
    people: [
      { name: 'Bob' },
      { name: 'Sue' },
      { name: 'Mike' },
      { name: 'Sally' }
    ] as Person[]
  }),
  methods: {
    addPerson () {
      this.personBeingAdded = { name: 'xczc' } as Person
      this.addingPerson = true
    },
    cancelAdd: function () {
      this.addingPerson = false
    }
  }
})
export default class Hat extends Vue {
}

</script>
