<script lang="ts">
import { Options, Vue } from 'vue-class-component'

@Options({
  props: {
    id: String,
    name: String,
    email: String,
    phone: String
  }
})
export default class Person extends Vue {
  id!: string
  name!: string
  email!: string
  phone!: string
}
</script>
