<template>
  <v-app>
    <v-main>      
      <router-view/>
    </v-main>
    <FooterHighland />
  </v-app>
</template>

<script>
import FooterHighland from './components/FooterHigh.vue'
export default {
  name: 'App',
  components:{
    FooterHighland
  },
  data: () => ({
    //
  }),
  
}
</script>
<style>

</style>
