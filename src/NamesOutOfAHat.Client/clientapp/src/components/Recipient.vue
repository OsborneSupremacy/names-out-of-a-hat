<script lang="ts">
import { Options, Vue } from 'vue-class-component'
import Person from '@/components/Person.vue'

@Options({
  props: {
    id: String,
    person: Person,
    eligible: Boolean
  }
})
export default class Recipient extends Vue {
  id!: string
  person!: Person
  eligible!: boolean
}
</script>
