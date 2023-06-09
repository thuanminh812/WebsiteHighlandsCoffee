<template>
  <div>
    <HomePage />
    <br>
    <br>
    <br>
    <div class="container">
      <div class="row">
        <div class="s" style="border-right: 1px solid #ddd3d3;">
          <v-list-item class="bg-grey-lighten-4 ">
            <a class="text-dark" @click="filterMenuByCategory(null)">Tất cả</a>
          </v-list-item>
          <v-list nav>
            <a class="text-dark" v-for="danhmucmenu in danhmucmenus" :key="danhmucmenu.menuId" @click="filterMenuByCategory(danhmucmenu.menuId)">
              <v-list-item :value="danhmucmenu">{{danhmucmenu.tenDanhMuc}}</v-list-item>
            </a>
          </v-list>
        </div>
        <div class="col-sm-10">
          <div class="row">
            <div class="col-sm-6">
              <h2 style="font-weight: bold;">{{ selectedCategoryName }}</h2>
            </div>     
            <div class="justify-content-end col-sm-5">
              <form action="" class="form-inline">
                <div class="form-group">
                  <label for="" style="font-size:20px;font-weight: bold;">Tìm kiếm:</label>
                  <input placeholder="" type="text" class="form-control ml-2 mr-2" name="tim" v-model="search">
                </div>
              </form>
            </div>
            <h2><a class="text-dark" href="/giohang"><i class="fa-solid fa-cart-shopping"></i></a></h2>
          </div>
          <div class="row">
            <v-card elevation="10" v-for="menu in filteredMenus" :key="menu.idSanPham" class="col-sm-3 m-4">
              <v-card-title>
                <router-link :to="{ name: 'menuchitiet', params: {id: menu.idSanPham}}" class="text-dark"><v-img class="card-image" :src="menu.hinhAnh"></v-img></router-link>
              </v-card-title>
              <v-card-text>
                <h6><router-link :to="{ name: 'menuchitiet', params: {id: menu.idSanPham}}" class="text-brown-darken-1">{{menu.tenSanPham}}</router-link></h6>
                <h6><router-link :to="{ name: 'menuchitiet', params: {id: menu.idSanPham}}" class="text-dark">Giá: {{ formatCurrency(menu.giaBan) }} </router-link></h6>
                <v-btn block variant="elevated" color="red" height="50px" @click="addCart(menu)">Thêm vào giỏ hàng</v-btn>
              </v-card-text>
            </v-card>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import axios from 'axios'
import HomePage from '../components/HomePage.vue'

export default {
  name: 'MenuList',
  components: {
    HomePage,
  },
  data() {
    return {
      danhmucmenus: [],
      selectedCategory: null,
      imgURL:'',
      menus: [],
      search: '',
      danhmucmenu: {
        tenDanhMuc: '',
        moTaDanhMuc: '',
      },
      menu: {
        tenSanPham: '',
        giaBan: '',
        moTaSanPham: '',
      },
      cart: {
        idSanPham: '',
        idDonHang: '',
        tenSanPham: '',
        hinhAnh:'',
        soLuong: '',
        giaBan: ''
      },
      cartItems: []
    }
  },
  computed: {
    filteredMenus() {
      if (this.selectedCategory !== null) {
        return this.menus.filter(menu => menu.menuId === this.selectedCategory && this.matchesSearch(menu));
      } else {
        return this.menus.filter(menu => this.matchesSearch(menu));
      }
    },
    selectedCategoryName() {
      const category = this.danhmucmenus.find(item => item.menuId === this.selectedCategory);
      return category ? category.tenDanhMuc : 'Tất cả';
    }
  },
  methods: {
    matchesSearch(menu) {
      const searchTerm = this.search.toLowerCase();
      return menu.tenSanPham.toLowerCase().includes(searchTerm);
    },
    formatCurrency(value) {
      return value.toLocaleString("vi-VN", { style: "currency", currency: "VND" });
    },
    addCart(menu) {
      const existingItem = this.cartItems.find(cartItem => cartItem.idSanPham === menu.idSanPham);
      if (existingItem) {
        existingItem.soLuong++;
        existingItem.giaBan = existingItem.soLuong * menu.giaBan;
      } else {
        const newCartItem = {
          idSanPham: menu.idSanPham,
          hinhAnh: menu.hinhAnh,
          tenSanPham: menu.tenSanPham,
          giaBan: menu.giaBan,
          soLuong: 1
        };
        this.cartItems.push(newCartItem);
        alert('Đã thêm vào giỏ hàng!');
      }

      localStorage.setItem("cartItems", JSON.stringify(this.cartItems));
    },
    filterMenuByCategory(categoryId) {
      this.selectedCategory = categoryId;
    },
  },
  created() {
    axios.get('https://localhost:7096/api/DanhMucMenu')
      .then(response => {
        if (response.data) {
          this.danhmucmenus = response.data;
        }
      })
      .catch(e => {
        console.log("lỗi", e)
      });

    axios.get('https://localhost:7096/api/Menu')
      .then(response => {
        if (response.data) {
          this.menus = response.data;
        }
      })
      .catch(e => {
        console.log("lỗi", e)
      });
  },
}
</script>

<style scoped>
* {
  text-decoration: none;
  list-style: none;
  box-sizing: border-box;
}
body {
  font-family: montserrat;
}
label.logo {
  color: black;
  font-size: 35px;
  line-height: 80px;
  padding: 0 100px;
  font-weight: bold;
}
</style>
