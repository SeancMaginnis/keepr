import Vue from 'vue'
import Router from 'vue-router'
// @ts-ignore
import Home from './views/Home.vue'
// @ts-ignore
import Login from './views/Login.vue'
// @ts-ignore
import MyVault from "./views/MyVault.vue";
import VaultKeep from "./views/VaultKeep.vue";



Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home
    },
    {
      path: '/login',
      name: 'login',
      component: Login
    },
    {

      path: '/vault/',
      name: 'myVault',
      component: MyVault,
    },
      {
          path: '/vault/:VaultId/keeps',
          name: 'vaultKeep',
          props: true,
          component: VaultKeep,
      }

  ]

})
