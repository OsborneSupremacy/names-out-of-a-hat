<script lang="ts">
import { Options, Vue } from 'vue-class-component'

@Options({
  props: {
    id: String,
    name: String,
    email: String
  }
})
export default class Person extends Vue {
  id!: string
  name!: string
  email!: string
}
</script>
