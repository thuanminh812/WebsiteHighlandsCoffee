<template>
  <div>
    <HomePage />
    <br>
    <br>
    <br>
    <div class="container">
      <!-- Danh sách đơn hàng -->
      <div v-if="donhangs.length === 0">
        <h3 class="text-center">Không có đơn hàng nào.</h3>
      </div>

      <div v-else>
        <h3>Danh sách đơn hàng</h3>
        <table class="table table-bordered table-hover" style="text-align:center">
          <thead class="thead-light">
            <tr>
              <th>STT</th>
              <th>Mã đơn hàng</th>
              <th>Tổng tiền</th>
              <th>Hình thức thanh toán</th>
              <th>Trạng thái</th>
              <th>Thao tác</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="(donhang, index) in donhangs" :key="donhang.id">
              <td>{{ index + 1 }}</td>
              <td>{{ donhang.idDonHang }}</td>
              <td>{{ formatCurrency(donhang.tongTien) }}</td>
              <td>{{ donhang.payMentMethod }}</td>
              <td>{{ donhang.trangThai }}</td>
              <td>
                <v-btn class="m-1" color="red" @click="onDelete(donhang.idDonHang)" v-if="donhang.trangThai !== 'Đã duyệt, đang giao hàng'">Hủy</v-btn>
                <v-btn class="m-1" color="green" @click="onNhanHang(donhang.idDonHang)" v-else>Đã nhận hàng <i class="fa-solid fa-check"></i></v-btn>
                <button @click="getChiTietDonHangs(donhang.idDonHang), showModal = true" class="btn btn-secondary">Xem chi tiết</button>
              </td>
            </tr>
          </tbody>
        </table>
      </div>

      <!-- Modal -->
      <div v-if="selectedOrder">
        <div class="row">
          <h3 class="m-2">Chi tiết đơn hàng</h3>
          <button class="btn btn-danger" @click="closeModal">Đóng</button>
        </div>
        <div v-for="(item, index) in selectedOrder.chitietdonhangs" :key="item.id">
          <hr>
          <h5 class="text-danger">Sản phẩm thứ: {{ index + 1 }}</h5>
          <div class="row">
            <div>
              <v-img style="width:160px;height:160px" class="card-image" :src="`${item.hinhAnh}`"></v-img>
            </div>
            <div>
              <h6>Tên sản phẩm: {{ item.tenSanPham }}</h6>
              <h6>Số lượng: {{ item.soLuong }}</h6>
              <h6>Giá tiền: {{ formatCurrency(item.soLuong * item.giaBan) }}</h6>
            </div>
          </div>
        </div>
        <hr>
      </div>
    </div>
  </div>
</template>

<script>
import axios from 'axios';
import jwt_decode from 'jwt-decode';
import HomePage from '../components/HomePage.vue';

export default {
  components: {
    HomePage,
  },
  data() {
    return {
      donhangs: [],
      donhang: {
        IdDonHang: '',
      },
      selectedOrder: null,
      showModal: false,
    };
  },
  methods: {
    decodeJwt(jwttoken) {
      const decoded = jwt_decode(jwttoken);
      this.role = decoded.role;
      this.email = decoded.email;
    },
    formatCurrency(value) {
      return value.toLocaleString('vi-VN', { style: 'currency', currency: 'VND' });
    },
    getAllOrders() {
      axios.get(`https://localhost:7096/api/DonHang/user/${this.$route.params.id}`)
        .then(response => {
          this.donhangs = response.data;
        })
        .catch(error => {
          console.error(error);
        });
    },
    getTokenConfig() {
      var token = JSON.parse(localStorage.getItem('user'))
      const config = {
        headers: { Authorization: `Bearer ${token}` }
      };
      return config;
    },
    getChiTietDonHangs(idDonHang) {
      axios.get(`https://localhost:7096/api/ChiTietDonHang/donhang/${idDonHang}`)
        .then(response => {
          this.selectedOrder = { ...this.donhangs.find(donhang => donhang.IdDonHang === idDonHang), chitietdonhangs: response.data };
        })
        .catch(error => {
          console.error(error);
        });
    },

    closeModal() {
      this.selectedOrder = null;
    },
    onDelete(id) {
      this.$swal.fire({
        title: 'Bạn có chắc chắn muốn hủy đơn hàng này?',
        showDenyButton: false,
        confirmButtonText: 'OK',
        showCancelButton: true,
      }).then((result) => {
        if (result.isConfirmed) {
          axios.delete(`https://localhost:7096/api/DonHang/${id}`)
            .then(response => {
              console.log(response.data)
              if (response.data) {
                this.$swal.fire('Hủy thành công!', '', 'success')
                window.location.reload();
              }
            });
        }
      });
    },
    
    onNhanHang(id) {
      this.$swal.fire({
        title: 'Bạn chắc chắn đã nhận được đơn hàng này, sẽ không có yêu cầu hoàn trả cho đơn hàng này?',
        showDenyButton: false,
        confirmButtonText: 'OK',
        showCancelButton: true,
      }).then((result) => {
        if (result.isConfirmed) {
          axios.delete(`https://localhost:7096/api/DonHang/${id}`)
            .then(response => {
              console.log(response.data)
              if (response.data) {
                this.$swal.fire('Xin cảm ơn bạn, hãy cho chúng tôi đánh giá nhé!', '', 'success')
                window.location.reload();
              }
            });
        }
      });
    },
  },
  computed: {
    currentUser() {
      return this.$store.state.auth.user;
    },
  },
  created() {
    const jwttoken = localStorage.getItem('user');
    this.decodeJwt(jwttoken);
  },
  mounted() {
    if (!this.currentUser) {
      this.$swal.fire('Bạn phải đăng nhập để xem chi tiết đơn hàng!');
      this.$router.push('/login');
    } else {
      this.getAllOrders(this.currentUser.id);
    }
  },
};
</script>
