<script lang="ts">
import { Options, Vue } from 'vue-class-component'
import Person from '@/components/Person.vue'

@Options({
  props: {
    person: Person,
    eligible: Boolean
  }
})
export default class Recipient extends Vue {
  person!: Person
  eligible!: boolean
}
</script>
