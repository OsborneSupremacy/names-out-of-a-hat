<script lang="ts">
import { Options, Vue } from 'vue-class-component'
import Person from '@/components/Person.vue'
import Recipient from '@/components/Recipient.vue'

@Options({
  props: {
    id: String,
    person: {} as Person,
    recipients: [] as Recipient[]
  }
})
export default class Giver extends Vue {
  id!: string
  person!: Person
  recipients!: Recipient[]
}
</script>
