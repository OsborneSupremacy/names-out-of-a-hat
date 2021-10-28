<script lang="ts">
import { Options, Vue } from 'vue-class-component'

@Options({
  props: {
    name: String,
    email: String,
    phone: String
  }
})
export default class Person extends Vue {
  name!: string
  email!: string
  phone!: string
}
</script>
