<template>
    <div>
      <div class="d-flex" id="wrapper">
          <!-- Sidebar -->
          <div class="bg-dark" id="sidebar-wrapper">
              <div class="sidebar-heading text-center py-4 primary-text fs-4 fw-bold text-uppercase border-bottom"><i
                      class="fas fa-user me-2"></i>Admin </div>
              <div class="list-group list-group-flush my-3">
                  <a href="/listdmucmenu" class="list-group-item list-group-item-action bg-transparent second-text active"><i class="fa-solid fa-bars"></i> Quản lý menu</a>
                  <a href="/listdmuctintuc" class="list-group-item list-group-item-action bg-transparent second-text fw-bold"><i class="fa-solid fa-newspaper"></i> Quản lý tin tức</a>
                  <a href="/qlykhuvuc" class="list-group-item list-group-item-action bg-transparent second-text fw-bold"><i class="fa-solid fa-store"></i> Quản lý cửa hàng</a>
                          <a href="/phanhoi" class="list-group-item list-group-item-action bg-transparent second-text fw-bold"><i class="fa-solid fa-reply"></i> Phản hồi khách hàng</a>
                          <a href="/qlydonhang" class="list-group-item list-group-item-action bg-transparent second-text fw-bold"><i class="fa-sharp fa-solid fa-cart-shopping"></i> Quản lý đơn hàng</a>
                  <a href="/addadmin" class="list-group-item list-group-item-action bg-transparent second-text fw-bold"><i class="fa-solid fa-user-plus"></i> Thêm tài khoản</a>
                  <a href="/dashboard" class="list-group-item list-group-item-action bg-transparent second-text fw-bold"><i class="fa-solid fa-circle-info"></i> Thông tin tài khoản</a>
                <a href="/" class="list-group-item list-group-item-action bg-transparent second-text fw-bold"><i class="fa-solid fa-arrow-left"></i> Về trang chủ</a>
                          <a @click.prevent="logOut" class="list-group-item list-group-item-action bg-transparent second-text fw-bold"><i class="fa-solid fa-right-from-bracket"></i> Log out</a>
              </div>
          </div>
          <!-- /#sidebar-wrapper -->
  
          <!-- Page Content -->
          <div id="page-content-wrapper">
              <nav class="navbar navbar-expand-lg navbar-light bg-transparent py-4 px-4">
                  <div class="d-flex align-items-center">
                      <i class="fas fa-align-left primary-text fs-4 me-3" id="menu-toggle"></i>
                      <h2 class="fs-2 m-0"> Danh mục menu </h2>
                  </div>
  
                  <button class="navbar-toggler" type="button" data-bs-toggle="collapse"
                      data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent"
                      aria-expanded="false" aria-label="Toggle navigation">
                      <span class="navbar-toggler-icon"></span>
                  </button>
  
                  <div class="collapse navbar-collapse" id="navbarSupportedContent">
                      <ul class="navbar-nav ms-auto mb-2 mb-lg-0">
                          <li class="nav-item dropdown">
                              <a class="nav-link second-text fw-bold" href="#" id="navbarDropdown"
                                  role="button" data-bs-toggle="dropdown" aria-expanded="false">
                                  <i class="fas fa-user me-2"></i>Xin chào: {{ email }}
                              </a>
                          </li>
                      </ul>
                  </div>
              </nav>
              <button class="btn btn-info mb-3" style="margin-left:16px"><router-link to="formdmucmenu" class="text-white">Thêm mới</router-link></button>
              <div class="container-fluid px-4">
                <table class="table table-bordered table-hover " style="text-align:center">
        <thead class="thead-light">
            <tr>
                <th>Tên danh mục</th>
                <th>Mô tả danh mục</th>
                <th>Thao tác</th>
            </tr>
        </thead>
        <tbody>
            <tr v-for="danhmucmenu in danhmucmenus" v-bind:key="danhmucmenu.menuId">
                <td>{{danhmucmenu.tenDanhMuc}}</td>
                <td>{{danhmucmenu.motaDanhMuc}}</td>
				<router-link :to="{ name: 'editdmucmenu', params: {id: danhmucmenu.menuId}}">
				<button class="btn btn-success"><i class="fa-solid fa-pen-to-square"></i></button> |
			</router-link>
				<button class="btn btn-danger" @click="onDelete(danhmucmenu.menuId)"><i class="fa-solid fa-trash"></i></button> |
        <router-link :to="{ name: 'listmenu', params: {id: danhmucmenu.menuId}}">
				<button class="btn btn-secondary">Xem chi tiết</button> |
			</router-link>
            </tr>
        </tbody>
    </table>
              </div>
          </div>
      </div>
      </div>
   </template>
    <script>
      import axios from 'axios'
    import jwt_decode from 'jwt-decode'
    export default {
      name: 'ListDmucMenu',
      data(){
        return{
          sub:'',
          danhmucmenus:[]
        }
      },
      computed: {
        currentUser() {
          return this.$store.state.auth.user;
        }
      },
      created(){
        const jwttoken = localStorage.getItem('user');
        this.decodeJwt(jwttoken);
        axios.get("https://localhost:7096/api/DanhMucMenu")
        .then(response=>{
            if(response.data){
                this.danhmucmenus = response.data
            }
        })
        .catch(e=>{
            console.log("lỗi",e)
        })
      },
      methods:{
        decodeJwt(jwttoken){
              const decoded = jwt_decode(jwttoken);
              this.role = decoded.role;
              this.email = decoded.email;           
          },
          onDelete(id) {
			this.$swal.fire({
  title: 'Bạn có chắc chắn muốn xóa?',
  showDenyButton: false,
  confirmButtonText: 'OK',
  showCancelButton: true,
}).then((result) => {
  if (result.isConfirmed) {
	axios.delete(`https://localhost:7096/api/DanhMucMenu/${id}`,this.getTokenConfig()) .then(response => {
		console.log(response.data)
		if(response.data){
			this.$swal.fire('Xóa thành công!','','success')
			axios.get('https://localhost:7096/api/DanhMucMenu')
        .then(response=>{
            console.log(response.data);
            if(response.data){
                this.danhmucmenus = response.data
            }
        })
        .catch(e=>{
            console.log("lỗi",e)
        })
		}
	})
  } 
})
		},
    getTokenConfig(){
        var token = JSON.parse(localStorage.getItem('user'))
        const config = {
          headers: {Authorization : `Bearer ${token}`}
        };
        return config;
      },
    logOut() {
        this.$store.dispatch('auth/logout');
        this.$router.push('/login');
      }
      },
      mounted() {
        if (!this.currentUser) {
          this.$router.push('/login');
        }
        if (this.role != 'Admin') {
          this.$router.push('/');
        }
        var el = document.getElementById("wrapper");
          var toggleButton = document.getElementById("menu-toggle");
  
          toggleButton.onclick = function () {
              el.classList.toggle("toggled");
          };
      }
      
    };
    </script>
    <style scoped>
  :root {
    --main-bg-color: #009d63;
    --main-text-color: #009d63;
    --second-text-color: #bbbec5;
    --second-bg-color: #c1efde;
  }
  
  .primary-text {
    color: var(--main-text-color);
  }
  
  .second-text {
    color: var(--second-text-color);
  }
  
  .primary-bg {
    background-color: var(--main-bg-color);
  }
  
  .secondary-bg {
    background-color: var(--second-bg-color);
  }
  
  .rounded-full {
    border-radius: 100%;
  }
  
  #wrapper {
    overflow-x: hidden;
    background-image: linear-gradient(
      to right,
      #ffffff,
      #ffffff,
      #ffffff,
      #ffffff,
      #ffffff
    );
  }
  
  #sidebar-wrapper {
    min-height: 100vh;
    margin-left: -15rem;
    border-right: 1px solid #c9cbd0;
    -webkit-transition: margin 0.25s ease-out;
    -moz-transition: margin 0.25s ease-out;
    -o-transition: margin 0.25s ease-out;
    transition: margin 0.25s ease-out;
  }
  
  #sidebar-wrapper .sidebar-heading {
    padding: 0.875rem 1.25rem;
    font-size: 1.2rem;
  }
  
  #sidebar-wrapper .list-group {
    width: 15rem;
  }
  
  #page-content-wrapper {
    min-width: 100vw;
  }
  
  #wrapper.toggled #sidebar-wrapper {
    margin-left: 0;
  }
  
  #menu-toggle {
    cursor: pointer;
  }
  
  .list-group-item {
    border: none;
    padding: 20px 30px;
  }
  
  .list-group-item.active {
    background-color: transparent;
    color: var(--main-text-color);
    font-weight: bold;
    border: none;
  }
  
  @media (min-width: 768px) {
    #sidebar-wrapper {
      margin-left: 0;
    }
  
    #page-content-wrapper {
      min-width: 0;
      width: 100%;
    }
  
    #wrapper.toggled #sidebar-wrapper {
      margin-left: -15rem;
    }
  }
  
  
  </style>