<template>
    <div class="card mb-3" style="width: 18rem;display: inline-flex;margin: 10px;">
        <h5 v-if="giver.person.name.trim().length === 0" class="card-header bg-info">Add Participant</h5>
        <h5 v-if="giver.person.name.trim().length > 0" class="card-header bg-info">{{ giver.person.name }}</h5>
        <div class="card-body">
          <NameEdit :person="giver.person" />
          <EmailEdit :person="giver.person" />
          <button type="submit" class="btn btn-sm btn-primary" @click="add" >Add</button>&nbsp;
          <a href="#" class="btn btn-sm btn-danger" @click="cancel" >Cancel</a>
        </div>
    </div>
</template>

<script lang="ts" >
import { Options, Vue } from 'vue-class-component'
// components
// import GiverFactory from '@/services/GiverFactory.vue'
import Giver from '@/components/Giver.vue'
import Person from '@/components/Person.vue'
import NameEdit from '@/views/NameEdit.vue'
import EmailEdit from '@/views/EmailEdit.vue'

@Options({
  components: {
    NameEdit,
    EmailEdit
  },
  props: {
    giverAdded: (giver: Giver) => Boolean,
    canceled: () => Boolean
  },
  data: () => ({
    giver: {
      person: { id: '', name: '', email: '' } as Person
    } as Giver
  }),
  methods: {
    add () {
      // const giverFactory = new GiverFactory()
      // this.giver = giverFactory.create(this.giver.person, [])
      // console.log(this.giver)
      this.giverAdded(this.giver)
    },
    cancel () {
      this.cancel()
    }
  }
})
export default class GiverAdd extends Vue {}
</script>
