<template>
  <div>
    <HomePage />
    <br>
    <br>
    <v-img src="../assets/banner1.jpg"></v-img>
    <br>
    <div class="container">
        <div class="row">
            <div class="col-sm-7">
        <h1 class="text-left">GIỚI THIỆU</h1>
        <p class="text-left">Highlands Coffee® được thành lập vào năm 1999, bắt nguồn từ tình yêu dành cho đất Việt cùng với cà phê và cộng đồng nơi đây. Tinh thần cộng đồng luôn chảy trong ADN của mỗi người Việt mình. Ngay từ những ngày đầu tiên, mục tiêu của chúng mình là có thể phục vụ và góp phần phát triển cộng đồng bằng cách siết chặt thêm sự kết nối và sự gắn bó giữa người với người. Ngày hôm nay, với hàng trăm cửa hàng trên khắp Việt Nam và trên Thế Giới, thứ chúng mình đem lại không chỉ dừng lại ở cà phê. Chúng mình còn là nơi để thuộc về, là nơi để kết nối tất cả mọi người với nhau. Từ đó, Highlands Coffee® trở thành nơi dành riêng cho cộng đồng.</p>
        <p class="text-left">Trong tương lai, chúng mình sẽ luôn thấy một Việt Nam đang phát triển và một Highlands Coffee® không ngừng cải tiến. Highlands Coffee® - điểm tụ họp của cộng đồng, nơi mọi người có thể kết nối và gắn kết với nhau bằng tình yêu dành cho cà phê, trà và các món ăn ngon. Tại Highlands Coffee®, chúng mình luôn sát cánh cùng bạn, chúng mình luôn ủng hộ bạn và chúng mình luôn đồng hành với nhau như một cộng đồng.</p>
        <p class="text-left" style="font-weight: bold;">Highlands Coffee® Là Của Chúng Mình.</p>
        </div>
        <div class="col-sm-5">
          <v-img src="../assets/tuyendung.jpg"></v-img>
          <br>
          <v-img src="../assets/dichvu.jpg"></v-img>
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