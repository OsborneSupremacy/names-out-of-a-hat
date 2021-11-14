<script lang="ts">
// utilities
import UUID from 'uuidjs'
// components
import Person from '@/components/Person.vue'
import Recipient from '@/components/Recipient.vue'
import Giver from '@/components/Giver.vue'

export default class GiverFactory {
  public create (person: Person, existingGivers: Giver[]): Giver {
    // create new giver
    person.id = UUID.generate()
    const newGiver = {
      id: person.id,
      person: person,
      recipients: [] as Recipient[]
    } as Giver
    // make existing givers recipients of new giver
    for (const giver of existingGivers) {
      newGiver.recipients.push({
        id: giver.id,
        person: giver.person,
        eligible: true
      } as Recipient)
    }
    return newGiver
  }
}
</script>
