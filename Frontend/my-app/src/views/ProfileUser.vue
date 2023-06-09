<template>
    <div>
        <HomePage />
    <br>
    <br>
      <div class="d-flex" id="wrapper">
          <!-- Sidebar -->
          <div class="bg-dark" id="sidebar-wrapper">
              <div class="list-group list-group-flush my-3">
                  <a href="/profileuser" class="list-group-item list-group-item-action bg-transparent second-text fw-bold"><i class="fa-solid fa-circle-info"></i> Thông tin tài khoản</a>
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
                      <h2 class="fs-2 m-0">Thông tin tài khoản </h2>
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
  
              <div class="container-fluid px-4">
                <div class="row">
                  <div class="col-sm-3">
                <v-img style="width:200px; height:200px" src="../assets/guest.png"></v-img>
                </div>
                <div class="col-sm-5">
                <h4>Địa chỉ: {{ user.diaChi }}</h4>
                <h4>Số điện thoại: {{ user.soDienThoai }}</h4>
                <h4><i class="fas fa-user me-2"></i> Username: {{ user.name }}</h4>
                <v-btn color="blue" @click="showModal=true"><i class="fa-solid fa-pen"></i> Sửa thông tin</v-btn>
              </div>
                <transition name="modal">
        <div class="modal-mask" v-if="showModal">
          <div class="modal-wrapper">
            <div class="modal-container">
              <form @submit.prevent="save()"  action="" class=" border mt-4 p-4 " style="width: 800px;">
            <div class="form-group">
              <label>Địa chỉ</label>
                <input type="ten" class="form-control" name="ten" v-model="user.diaChi" required>
            </div>
            <div class="form-group">
              <label>Số điện thoại</label>
                <input type="ten" class="form-control" name="ten" v-model="user.soDienThoai" required>
            </div>
            <div class="form-group">
              <label>Username</label>
                <input type="ten" class="form-control" name="ten" v-model="user.name" required>
            </div>
            <div>
            <button type="submit" class="btn btn-success"  @click="showModal = false">Lưu</button> &nbsp;
            </div>
            </form>
              <button class="btn btn-danger modal-default-button" @click="showModal = false">Đóng</button>
            </div>
          </div>
        </div>
      </transition>
              </div>
              </div>
          </div>
      </div>
      </div>
   </template>
    <script>
    import axios from 'axios'
    import jwt_decode from 'jwt-decode'
    import HomePage from '../components/HomePage.vue'
    export default {
      name: 'Profile',
      components: {
    HomePage,
  },
      data(){
        return{
          sub:'',
          users:[],
          user:{
            diaChi:'',
            soDienThoai:'',
            name:''
          },
          showModal: false,
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
      methods:{
        decodeJwt(jwttoken){
              const decoded = jwt_decode(jwttoken);
              this.role = decoded.role;
              this.email = decoded.email;           
          },
          save(){
            axios.put(`https://localhost:7096/api/Account/updateUser/${this.user.id}`,this.user,this.getTokenConfig()).then(response => {
                if(response.data){
                  this.$swal.fire('Cập nhật thông tin thành công, bạn cần phải đăng nhập lại!','','success')
                  this.logOut()
                    return
                }
            })
            return;
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
        if (this.role != 'User') {
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