<template>
    <Hat />
</template>

<script lang="ts">
import { Options, Vue } from 'vue-class-component'
import Hat from '@/components/Hat.vue'

@Options({
  components: {
    Hat
  }
})
export default class Home extends Vue {}
</script>
