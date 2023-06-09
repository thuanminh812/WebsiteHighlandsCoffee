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
                      <h2 class="fs-2 m-0">Thêm mới</h2>
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
                <form @submit.prevent="save()"  action="" class=" border mt-4 p-4 " style="width: 800px;">
          <div class="form-group">
            <label>Tiêu đề </label>
              <input class="form-control"  v-model="tintuc.tieuDe" required>
          </div>
          <div class="form-group">
            <label>Hình ảnh </label>
          </div>
          <v-file-input ref="file" @change="handleFileUpload" ></v-file-input>
          <!-- <button @click="uploadFile">Up</button> -->
          <div v-if="imgURL">
            <img style="width: 80px; height: 80px;" :src="`${imgURL}`" alt="">
          </div>
          <div class="form-group">
            <label>Tóm tắt</label>
              <input  class="form-control"  v-model="tintuc.linkUrl" required>
          </div>
          <div class="form-group">
            <label>Mô tả tin tức</label>
              <textarea style="resize: none; width: 100%;
    height: 150px;box-sizing: border-box;" class="form-control"  v-model="tintuc.motaTinTuc" required></textarea>
          </div>
          <div>
          <button type="submit" class="btn btn-success">Lưu</button> &nbsp;
          </div>
          </form>
              </div>
          </div>
      </div>
      </div>
   </template>
    <script>
      import axios from 'axios'
    import jwt_decode from 'jwt-decode'
    // import authHeader from '../services/auth-header'
    export default {
      name: 'DmucMenuForm',
      data(){
        return{
            imgURL: '',
            tintuc:{
            hinhAnh:'',
            tieuDe:'',
            linkUrl:'',
            motaTinTuc:'',
            id:'',
            selectedFile: null
          }
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
        let id = this.$route.params.id
        if(id) {
            this.getTinTuc(id)
        }
      },
      methods:{
        decodeJwt(jwttoken){
              const decoded = jwt_decode(jwttoken);
              this.role = decoded.role;     
              this.email = decoded.email;   
          },
          getTinTuc(id) {
            axios.get(`https://localhost:7096/api/TinTuc/${id}`).then(response => {
                this.tintuc = response.data
            })
            
        },
      save(){ 
        this.tintuc.hinhAnh = this.imgURL
        if(this.tintuc.id) {
            axios.put(`https://localhost:7096/api/TinTuc/${this.tintuc.id}`,this.tintuc,this.getTokenConfig()).then(response => {
                if(response.data){
                  this.$swal.fire('Cập nhật thành công!','','success')
                  this.$router.go(-1)
                }
            })
            return;
        } 
      },
      getTokenConfig(){
        var token = JSON.parse(localStorage.getItem('user'))
        const config = {
          headers: {Authorization : `Bearer ${token}`}
        };
        return config;
      },
      handleFileUpload(event) {
        this.selectedFile = event.target.files[0] ;
        const formData = new FormData();
        formData.append('file',this.selectedFile);
        axios.post('https://localhost:7096/api/TinTuc/uploadimage',formData,
        {
          headers:{
            'Content-Type':'multipart/form-data'
          }         
        }).then(response => {
          this.imgURL = response.data
          
        }).catch(error => {
          console.log(error);
        })
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