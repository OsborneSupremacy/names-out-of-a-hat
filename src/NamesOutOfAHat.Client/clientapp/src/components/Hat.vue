<template>
    <div class="jumbotron">
        <h1 class="display-4">Put everyone's name in the hat!</h1>
    </div>

    <PersonDisplay v-for="person in people" :key="person.name" :person="person"/>
    <PersonAdd v-if="addingPerson" :person="personBeingAdded" :commitFunction="commitAdd" :cancelFunction="cancelAdd" />

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
      { name: 'Bob', email: 'bob@gmail.com', phone: '111-111-1111' },
      { name: 'Sue', email: '', phone: '222-111-1111' },
      { name: 'Mike', email: 'mike@gmail.com', phone: '' },
      { name: 'Sally', email: 'sally@gmail.com', phone: '444-111-1111' }
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
    }
  }
})
export default class Hat extends Vue {
}

</script>
