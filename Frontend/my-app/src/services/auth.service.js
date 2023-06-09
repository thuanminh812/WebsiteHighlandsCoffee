import axios from 'axios';

const API_URL = 'https://localhost:7096/api/Account/';

class AuthService {
  login(user) {
    return axios
      .post(API_URL + 'Login', {
        email: user.email,
        password: user.password
      })
      .then(response => {
        if (response.data) {
          localStorage.setItem('user', JSON.stringify(response.data));
          
        }

        return response.data;
      });
  }

  logout() {
    localStorage.removeItem('user');
  }

}

export default new AuthService();