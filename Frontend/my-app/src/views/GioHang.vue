<template>
  <div>
    <HomePage />
    <br>
    <br>
    <br>
    <div class="container">
          <div>
            <div v-if="cartItems.length === 0">
             <h2> Giỏ hàng của bạn đang trống</h2>
            </div>
            <div v-else>
              <h2>Giỏ hàng của bạn</h2>
              <hr>
              <div v-for="item in cartItems" :key="item.idSanPham">
                <div class="row">
                  <div>
                        <v-img style="width:160px;height:160px" class="card-image" :src="`${item.hinhAnh}`"></v-img>
                        </div>
                        <div class="col-sm-7">
                        <h4>Tên sản phẩm: {{ item.tenSanPham }}</h4>
                        <h6>Số lượng: <button  @click="decreaseQuantity(item)"><i class="fa-regular fa-square-minus"></i></button>
                          {{ item.soLuong }}
                          <button  @click="increaseQuantity(item)"><i class="fa-regular fa-square-plus"></i></button></h6>
                          
                        <h5>Giá tiền: {{ formatCurrency(item.soLuong * item.giaBan) }}</h5>
                          
                      </div>
                      <div>
                        <v-btn color="red" @click="removeFromCart(item.idSanPham)"><i class="fa-solid fa-trash"></i></v-btn>
                      </div>
                </div>
                <hr>
              </div>
              <br>
              <div>
        <select v-model="paymentMethod">
          <option value="">Chọn hình thức thanh toán</option>
          <option value="Thanh toán khi nhận hàng (COD)">Thanh toán khi nhận hàng (COD)</option>
          <option value="QR code"> QR code</option>
          <!-- Thêm các tùy chọn hình thức thanh toán khác -->
        </select>
      </div>
            </div>
          </div>
          <div class="foot">
            <h2 v-if="cartItems.length !== 0" id="total">Tổng tiền: {{ formatCurrency(total) }}</h2>
            
            <v-btn class="m-2" v-if="cartItems.length !== 0" color="red" @click="clearCart()">Xóa tất cả <i class="fa-solid fa-trash"></i></v-btn> 
            <v-btn class="m-2" color="#808080"><router-link :to="`/donhangcuaban/${user.id}`" class="text-dark">Xem đơn hàng của bạn </router-link></v-btn> 
        <v-btn class="m-2" v-if="cartItems.length !== 0" color="green" @click="placeOrder">Đặt hàng <i class="fa-solid fa-check"></i></v-btn>
          </div>
          

        <!-- <div class="col-sm-5">
          <form @submit.prevent="placeOrder">
          <h3>Thông tin đơn hàng</h3>
          <h4>Địa chỉ: {{ user.diaChi }}</h4>
          <h4>Số điện thoại: {{ user.soDienThoai }}</h4>
          <h4>Tên của bạn: {{ user.name }}</h4>
          
        </form>
        </div> -->
       
      <br>
    </div>
  </div>
</template>

