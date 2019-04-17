import Vue from 'vue'
import Router from 'vue-router'
// @ts-ignore
import Home from './views/Home.vue'
// @ts-ignore
import Login from './views/Login.vue'
import Keeps from "./views/Keeps.vue"
import MyVault from "./components/MyVault";
import addVault from "./components/addVault";
import addKeep from "./components/addKeep";


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

      path: '/vault',
      name: 'myVaults',
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
