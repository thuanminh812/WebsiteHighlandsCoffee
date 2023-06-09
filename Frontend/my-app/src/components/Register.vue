<template>
  <div class="body">
    <HomePage />
    <br>
    <br>
    <br>
    <br>
    <div class="card card-container">
      <img
        id="profile-img"
        src="//ssl.gstatic.com/accounts/ui/avatar_2x.png"
        class="profile-img-card"
      />
      <h4 class="text-center text-cyan-darken-2">Đăng ký</h4>
      <form @submit="save()">
        <div v-if="!successful">
          <div class="form-group">
            <label for="diaChi">Địa chỉ</label>
            <input type="ten" class="form-control" name="ten" v-model="register.diaChi" required>
          </div>
          <div class="form-group">
            <label for="soDienThoai">Số điện thoại</label>
            <input type="ten" class="form-control" name="ten" v-model="register.soDienThoai" required>
          </div>
          <div class="form-group">
            <label for="username">Username</label>
            <input type="ten" class="form-control" name="ten" v-model="register.userName" required>
          </div>
          <div class="form-group">
            <label for="email">Email</label>
            <input type="ten" class="form-control" name="ten" v-model="register.email" required>
            <ErrorMessage name="email" class="error-feedback" />
          </div>
          <div class="form-group">
            <label for="password">Mật khẩu</label>
            <input type="password" class="form-control" name="password" v-model="register.password" required>
          </div>
          <div class="form-group">
            <label for="confirmPassword">Nhập lại mật khẩu</label>
            <input type="password" class="form-control" name="password" v-model="register.confirmPassword" required>
          </div>
          <div class="form-group">
            <button class="btn btn-primary btn-block" :disabled="loading">
              <span
                v-show="loading"
                class="spinner-border spinner-border-sm"
              ></span>
              Đăng ký
            </button>
          </div>
        </div>
      </Form>

      <div
        v-if="message"
        class="alert"
        :class="successful ? 'alert-success' : 'alert-danger'"
      >
        {{ message }}
      </div>
    </div>
  </div>
</template>

<script>
      import axios from 'axios'
import HomePage from '../components/HomePage.vue'
export default {
  name: "Register",
  components: {
    HomePage,
  },
  
  data() {
    return {
      successful: false,
      loading: false,
      register:{
            diaChi:'',
            soDienThoai:'',
            userName:'',
            email:'',
            password:'',
            confirmPassword:''
        }
    };
  },
  computed: {
    loggedIn() {
      return this.$store.state.auth.status.loggedIn;
    },
  },
  mounted() {
    if (this.loggedIn) {
      this.$router.push("/profile");
    }
  },
  methods: {
save(){
  axios.post('https://localhost:7096/api/Account/RegisterUser',this.register).then(response => {
              if(response.data){
                  // this.$router.push("/listmenu/"+this.$route.params.id)
                  this.$swal.fire('Thêm thành công','','success')
              }
          })
          .catch(e=>{
      console.log("lỗi",e)
          })
}
  },
};
</script>

<style scoped>
label {
  display: block;
  margin-top: 10px;
}
.card-container.card {
  max-width: 350px !important;
  padding: 40px 40px;
}
.body{
  background-color: cadetblue;
  height: 100%;
}
.card {
  background-color: #f7f7f7;
  padding: 20px 25px 30px;
  margin: 0 auto 25px;
  -moz-border-radius: 2px;
  -webkit-border-radius: 2px;
  border-radius: 2px;
  -moz-box-shadow: 0px 2px 2px rgba(0, 0, 0, 0.3);
  -webkit-box-shadow: 0px 2px 2px rgba(0, 0, 0, 0.3);
  box-shadow: 0px 2px 2px rgba(0, 0, 0, 0.3);
}
.profile-img-card {
  width: 96px;
  height: 96px;
  margin: 0 auto 10px;
  display: block;
  -moz-border-radius: 50%;
  -webkit-border-radius: 50%;
  border-radius: 50%;
}
.error-feedback {
  color: red;
}
</style>