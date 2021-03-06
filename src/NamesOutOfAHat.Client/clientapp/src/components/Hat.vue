<template>
  <div class="bg-light rounded-3" >
    <div class="container-fluid py-5" >
      <div class="jumbotron">
        <h1 class="display-5">Put everyone's name in the hat!</h1>
      </div>

      <PersonDisplay
        v-for="person in people"
        :key="person.id"
        :person="person"
        :people="people"
        :removeFunction="removePerson"
        />

      <PersonAdd
        v-if="addMode"
        :person="personBeingAdded"
        :commitFunction="commitAdd"
        :cancelFunction="cancelAdd"
        />

      <p v-if="!addMode" >
        <button type="button" @click="addPerson" class="btn btn-primary">Add a Name</button>
      </p>

      <div v-if="people.length === 0 && !addMode" class="alert alert-primary" role="alert">
        There currently aren't any names in the hat! Click the button below to add one.
      </div>

      <div v-if="people.length === 1 && !addMode" class="alert alert-primary" role="alert">
        There's one name in the hat so far. At at least two more for a valid gift exchange.
      </div>

      <div v-if="people.length === 2 && !addMode" class="alert alert-primary" role="alert">
        Great job, that's two names in the hat! Add one more for a valid gift exchange.
      </div>

      <div v-if="people.length >= 3 && !addMode" class="alert alert-primary" role="alert">
        You have {{ people.length }} names in the hat. That's enough for a gift exchange, but you can add more (up to {{ maxPeople }}). Once everyone's added. Click the <b>Shake Up The Hat</b> button below.
      </div>

      <div class="container-fluid py-5">
        <button type="button" @click="validateHat" class="btn btn-primary btn-lg">Shake Up The Hat</button>
      </div>

      <div v-if="hatIsInvalid" class="alert alert-danger" role="alert">
        <h4>There is a problem with the names in the hat.</h4>
        <ul v-if="hatIsInvalidReason.length > 0">
          <li v-for="error in hatIsInvalidReason" :key="error" >{{ error }}</li>
        </ul>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import { Options, Vue } from 'vue-class-component'
import Person from '@/components/Person.vue'
import PersonDisplay from '@/views/PersonDisplay.vue'
import PersonAdd from '@/views/PersonAdd.vue'
import UUID from 'uuidjs'
import ResponseModel from '@/components/ResponseModel.vue'

@Options({
  components: {
    PersonDisplay,
    PersonAdd
  },
  data: () => ({
    maxPeople: 30,
    hatIsInvalid: false,
    hatIsInvalidReason: [] as string[],
    addMode: Boolean(false),
    personBeingAdded: { } as Person,
    people: [] as Person[],
    baseUrl: 'https://localhost:5010' as string
  }),
  methods: {
    saveToLocal () {
      this.hatIsInvalid = false
      this.hatis = [] as string[]
      localStorage.setItem('nooah-people', JSON.stringify(this.people))
    },
    addPerson () {
      this.personBeingAdded = { id: UUID.generate(), name: '', email: '' } as Person
      this.addMode = true
    },
    commitAdd: function (person: Person) {
      this.people.push(person)
      this.addMode = false
      this.saveToLocal()
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
      this.saveToLocal()
    },
    validateHat: async function () {
      this.saveToLocal()

      const response = await fetch(`${this.baseUrl}/api/hat/validate`, {
        method: 'post',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(this.people)
      })

      if (!response.ok) {
        this.hatIsInvalid = true
        try {
          const responseModel : ResponseModel = await response.json()
          this.hatIsInvalidReason = responseModel.errors
        } catch (error) {
        }
      }
    }
  },
  mounted () {
    if (localStorage.getItem('nooah-people')) {
      try {
        this.people = (JSON.parse(localStorage.getItem('nooah-people') as string) as Person[])
      } catch (error) {
        console.log('Could not load people from local storage')
      }
    }
  }
})
export default class Hat extends Vue {
}

</script>
