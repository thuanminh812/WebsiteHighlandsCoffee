import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import vuetify from './plugins/vuetify'
import store from './store';
import { FontAwesomeIcon } from './plugins/font-awesome';
import VueSweetalert2 from 'vue-sweetalert2';
import 'sweetalert2/dist/sweetalert2.min.css';



createApp(App)
  .use(router)
  .use(store)
  .use(vuetify)
  .use(VueSweetalert2)
  .component('font-awesome-icon', FontAwesomeIcon)
  .mount('#app')
