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
      <h4 class="text-center text-cyan-darken-2">Đăng nhập</h4>
      <Form @submit="handleLogin" :validation-schema="schema">
        <div class="form-group">
          <label for="email">Email của bạn</label>
          <Field name="email" type="text" class="form-control" />
          <ErrorMessage name="email" class="error-feedback" />
        </div>
        <div class="form-group">
          <label for="password">Mật khẩu</label>
          <Field name="password" type="password" class="form-control" />
          <ErrorMessage name="password" class="error-feedback" />
        </div>

        <div class="form-group">
          <button class="btn btn-primary btn-block" :disabled="loading">
            <span
              v-show="loading"
              class="spinner-border spinner-border-sm"
            ></span>
            <span>Đăng nhập</span>
          </button>
        </div>
        <div class="form-group">
          <div v-if="message" class="alert alert-danger" role="alert">
            {{ message }}
          </div>
        </div>
      </Form>
      <div class="form-group">
        <router-link to="/register">
          <button class="btn btn-primary btn-block">
            <span>Đăng ký</span>
          </button>
        </router-link>
        </div>
    </div>
  </div>
</template>

<script>
import { Form, Field, ErrorMessage } from "vee-validate";
import HomePage from '../components/HomePage.vue'
import * as yup from "yup";
export default {
  name: "Login",
  components: {
    Form,
    Field,
    ErrorMessage,
    HomePage,
  },
  data() {
    const schema = yup.object().shape({
      email: yup.string().required("Username is required!"),
      password: yup.string().required("Password is required!"),
    });
    return {
      loading: false,
      message: "",
      schema,
    };
  },
  computed: {
    loggedIn() {
      return this.$store.state.auth.status.loggedIn;
    },
  },
  created() {
    if (this.loggedIn) {
      this.$router.push("/dashboard");
    }
  },
  methods: {
    handleLogin(user) {
      this.loading = true;
      this.$store.dispatch("auth/login", user).then(
        () => {
          this.$router.push("/dashboard");
        },
        (error) => {
          this.loading = false;
          this.message =
            (error.response &&
              error.response.data &&
              error.response.data.message) ||
            error.message ||
            error.toString();
        }
      );
    },
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