<template>
  <div >
    <HomePage />
    <br>
    <br>
<!-- <v-carousel hide-delimiter-background cycle="" show-arrows="hover">
  <v-carousel-item
    src="../assets/banner3.jpg"
    cover
  ></v-carousel-item>

  <v-carousel-item
    src="../assets/banner2.jpg"
    cover
  ></v-carousel-item>

  <v-carousel-item
    src="../assets/banner1.jpg"
    cover
  ></v-carousel-item>
</v-carousel> -->
<!-- <v-img style="width: 100%;height: 100%;" src="../assets/banner4.jpg"></v-img>  -->
<div id="menu2">
    <div class="container text-right">
      <h2 class=" text-white">Bắt đầu ngày mới của bạn với </h2>
        <h2 class=" text-white">một ly Coffee nhé!</h2>
      <v-btn color="white" variant="outlined"><router-link to="/menu">Khám phá menu</router-link></v-btn>
    </div> 
     
    </div>
<br>
<div class="container" style="max-width: 1400px;">

  <!-- <div class="row">
    <div class="col-sm-5">
      <v-img style="width: 100%;height: 380px;" src="../assets/a2.png"></v-img>      
    </div>

  </div> -->
  <br>
  <br>
  <div class="text-center">
  <h2>MENU NỔI BẬT CỦA CHÚNG TÔI</h2>
  <h5>Các sản phẩm được nhiều người yêu thích nhất!</h5>
</div>
    <swiper class="swiper"
    :modules="modules"
    :space-between="2"
    :slides-per-view="3"
    :pagination="{ clickable: true }">
    <swiper-slide v-for="menu in menus" v-bind:key="menu.menuId"> 
      <router-link :to="{ name: 'menuchitiet', params: {id: menu.idSanPham}}" class="text-dark">
        <v-card elevation="10" class="col-sm-9 m-5">
      <v-card-title>
        <v-img class="card-image1" :src="`${menu.hinhAnh}`"></v-img>
      </v-card-title>
      <v-card-text>
        <h4 style="font-weight: bold;">{{menu.tenSanPham}}</h4>
        <h6 style="font-weight: bold;">Giá: {{ formatCurrency(menu.giaBan) }} </h6>
      </v-card-text>
    </v-card></router-link>  
</swiper-slide>   
    <div class="swiper-pagination" slot="pagination"></div>
  </swiper>
</div>
  <br>
  <!-- <v-img src="../assets/banner4.jpg"></v-img> -->
  <div id="freewifi">
    <div class="row text-center text-white">
    <div class="col-sm-4">
      <h1><i class="fa-solid fa-wifi"></i></h1>
      <h4 >Wifi miễn phí</h4>
      <h5>Tốc độ cao, miễn phí truy cập</h5>
    </div>
    <div class="col-sm-4">
      <h1><i class="fa-sharp fa-solid fa-store"></i></h1>
      <h4>Phục vụ tại chỗ</h4>
      <h5>Tiện lợi với khách hàng</h5>
    </div>
    <div class="col-sm-4">
      <h1><i class="fa-solid fa-face-smile"></i></h1>
      <h4>Thân thiện</h4>
      <h5>Thái độ nhiệt tình, vui vẻ, cởi mở </h5>
    </div>
  </div>
  </div>
  <div class="container">
    <h2 class="text-center">Đánh giá từ khách hàng</h2>
<v-carousel hide-delimiter-background cycle="">
  <v-carousel-item v-for="phanhoi in phanhois" v-bind:key="phanhoi.id" class="danhgia"> 
    <div style="margin-top: 5%" >
      <v-img class="imgres" src="../assets/guest.png"></v-img>
    <!-- <h1><i class="fa-solid fa-user"></i></h1> -->
    <h3 style="font-weight: bold;color:#528b8b" class="text-center">{{ phanhoi.hoTen }}</h3>
    <br>
    <br>
      <h5 class="text-center textph">"{{ phanhoi.noiDung }}"</h5>
      </div>
    
  </v-carousel-item>

</v-carousel>
</div>
<div id="menu3" class="text-white text-center">
  <h1>Chúng tôi mở cửa từ</h1>
<h2 class="text-white">07:00 - 22:00</h2>
<h5>Vào các ngày trong tuần, tại mọi chi nhánh</h5>
<v-btn color="white" variant="outlined"><router-link to="/cuahang">Xem vị trí cửa hàng</router-link></v-btn>
</div>
<br>
<div class="container">
<div class="row">
<div class="col-sm-5" style="border-right:1px solid #c9cbd0">
  <h2>Gửi phản hồi của bạn tại đây</h2>
  <form @submit.prevent="save()">
<div class="form-group">
  <label for="name">Email</label>
  <input type="text" class="form-control" id="name" v-model="phanhoi.email">
