<template>
    <div class="card mb-3" style="width: 18rem;display: inline-flex;margin: 10px;">
        <h5 v-if="person.name.trim().length === 0" class="card-header">Add Person</h5>
        <h5 v-if="person.name.trim().length > 0" class="card-header">{{ person.name }}</h5>
        <div class="card-body">
            <NameEdit :person="person" />
            <EmailEdit :person="person" />
            <button type="submit" class="btn btn-sm btn-primary" @click="commit" >Add</button>&nbsp;
            <a href="#" class="btn btn-sm btn-danger" @click="cancel" >Cancel</a>
        </div>
    </div>
</template>

<script lang="ts" >
import { Options, Vue } from 'vue-class-component'
import Person from '@/components/Person.vue'
import NameEdit from '@/views/NameEdit.vue'
import EmailEdit from '@/views/EmailEdit.vue'

@Options({
  components: {
    NameEdit,
    EmailEdit
  },
  props: {
    person: Person,
    cancelFunction: () => Boolean,
    commitFunction: (person: Person) => Boolean
  },
  methods: {
    cancel () {
      this.cancelFunction()
    },
    commit () {
      this.commitFunction(this.person)
    }
  }
})
export default class PersonAdd extends Vue {}
</script>
