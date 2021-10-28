<template>
    <div class="jumbotron">
        <h1 class="display-4">Put everyone's name in the hat!</h1>
    </div>

    <PersonDisplay
      v-for="person in people"
      :key="person.id"
      :person="person"
      :removeFunction="removePerson"
      />

    <PersonAdd
      v-if="addingPerson"
      :person="personBeingAdded"
      :commitFunction="commitAdd"
      :cancelFunction="cancelAdd"
      />

    <p v-if="!addingPerson" >
      <button type="button" @click="addPerson" class="btn btn-primary">Add Person</button>
    </p>
</template>

<script lang="ts">
import { Options, Vue } from 'vue-class-component'
import Person from '@/components/Person.vue'
import PersonDisplay from '@/views/PersonDisplay.vue'
import PersonAdd from '@/views/PersonAdd.vue'
import UUID from 'uuidjs'

@Options({
  components: {
    PersonDisplay,
    PersonAdd
  },
  data: () => ({
    addingPerson: Boolean(false),
    personBeingAdded: { id: UUID.generate(), name: '' } as Person,
    people: [
      { id: UUID.generate(), name: 'Bob', email: 'bob@gmail.com', phone: '111-111-1111' },
      { id: UUID.generate(), name: 'Sue', email: '', phone: '222-111-1111' },
      { id: UUID.generate(), name: 'Mike', email: 'mike@gmail.com', phone: '' },
      { id: UUID.generate(), name: 'Sally', email: 'sally@gmail.com', phone: '444-111-1111' }
    ] as Person[]
  }),
  methods: {
    addPerson () {
      this.personBeingAdded = { name: '', email: '', phone: '' } as Person
      this.addingPerson = true
    },
    commitAdd: function (person: Person) {
      this.people.push(person)
      this.addingPerson = false
    },
    cancelAdd: function () {
      this.addingPerson = false
    },
    removePerson: function (person: Person) {
      const p2 : Person[] = this.people
      const foundPerson = p2.find((x: { id: string }) => x.id === person.id)
      if (foundPerson === null) {
        console.log('Person not found', foundPerson)
        return
      }
      p2.splice(p2.indexOf(foundPerson!), 1)
    }
  }
})
export default class Hat extends Vue {
}

</script>
