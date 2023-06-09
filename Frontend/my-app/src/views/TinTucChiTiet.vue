<template>
  <div>
    <HomePage />
    <br>
    <br>
    <br>
    <div class="container" >
      <div class="row">
      <div class="col-sm-7" style="border-right: 1px solid #ddd3d3;">
        <h2><strong>{{ tintuc.tieuDe }}</strong></h2>
        <p class="text-left"><i class="fa-regular fa-calendar"></i> Ngày đăng: {{ tintuc.ngayTao }}</p>
        <v-img :src="`${tintuc.hinhAnh}`"></v-img>
        <br>
        <h5>{{ tintuc.motaTinTuc }}</h5>
      </div>
      <br>
      <div class="col-sm-5">
        <h3 style="font-weight:bold">Tin tức khác</h3>
        <div v-for="tintuc in tintucs" v-bind:key="tintuc.tintucId">
          <a :href="'/tintuc/'+ tintuc.id" class="text-dark">
            <div class=" row">
      <div class="col-sm-4">
        <v-img :src="`${tintuc.hinhAnh}`"></v-img>
      </div>
			<div class="col-sm-8">
			<h5 style="font-weight: bold;color:#444444">{{tintuc.tieuDe}}</h5>
			<p class="text-left"><i class="fa-regular fa-calendar"></i> Ngày đăng: {{ tintuc.ngayTao }}</p>
			</div>
		</div></a>
    <br>
  </div>
      </div>
    </div>
		</div>
    <br>
  </div>
</template>

<script>
import axios from 'axios'
import HomePage from '../components/HomePage.vue'
export default {
    name:'TinTucChiTiet',
    components: {
    HomePage,
  },
    data() {
    return {
      tintucs:[],
      tintuc:{
      }
    }
  },
  methods:{
      setTinTuc(data){
        this.tintuc = data
      }
  },
  created() {
    axios.get('https://localhost:7096/api/TinTuc')
        .then(response=>{
            if(response.data){
                this.tintucs = response.data
            }
        })
        .catch(e=>{
            console.log("lỗi",e)
        })
  },
  mounted() {
    axios.get("https://localhost:7096/api/TinTuc/"+this.$route.params.id)
    .then((response) => this.setTinTuc(response.data))
    .catch((error) => console.log(error));
  }
}
</script>

<style>

</style>