</div>
<div class="form-group">
  <label for="name">Họ tên</label>
  <input type="text" class="form-control" id="name" v-model="phanhoi.hoTen">
</div>
<div class="form-group">
  <label for="name">Số điện thoại</label>
  <input type="text" class="form-control" id="name" v-model="phanhoi.soDienThoai">
</div>
<div class="form-group">
  <label for="name">Nội dung</label>
  <textarea style="resize: none; width: 100%;
  height: 150px;box-sizing: border-box;"  class="form-control" required v-model="phanhoi.noiDung"></textarea>
</div>
<v-btn type="submit" color="black">Gửi phản hồi</v-btn>
</form>
</div>
<div class="col-sm-7">
<h2>Tin tức</h2>
<div id="scroll">
<div class="row" v-for="tintuc in tintucs" v-bind:key="tintuc.id">
  <router-link :to="{ name: 'tintucchitiet', params: {id: tintuc.id}}" class="text-dark col-sm-3">
			<v-img :src="`${tintuc.hinhAnh}`" class="col-sm-3"></v-img>
    </router-link>
			<div class="col-sm-9">
        <router-link :to="{ name: 'tintucchitiet', params: {id: tintuc.id}}" class="text-dark">
			<h5 style="font-weight: bold;color:#444444">{{ tintuc.tieuDe }}</h5>
			<h6><i class="fa-regular fa-calendar"></i> Ngày đăng: {{ tintuc.ngayTao }}</h6>
			<h6>{{ tintuc.linkUrl }}</h6>

    </router-link>
    <hr>
			</div>
    
		</div>
  </div>
</div>
</div>
</div>
<br>
  </div>
</template>
<script>
import axios from 'axios'
import moment from 'moment'
import {Swiper,SwiperSlide} from 'vue-awesome-swiper'
import HomePage from '../components/HomePage.vue'
import { Pagination } from 'swiper'
import 'swiper/css/pagination'
import 'swiper/css/navigation'
import 'swiper/swiper.css'
  export default {
    name:'TrangChu',
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
        tintucs:[],
        phanhois:[],
        menu:{
          tenSanPham: '',
          giaBan: '',
          moTaSanPham: '',
        },
        tintuc:{
          tieuDe:'',
          moTaTinTuc:'',
          ngayTao:''
        },
        phanhoi:{
          email:'',
          hoTen:'',
          soDienThoai:'',
          noiDung:''
        }
      }
    },
    methods:{
      save(){
        axios.post('https://localhost:7096/api/PhanHoi',this.phanhoi).then(response => {
              if(response.data){
                this.$swal.fire('Gửi thành công','','success')
              }
          })
          .catch(e=>{
      console.log("lỗi",e)
          })
      },
      formatCurrency(value) {
      return value.toLocaleString("vi-VN", { style: "currency", currency: "VND" });
    },
    },
    created(){
        axios.get('https://localhost:7096/api/Menu/menuid/225d11e7-4697-42a6-41cd-08db64215b5e')
        .then(response=>{
            if(response.data){
                this.menus = response.data
            }
        })
        .catch(e=>{
            console.log("lỗi",e)
        })
        axios.get('https://localhost:7096/api/TinTuc')
        .then(response=>{
            if(response.data){
                this.tintucs = response.data
            }
        })
        .catch(e=>{
            console.log("lỗi",e)
        })
        axios.get('https://localhost:7096/api/PhanHoi')
        .then(response=>{
            if(response.data){
                this.phanhois = response.data
            }
        })
        .catch(e=>{
            console.log("lỗi",e)
        })
    },
    computed:{
      formatDate(){
        if(this.tintuc.ngayTao) {
          return moment(this.tintuc.ngayTao).format('DD/MM/YYYY')
        }
        return '';
      }
    }
  }
</script>

