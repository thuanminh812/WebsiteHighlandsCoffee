<template>
  <div>
    <HomePage />
    <br>
    <br>
    <br>
    <div class="container">
      <h2 style="font-weight: bold;">Tìm quán cà phê</h2>
        <div class="row">
          <div class="form-group col-sm-2">
            <v-menu>
        <template v-slot:activator="{ props }">
          <v-btn
            color="primary"
            v-bind="props"
          >
            Khu vực
          </v-btn>
        </template>
        <v-list>
          <v-list-item
            v-for="khuvuc in khuvucs"
            v-bind:key="khuvuc.idKhuVuc"
          >
          <a :href="'/cuahangbykv/'+ khuvuc.idKhuVuc" class="text-dark"><v-list-item-title>{{ khuvuc.tenKhuVuc }}</v-list-item-title></a>
          </v-list-item>
        </v-list>
      </v-menu>
		</div>
    <div class="form-group col-sm-5">
    <input placeholder="Tìm kiếm cụ thể" type="text" class="form-control ml-2 mr-2" name="tim" v-model="search" >
</div>
        </div>
        <h4 style="font-weight: bold;">Tất cả cửa hàng</h4>
      <div class="row justify-content-center">
    <v-card elevation="10" v-for="cuahang in fillterCuaHang" v-bind:key="cuahang.id" class="col-sm-4 m-4">
          <v-card-title>
            <v-img :src="`${cuahang.hinhAnh}`" cover class="col-sm-3"></v-img>
      </v-card-title>
      <v-card-text>
        <h5>{{ cuahang.tenCuaHang }}</h5>
        <h6><i class="fa-solid fa-location-dot"></i> {{ cuahang.diaChi }}</h6>
        <h6><i class="fa-solid fa-clock"></i> Mở cửa: 07:00 - 22:00</h6>
        <v-btn block color="black"><a :href="`${cuahang.linkBanDo}`">Xem bản đồ</a></v-btn>
      </v-card-text>
    </v-card>
    </div>
    </div>
    <br>
  </div>
</template>

<script>
import axios from 'axios'
import HomePage from '../components/HomePage.vue'
export default {
  components: {
    HomePage,
  },
 data(){
    return{
      cuahangs:[],
      khuvucs:[],
      length:4,
      search:'',
      linkURL:'',
      showMenu: false
    }
 },
 created(){
  axios.get('https://localhost:7096/api/CuaHang')
        .then(response=>{
            if(response.data){
                this.cuahangs = response.data
            }
        })
        .catch(e=>{
            console.log("lỗi",e)
        })
        axios.get('https://localhost:7096/api/KhuVuc')
        .then(response=>{
            if(response.data){
                this.khuvucs = response.data
            }
        })
        .catch(e=>{
            console.log("lỗi",e)
        })
 },
 methods:{
  loadMore() {
      if (this.length > this.menus.length) return;
      this.length = this.length + 2;
    },
 },
 computed: {
  fillterCuaHang:function(){
    return this.cuahangs.filter((cuahang) => {
        return cuahang.tenCuaHang.toLowerCase().includes(this.search.toLowerCase()) | cuahang.diaChi.toLowerCase().includes(this.search.toLowerCase());
    });
},
companiesLoaded() {
      return this.cuahangs.slice(0, this.length);
    },

    }
}
</script>

<style>

</style>