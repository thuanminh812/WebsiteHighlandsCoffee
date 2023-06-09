<template>
  <div>
    <HomePage />
    <br>
    <br>
    <br>
    <div class="container">
      <div class="row">
      <div class="col-sm-7">
        <h2 style="font-weight: bold;"> TIN TUYỂN DỤNG </h2>
      </div>     
      <div class="justify-content-end col-sm-5">
        <form action="" class="form-inline ">
<div class="form-group ">
    <label for="" style="font-size:20px;font-weight: bold;">Tìm kiếm:</label>
    <input placeholder="" type="text" class="form-control ml-2 mr-2" name="tim" v-model="search" >
</div>
</form>
      </div>
    </div>
        <hr>
    <div v-for="tintuc in filterTinTuc" v-bind:key="tintuc.tintucId">
      <router-link :to="{ name: 'tintucchitiet', params: {id: tintuc.id}}" class="text-dark">
        <div class="row">
      <div class="col-sm-3">
        <v-img :src="`${tintuc.hinhAnh}`"></v-img>
      </div>
			<div class="col-sm-6">
        <h4 style="font-weight: bold;">{{tintuc.tieuDe}}</h4>
			<p class="text-left"><i class="fa-regular fa-calendar"></i> Ngày đăng: {{ tintuc.ngayTao }}</p>
      <h6>{{ tintuc.linkUrl }}</h6>
			</div>
		</div></router-link>
    <br>
  </div>
</div>
<br>
  </div>
</template>

<script>
import axios from 'axios'
import HomePage from '../components/HomePage.vue'
export default {
    name:'TuyenDung',
    components: {
    HomePage,
  },
    data(){
        return{
          search:'',
            tintucs:[],
            length: 3,
            tintuc:{
          tieuDe:'',
          moTaTinTuc:'',
          ngayTao:''
        }
        }
    },
    mounted:function(){
        axios.get('https://localhost:7096/api/TinTuc/tintucid/eb4f5e5c-7fff-43b7-f480-08db64def9d1')
        .then(response=>{
            if(response.data){
                this.tintucs = response.data
            }
        })
        .catch(e=>{
            console.log("lỗi",e)
        })
    },

    created(){
    let id = this.$route.params.id
      if(id) {
          this.getTinTuc(id)
      }
  }, 
    methods: {
      getTinTuc(id) {
          axios.get(`https://localhost:7096/api/TinTuc/${id}`).then(response => {
              this.tintuc = response.data
          })
          
      },
    loadMore() {
      if (this.length > this.tintucs.length) return;
      this.length = this.length + 3;
    },
  },
  computed: {
    filterTinTuc:function(){
    return this.tintucs.filter((tintuc) => {
        return tintuc.tieuDe.toLowerCase().includes(this.search.toLowerCase()) ;
    });
}
  },
}
</script>

<style>

</style>