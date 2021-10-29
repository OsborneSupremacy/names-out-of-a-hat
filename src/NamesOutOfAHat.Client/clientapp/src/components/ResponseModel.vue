<script lang="ts">
import { Options, Vue } from 'vue-class-component'

@Options({
  props: {
    success: Boolean,
    errors: [] as string[]
  }
})
export default class ResponseModel extends Vue {
  errors!: string[]
}
</script>
