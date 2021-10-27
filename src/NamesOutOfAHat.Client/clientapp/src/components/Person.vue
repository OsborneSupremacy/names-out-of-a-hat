<script lang="ts">
import { Options, Vue } from 'vue-class-component'

@Options({
  props: {
    name: String
  }
})
export default class Person extends Vue {
  name!: string
}
</script>
