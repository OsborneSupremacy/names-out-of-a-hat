<script lang="ts">
import { Options, Vue } from 'vue-class-component'
import Person from '@/components/Person.vue'
import Recipient from '@/components/Recipient.vue'

@Options({
  props: {
    person: {} as Person,
    recipients: [] as Recipient[]
  }
})
export default class Giver extends Vue {
  person!: Person
  recipients!: Recipient[]
}
</script>
