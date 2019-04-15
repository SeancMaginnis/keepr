import Vue from 'vue'
import Router from 'vue-router'
// @ts-ignore
import Home from './views/Home.vue'
// @ts-ignore
import Login from './views/Login.vue'
import Keeps from "./views/Keeps.vue"
import MyVault from "./views/MyVault";
import addVault from "./views/addVault";
import addKeep from "./views/addKeep";


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
      path: '/keeps',
      name: 'keeps',
      component: Keeps
    },
    {

      path: '/vaults',
      name: 'myvaults',
      component: MyVault,
    },
    {
      path: '/addVault',
      name: 'addVault',
      component: addVault,
    },
    {
      path: '/addKeep',
      name: 'addKeep',
      component: addKeep,
    },
  ]

})
