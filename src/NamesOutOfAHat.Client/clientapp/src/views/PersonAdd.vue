<template>
    <div class="card" style="width: 18rem;display: inline-flex;margin: 10px;">

        <div class="card-body">
            <h5 class="card-title">Card title - {{ person.name }}</h5>

            <div class="form-floating mb-3">
                <input type="text" class="form-control" :value="person.name" />
                <label for="Name">Name</label>
            </div>

            <div class="form-floating mb-3">
                <input type="email" class="form-control" />
                <label for="Email">Email</label>
            </div>

            <div class="form-floating mb-3">
                <input type="tel" class="form-control" />
                <label for="Phone">Phone</label>
            </div>

            <a href="#" class="btn btn-primary">Add</a>&nbsp;
            <a href="#" class="btn btn-danger" @click="cancel" >Cancel</a>

        </div>

    </div>

</template>

<script lang="ts" >
import { Options, Vue } from 'vue-class-component'
import Person from '@/components/Person.vue'

@Options({
  props: {
    person: Person,
    cancelFunction: () => Boolean
  },
  methods: {
    cancel () {
      this.cancelFunction()
    }
  }
})
export default class PersonAdd extends Vue {}
</script>