<style>
@import url('https://fonts.googleapis.com/css2?family=Roboto+Slab&display=swap');
body {
    background: #D0D8DB;
    font-family: 'Roboto Slab', serif;  
}
.textph{
  font-size: 20px;
}
.imgres{
  width:80px;
  height: 80px;
  margin-left: 46.5%;
}
p{
  font-family: 'Roboto Slab', serif;
}
#menu2{
  background-size: cover;
  padding-top: 250px;
  padding-bottom: 450px;
  background-repeat: no-repeat;
  background: linear-gradient(rgba(0,0,0,0.6),rgba(0,0,0,0.3)),url(../assets/bg-image.jpeg);
}
#menu3{
  background-size: cover;
  padding-top: 200px;
  padding-bottom: 250px;
  background-repeat: no-repeat;
  background: linear-gradient(rgba(0,0,0,0.6),rgba(0,0,0,0.3)),url(../assets/bg2.jpg);
}
#freewifi{
  background-size: cover;
  padding-top: 250px;
  padding-bottom: 250px;
  background-repeat: no-repeat;
  background: linear-gradient(rgba(0,0,0,0.6),rgba(0,0,0,0.3)),url(../assets/banner4.jpg);
}
.tin{
            width:100%;
            height:500px;
            overflow-x:hidden;
            overflow-y:auto;
}
.welcome{
  text-align: center;
}
h2{
  font-family: 'Roboto Slab', serif;
  font-weight: bold;
  color:#8b4513
}
h3{
  position: relative;
  color: #000;
  font-family: 'Roboto Slab', serif;
}
#scroll{
            height:502px;
            overflow-x:hidden;
            overflow-y:auto;
}
#hover1:hover{
  color: #bb0000;
}
.imgcar{
 width: 100%;
 border-radius: 20px;
}
#hover {
  --c:linear-gradient(#e1d2d2 0 0); /* update the color here */
  
  padding-bottom: .15em;
  background: var(--c), var(--c);
  background-size: .3em .1em;
  background-position:50% 100%;
  background-repeat: no-repeat;
  transition: .3s linear, background-size .3s .2s linear;
}
#hover:hover {
  background-size: 40% .1em;
  background-position: 10% 100%, 90% 100%;
}

#title{
  font-family: 'Roboto Slab', serif;
      font-size: 30px;
      font-weight: bold;
      color: #555555;
}
.card-image{
  width: 400px;
  height: 220px;
  object-fit: cover;
}
footer{
  background-color: #000000D9; 
}
#card-image1{
  width: 100%;
  height: 100px;
}
a{
  font-family: 'Roboto Slab', serif;
  font-weight: bold;
  color: white;
}
a:hover{
  text-decoration: none;
  color: white;
}
textarea {
    resize: none;
}
.text {
  color: white;
  font-size: 20px;
  position: absolute;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
  -ms-transform: translate(-50%, -50%);
  white-space: nowrap;
  font-family: 'Roboto Slab', serif;
}

.svg-inline--fa {
  vertical-align: -0.200em;
}

.rounded-social-buttons {
  text-align: center;
  padding: 10px;
}
.rounded-social-buttons .social-button {
  display: inline-block;
  position: relative;
  cursor: pointer;
  width: 3.125rem;
  height: 3.125rem;
  border: 0.125rem solid transparent;
  padding: 0;
  text-decoration: none;
  text-align: center;
  color: #fefefe;
  font-size: 1.5625rem;
  font-weight: normal;
  line-height: 2em;
  border-radius: 1.6875rem;
  transition: all 0.5s ease;
  margin-right: 0.25rem;
  margin-bottom: 0.25rem;
}

.rounded-social-buttons .social-button:hover, .rounded-social-buttons .social-button:focus {
  -webkit-transform: rotate(360deg);
      -ms-transform: rotate(360deg);
          transform: rotate(360deg);
}

.rounded-social-buttons .fa-twitter, .fa-facebook-f, .fa-linkedin, .fa-youtube, .fa-instagram {
  font-size: 25px;
}

.rounded-social-buttons .social-button.facebook {
  background: #3b5998;
}

.rounded-social-buttons .social-button.facebook:hover, .rounded-social-buttons .social-button.facebook:focus {
  color: #3b5998;
  background: #fefefe;
  border-color: #3b5998;
}

.rounded-social-buttons .social-button.twitter {
  background: #55acee;
}

.rounded-social-buttons .social-button.twitter:hover, .rounded-social-buttons .social-button.twitter:focus {
  color: #55acee;
  background: #fefefe;
  border-color: #55acee;
}

.rounded-social-buttons .social-button.linkedin {
  background: #007bb5;
}

.rounded-social-buttons .social-button.linkedin:hover, .rounded-social-buttons .social-button.linkedin:focus {
  color: #007bb5;
  background: #fefefe;
  border-color: #007bb5;
}

.rounded-social-buttons .social-button.youtube {
  background: #bb0000;
}

.rounded-social-buttons .social-button.youtube:hover, .rounded-social-buttons .social-button.youtube:focus {
  color: #bb0000;
  background: #fefefe;
  border-color: #bb0000;
}

.rounded-social-buttons .social-button.instagram {
  background: #125688;
}

.rounded-social-buttons .social-button.instagram:hover, .rounded-social-buttons .social-button.instagram:focus {
  color: #125688;
  background: #fefefe;
  border-color: #125688;
}
p{
  font-family: sans-serif;
  color:#555555;
  text-align: center;
  
}
#menu1{
  height: 350px;
  justify-content: center;
  align-items: center;
  flex-direction: column;
  display: flex;
}

</style>