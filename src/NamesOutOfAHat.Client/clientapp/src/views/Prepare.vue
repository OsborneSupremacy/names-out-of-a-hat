<template>
  <div>
    <h1>Prepare</h1>
    <div>
        <h2>Givers</h2>
        <GiverAdd />
        <p v-for="giver in hat.givers" :key="giver.id" >
          <GiverDisplay :giver="giver" />
        </p>
    </div>
    <button @click="addGiver">Add</button>
  </div>
</template>

<script lang="ts">
import { Options, Vue } from 'vue-class-component'
// utilities
import UUID from 'uuidjs'
// components
import HatModel from '@/components/HatModel.vue'
import Giver from '@/components/Giver.vue'
import Person from '@/components/Person.vue'
import Recipient from '@/components/Recipient.vue'
// views
import GiverDisplay from './GiverDisplay.vue'
import GiverAdd from './GiverAdd.vue'

@Options({
  components: {
    HatModel,
    GiverDisplay,
    GiverAdd
  },
  data: () => ({
    hat:
    {
      givers: [] as Giver[]
    } as HatModel
  }),
  methods: {
    addGiver () {
      const recipients = [] as Recipient[]
      /*
      make existing givers recipients of new giver
      */
      for (const giver of this.hat.givers) {
        recipients.push({
          id: giver.id,
          person: giver.person,
          eligible: true
        } as Recipient)
      }
      /*
      create new giver
      */
      const id = UUID.generate()
      const newGiver = {
        id: id,
        person: {
          id: id,
          name: 'Ben',
          email: 'osborne.ben@gmail.com'
        } as Person,
        recipients: recipients
      } as Giver
      /*
      add this giver to all other givers' recipient lists
      */
      for (const giver of this.hat.givers) {
        giver.recipients.push({
          id: newGiver.id,
          person: newGiver.person,
          eligible: true
        } as Recipient)
      }
      // add giver to the hat
      this.hat.givers.push(newGiver)
    }
  }
})
export default class Prepare extends Vue {
}

</script>
