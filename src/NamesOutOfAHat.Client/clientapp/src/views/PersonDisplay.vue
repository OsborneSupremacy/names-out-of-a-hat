<template>
    <div class="card mb-3" style="width: 18rem;display: inline-flex;margin: 10px;">
        <div class="card-body">
            <h5 class="card-title">{{ person.name }}</h5>
            <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
            <a href="#" class="btn btn-primary">Go somewhere</a>
        </div>
    </div>
</template>

<script lang="ts" >
import { Options, Vue } from 'vue-class-component'
import Person from '@/components/Person.vue'

@Options({
  props: {
    person: Person
  }
})
export default class PersonDisplay extends Vue {}
</script>
