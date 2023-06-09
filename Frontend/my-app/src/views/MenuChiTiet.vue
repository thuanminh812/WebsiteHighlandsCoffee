<template>
    <div>
      <HomePage />
      <br>
    <br>
    <br>
      <div class="container" >
        <!-- <h2><router-link class="text-dark" to="/giohang"><i class="fa-solid fa-cart-shopping">{{ cartItems.length }}</i></router-link></h2> -->
        <div class="row">
        <div class="col-sm-5">
          <v-img :src="`${menu.hinhAnh}`"></v-img>
          </div>
          <div class="col-sm-5">
            <h1>{{ menu.tenSanPham }}</h1>
            <p class="text-left"> Mô tả sản phẩm: {{ menu.motaSanPham }}</p>
            <h5> Giá: {{ menu.giaBan }} ₫</h5>
            <br>
            <!-- <v-btn block variant="elevated" color="red" height="50px" @click="addCart([menu])">Đặt mua ngay</v-btn> -->
          </div>
        <br>
      </div>
      <hr>
      <h2>SẢN PHẨM KHÁC</h2>
    <swiper class="swiper"
    :modules="modules"
    :space-between="2"
    :slides-per-view="3"
    :pagination="{ clickable: true }">
    <swiper-slide v-for="menu in menus" v-bind:key="menu.menuId">   
      <v-card elevation="10" class="col-sm-9 m-5">
      <v-card-title>
        <a :href="'/menuchitiet/'+ menu.idSanPham" class="text-dark"><v-img class="card-image" :src="`${menu.hinhAnh}`"></v-img></a>
      </v-card-title>
      <v-card-text>
        <h4><a :href="'/menuchitiet/'+ menu.idSanPham" class="text-dark">{{menu.tenSanPham}}</a></h4>
        <h6><a :href="'/menuchitiet/'+ menu.idSanPham" class="text-dark">Giá: {{ formatCurrency(menu.giaBan) }}</a></h6>
      </v-card-text>
    </v-card></swiper-slide>   
    <div class="swiper-pagination" slot="pagination"></div>
  </swiper>
    </div>
      <br>
    </div>
  </template>
  
  <script>
  import axios from 'axios'
  import {Swiper,SwiperSlide} from 'vue-awesome-swiper'
  import HomePage from '../components/HomePage.vue'
import { Pagination } from 'swiper'
import 'swiper/css/pagination'
import 'swiper/css/navigation'
import 'swiper/swiper.css'
  export default {
      name:'MenuChiTiet',
      components:{
      Swiper,
      SwiperSlide,
    HomePage,
    },
    setup(){
      
      return {
      modules: [Pagination]
    }
    },
      data() {
      return {
        swiperOption: {
          slidesPerView: 3,
          spaceBetween: 30,
          pagination: {
            el: '.swiper-pagination',
            clickable: true
          }
        },
        menus:[],
        menu:{
        },
        cartItems:[]
      }
    },
    methods:{
        setMenu(data){
          this.menu = data
        },
        formatCurrency(value) {
      return value.toLocaleString("vi-VN", { style: "currency", currency: "VND" });
    },
        addCart(menu) {
    this.cartItems.push(...menu);
    localStorage.setItem("cartItems", JSON.stringify(this.cartItems) || '[]');

  },
    },
    created() {
      axios.get('https://localhost:7096/api/Menu/menuid/225d11e7-4697-42a6-41cd-08db64215b5e')
          .then(response=>{
              if(response.data){
                  this.menus = response.data
              }
          })
          .catch(e=>{
              console.log("lỗi",e)
          })
    },
    mounted() {
      axios.get("https://localhost:7096/api/Menu/"+this.$route.params.id)
      .then((response) => this.setMenu(response.data))
      .catch((error) => console.log(error));
      
    }
  }
  </script>
  
  <style>
  
  </style>