<script>
import axios from 'axios'
import HomePage from '../components/HomePage.vue'
import jwt_decode from 'jwt-decode'
export default {
  components: {
    HomePage,
  },
  data() {
    return {
      cartItems: [],
      showModal: false,
      menus: [],
      donhangs: [],
      paymentMethod: '',
      donhang: {
        id:'',
        userName: '',
        diaChi: '',
        soDienThoai: '',
        tongTien: 0,
        trangThai: 'Đơn hàng đang được duyệt'
      },
      chitietdonhangs: [],
      users:[],
      user:{
        id:'',
        name:'',
        diaChi:'',
        soDienThoai:''
      },
    }
  },
  computed: {
    total() {
      return this.cartItems.reduce((total, item) => total + item.giaBan * item.soLuong, 0);
    },
    currentUser() {
        return this.$store.state.auth.user;
      }
  },
  methods: {
    increaseQuantity(item) {
      item.soLuong++;
    },
    formatCurrency(value) {
      return value.toLocaleString("vi-VN", { style: "currency", currency: "VND" });
    },
    getTokenConfig(){
        var token = JSON.parse(localStorage.getItem('user'))
        const config = {
          headers: {Authorization : `Bearer ${token}`}
        };
        return config;
      },
    decreaseQuantity(item) {
      if (item.soLuong > 1) {
        item.soLuong--;
      } else {
        this.removeFromCart(item.idSanPham);
      }
    },
    
    removeFromCart(productId) {
      const index = this.cartItems.findIndex(item => item.idSanPham === productId);
      if (index !== -1) {
        this.cartItems.splice(index, 1);
        localStorage.removeItem('cartItems');
      }
    },
    decodeJwt(jwttoken){
              const decoded = jwt_decode(jwttoken);
              this.role = decoded.role;
              this.email = decoded.email;           
          },
    clearCart() {
      this.cartItems = [];
      localStorage.removeItem('cartItems');
    },
    async placeOrder() {
      if (this.paymentMethod === '') {
          // Hiển thị thông báo lỗi nếu chưa chọn hình thức thanh toán
          this.$swal.fire({
            icon: 'error',
            title: 'Lỗi!',
            text: 'Vui lòng chọn hình thức thanh toán',
          });
          return;
        }
      try {
        this.donhang.tongTien = this.total;
        this.donhang.id = this.user.id;
        this.donhang.userName = this.user.name; // Thêm thông tin tên người dùng
        this.donhang.diaChi = this.user.diaChi; // Thêm thông tin địa chỉ người dùng
        this.donhang.soDienThoai = this.user.soDienThoai; // Thêm thông tin số điện thoại người dùng
        this.donhang.paymentMethod = this.paymentMethod;
        const response = await axios.post('https://localhost:7096/api/DonHang', this.donhang);
        const idDonHang = response.data;
        for (const item of this.cartItems) {
          const chiTietDonHang = {
            idDonHang: idDonHang,
            idSanPham: item.idSanPham,
            hinhAnh: item.hinhAnh,
            soLuong: item.soLuong,
            tenSanPham: item.tenSanPham,
            giaBan: item.giaBan
          };
          await axios.post('https://localhost:7096/api/ChiTietDonHang', chiTietDonHang);
        }
        // Xóa giỏ hàng và đặt hàng thành công
        this.cartItems = [];
        this.donhang.userName = '';
        this.donhang.diaChi = '';
        this.donhang.soDienThoai = '';
        localStorage.removeItem('cartItems');
        this.$swal.fire('Đặt hàng thành công!', '', 'success');
      } catch (error) {
        console.error(error);
        localStorage.removeItem('cartItems');
        this.$swal.fire({
          icon: 'error',
          title: 'Lỗi!',
          text: 'Đặt hàng không thành công!'
        });
      }
    },
  },
  created() {
    const jwttoken = localStorage.getItem('user');
        this.decodeJwt(jwttoken);
    axios.get('https://localhost:7096/api/Menu')
      .then(response => {
        if (response.data) {
          this.menus = response.data;
        }
      })
      .catch(e => {
        console.log('Lỗi', e);
      });
      axios.get('https://localhost:7096/api/Account/user',this.getTokenConfig())
          .then(response=>{
              if(response.data){
                  this.user = response.data
              }
          })
          .catch(e=>{
              console.log("lỗi",e)
          })
  },
  mounted() {
    const cartItems = localStorage.getItem('cartItems');
    if (cartItems) {
      this.cartItems = JSON.parse(cartItems);
    }
    if (!this.currentUser) {
        this.$swal.fire('Bạn phải đăng nhập để đặt hàng!');
        this.$router.push('/login');
      }
      if (this.role != 'User') {
          this.$router.push('/');
        }
  }
}
</script>

<style>
.modal-mask {
  position: fixed;
  z-index: 9998;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background-color: rgba(0, 0, 0, 0.5);
  display: table;
  transition: opacity 0.3s ease;
}

.modal-wrapper {
  display: table-cell;
  vertical-align: middle;
}

.modal-container {
  width: 860px;
  margin: 0 auto;
  padding: 20px 30px;
  background-color: #fff;
  border-radius: 2px;
  box-shadow: 0 2px 8px rgba(0, 0, 0, 0.33);
  transition: all 0.3s ease;
  font-family: Helvetica, Arial, sans-serif;
}

.modal-enter {
  opacity: 0;
}

.modal-enter-active {
  opacity: 1;
}

.modal-leave {
  opacity: 1;
}

.modal-leave-active {
  opacity: 0;
}
</style>
