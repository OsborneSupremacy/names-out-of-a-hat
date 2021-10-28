<template>
  <div class="bg-light rounded-3" >
    <div class="container-fluid py-5" >
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
        v-if="addMode"
        :person="personBeingAdded"
        :commitFunction="commitAdd"
        :cancelFunction="cancelAdd"
        />

      <p v-if="!addMode" >
        <button type="button" @click="addPerson" class="btn btn-primary">Add Person</button>
      </p>
    </div>
  </div>

  <div class="container-fluid py-5" >
    <button type="button" @click="validateHat" class="btn btn-primary btn-lg">Shake Up The Hat</button>
  </div>
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
    addMode: Boolean(false),
    personBeingAdded: { id: UUID.generate(), name: '', email: '' } as Person,
    people: [
      { id: UUID.generate(), name: 'Bob', email: 'bob@gmail.com' },
      { id: UUID.generate(), name: 'Sue', email: '' },
      { id: UUID.generate(), name: 'Mike', email: 'mike@gmail.com' },
      { id: UUID.generate(), name: 'Sally', email: 'sally@gmail.com' }
    ] as Person[]
  }),
  methods: {
    addPerson () {
      this.personBeingAdded = { name: '', email: '' } as Person
      this.addMode = true
    },
    commitAdd: function (person: Person) {
      this.people.push(person)
      this.addMode = false
    },
    cancelAdd: function () {
      this.addMode = false
    },
    removePerson: function (person: Person) {
      const p2 : Person[] = this.people
      const foundPerson = p2.find((x: { id: string }) => x.id === person.id)
      if (foundPerson === null) {
        console.log('Person not found', foundPerson)
        return
      }
      p2.splice(p2.indexOf(foundPerson!), 1)
    },
    validateHat: async function () {
      const response = await fetch(`${window.location.origin}/api/hat/validate`, {
        method: 'post',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(this.people)
      })

      if (!response.ok) {
        const body = await response.text()
        console.log('Response not okay', body)
        return
      }

      console.log(response)
    }
  }
})
export default class Hat extends Vue {
}

</script>
