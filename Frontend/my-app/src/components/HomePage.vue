<template>
        <header class="header homee">
  <router-link to="/" class="logo">Highlands Coffee </router-link>
  <input class="menu-btn" type="checkbox" id="menu-btn" />
  <label class="menu-icon" for="menu-btn"><span class="navicon"></span></label>
  <ul class="menu  navbar-expand navbar-dark ">
    <li class="nav-item"><router-link class="nav-link" to="/gioithieu">Giới thiệu</router-link></li>
    <li class="nav-item"><router-link class="nav-link" to="/menu">Menu</router-link></li>
    <li class="nav-item"><router-link class="nav-link" to="/tintuc">Tin tức</router-link></li>
    <li class="nav-item"><router-link class="nav-link" to="/cuahang">Cửa hàng</router-link></li>
    <li class="nav-item"><router-link class="nav-link" to="/tuyendung">Tuyển dụng</router-link></li>
    <li class="nav-item"><router-link class="nav-link" to="/lienhe">Liên hệ</router-link></li>
    <div v-if="!currentUser" class="navbar-nav ml-auto">
        <li class="nav-item">
          <router-link to="/register" class="nav-link">
            <font-awesome-icon icon="user-plus" /> Đăng ký
          </router-link>
        </li>
        <li class="nav-item">
          <router-link to="/login" class="nav-link">
            <font-awesome-icon icon="sign-in-alt" /> Đăng nhập
          </router-link>
        </li>
      </div>
        <div v-if="currentUser" class="navbar-nav ml-auto">
          <li class="nav-item">
            <router-link to="/dashboard">
              <i class="fa-solid fa-list"></i>
            </router-link>
          </li>
          <li class="nav-item">
            <router-link to="/profileuser">
              <i
                    class="fas fa-user me-2"></i>
            </router-link>
          </li>
          <li class="nav-item">
            <a class="nav-link"  @click.prevent="logOut">
              <font-awesome-icon icon="sign-out-alt" /> Logout
            </a>
          </li>
        </div>
  </ul>
</header>
  </template>
  <script scoped>
  export default {
    computed: {
      currentUser() {
        return this.$store.state.auth.user;
      },
    },    
    methods: {
      logOut() {
        this.$store.dispatch('auth/logout');
        this.$router.push('/login');
      },
    }
  };
  </script>
  
  <style >

    ul{
      margin-top: 50px;
    }
    ul li {
      font-size: 19px;
      font-weight: bold;
      color: #555555;
    }
    h2{
      font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
    }
body {
  margin: 0;
  font-family: Helvetica, sans-serif;
  background-color: #f4f4f4;
}

a {
  color: #000;
}

.header {
  background-color: #7e7878;
  box-shadow: 1px 1px 4px 0 rgba(0,0,0,.1);
  position: fixed;
  width: 100%;
  z-index: 3;
  
}

.header ul {
  margin: 0;
  padding: 0;
  list-style: none;
  overflow: hidden;
  background-color: #7e7878;
}

.header li a {
  display: block;
  padding: 1px 30px;
  border-right: 1px solid #7e7878;
  text-decoration: none;
}

.header li a:hover,
.header .menu-btn:hover {
  color: cornsilk;
}

.header .logo {
  display: block;
  float: left;
  font-size: 2em;
  padding: 10px 20px;
  text-decoration: none;
  font-family: 'Trebuchet MS', 'Lucida Sans Unicode', 'Lucida Grande', 'Lucida Sans', Arial, sans-serif;
}



.header .menu {
  clear: both;
  max-height: 0;
  transition: max-height .2s ease-out;
}



.header .menu-icon {
  cursor: pointer;
  display: inline-block;
  float: right;
  padding: 28px 20px;
  position: relative;
  user-select: none;
}

.header .menu-icon .navicon {
  background: #333;
  display: block;
  height: 2px;
  position: relative;
  transition: background .2s ease-out;
  width: 18px;
}

.header .menu-icon .navicon:before,
.header .menu-icon .navicon:after {
  background: #333;
  content: '';
  display: block;
  height: 100%;
  position: absolute;
  transition: all .2s ease-out;
  width: 100%;
}

.header .menu-icon .navicon:before {
  top: 5px;
}

.header .menu-icon .navicon:after {
  top: -5px;
}



.header .menu-btn {
  display: none;
}

.header .menu-btn:checked ~ .menu {
  max-height: 240px;
}

.header .menu-btn:checked ~ .menu-icon .navicon {
  background: transparent;
}

.header .menu-btn:checked ~ .menu-icon .navicon:before {
  transform: rotate(-45deg);
}

.header .menu-btn:checked ~ .menu-icon .navicon:after {
  transform: rotate(45deg);
}

.header .menu-btn:checked ~ .menu-icon:not(.steps) .navicon:before,
.header .menu-btn:checked ~ .menu-icon:not(.steps) .navicon:after {
  top: 0;
}



@media (min-width: 48em) {
  .header li {
    float: left;
  }
  .header li a {
    padding: 20px 30px;
  }
  .header .menu {
    clear: none;
    float: right;
    max-height: none;
  }
  .header .menu-icon {
    display: none;
  }
}

  </style>