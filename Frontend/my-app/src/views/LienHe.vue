<template>
  <div>
    <HomePage />
    <br>
    <br>
    <v-img src="../assets/banner4.jpg"></v-img>
    <br>
    <div class="container">
        <div class="row">
            <div class="col-sm-7">
        <h1 class="text-left">LIÊN HỆ</h1>
        <p class="text-left">Highlands Coffee® là không gian vui vẻ nên mọi thứ ở đây đều vì sự thoải mái của chúng ta.</p>
        <p class="text-left">Hãy chia sẻ với chúng tôi điều bạn mong muốn để cùng nhau giúp Highlands Coffee® của chúng tôi cải thiện hơn nhé.</p>
        <p class="text-left" style="font-weight: bold;">Gửi thông tin phản hồi tại:</p>
        <p class="text-left" style="font-weight: bold;">Facebook: <a class="text-info" href="https://www.facebook.com/highlandscoffeevietnam/">https://www.facebook.com/highlandscoffeevietnam/</a></p>
        <p class="text-left" style="font-weight: bold;">Email: customerservice@highlandscoffee.com.vn</p>
        <p class="text-left" style="font-weight: bold;">Hoặc bạn có thể gửi phản hồi trực tiếp theo liên kết dưới đây, chúng tôi sẽ cố gắng phản hồi sớm nhất: </p>
        </div>
        <div class="col-sm-5">
          <v-img src="../assets/dichvu.jpg"></v-img>
          <br>
          <v-img src="../assets/tuyendung.jpg"></v-img>
        </div>
    </div>
    <br>
    </div>
    <br>
  </div>
</template>

<script>
import HomePage from '../components/HomePage.vue'
export default {
  components: {
    HomePage,
  },
}
</script>

<style>

</style>