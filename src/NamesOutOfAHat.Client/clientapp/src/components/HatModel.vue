<script lang="ts">
import { Options, Vue } from 'vue-class-component'
import Giver from './Giver.vue'

@Options({
  components: {
    Giver
  },
  props: {
    givers: [] as Giver[]
  }
})
export default class HatModel extends Vue {
  givers!: Giver[]
}
</script>
