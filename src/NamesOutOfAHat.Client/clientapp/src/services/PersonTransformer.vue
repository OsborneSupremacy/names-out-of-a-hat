<script lang="ts">
import { Options, Vue } from 'vue-class-component'
import Person from '@/components/Person.vue'
import Recipient from '@/components/Recipient.vue'
import Giver from '@/components/Giver.vue'

@Options({
  methods: {
    transformToRecipients: function (people: Person[]) : Recipient[] {
      const recipients = [] as Recipient[]
      for (const person of people) {
        const recipient = { } as Recipient
        // consider recipient eligible by default
        recipient.eligible = true
        recipient.person = person
        recipients.push(recipient)
      }
      return recipients as Recipient[]
    },
    transformToGiver: function (person: Person, recipients: Recipient[]) : Giver {
      const giver = { } as Giver
      // TODO: exclude the giver from this list
      giver.recipients = recipients
      return giver
    }
  }
})

export default class PersonTransformer extends Vue {
}
</script>
