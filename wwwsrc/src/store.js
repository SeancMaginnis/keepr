import Vue from 'vue'
import Vuex from 'vuex'
import Axios from 'axios'
import router from './router'


Vue.use(Vuex)


let baseUrl = location.host.includes('localhost') ? '//localhost:5000/' : '/'

let auth = Axios.create({
  baseURL: baseUrl + "account/",
  timeout: 3000,
  withCredentials: true
})

let api = Axios.create({
  baseURL: baseUrl + "api/",
  timeout: 3000,
  withCredentials: true
})

export default new Vuex.Store({
  state: {
    user: {},
    keeps: [],
    vaults: [],
    myVaults: [],
    vaultkeeps: {},
    
    privateKeeps: [],
  },
  mutations: {
    setUser(state, user) {
      state.user = user
    },
    setKeeps(state, keeps) {
      state.keeps = keeps
    },
    addKeep(state, keep) {
      state.keeps.push(keep)
    },
    setVaults(state, vaults) {
      state.vaults = vaults;
    },
    addVaults(state, vault) {
      state.vaults.push(vault)
    },
    setVaultKeeps(state, newPayload) {
     Vue.set(state.vaultkeeps, newPayload.vaultId, newPayload.keeps) 
    },
    setMyVaults(state, vaults) {
      state.myVaults = vaults
    },
    setPrivate(state, keeps) {
      state.privateKeeps = keeps
    }

  },
  actions: {
    //#region --Login--
    register({ commit, dispatch }, newUser) {
      auth.post('register', newUser)
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('[registration failed] :', e)
        })
    },
    authenticate({ commit, dispatch }) {
      auth.get('authenticate')
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('not authenticated')
        })
    },
    login({ commit, dispatch }, creds) {
      auth.post('login', creds)
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('Login Failed')
        })
    },
    logout({ commit, dispatch }, creds) {
      auth.delete('logout')
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'login' })
        })
    },
    getUser({ commit, dispatch }, payload) {
      auth.get('authenticate')
        .then(res => {
          commit('setUsers', res.data)
        })
    },
    //#endregion
    //#region --Keeps--
    createKeep({ commit, dispatch }, payload) {
      api.post('keeps', payload)
        .then(res => {
          commit('addKeep', res.data)
        })
    },
    getPublic({ commit, dispatch }) {
      api.get('keeps/public')
        .then(res => {
          commit('setKeeps', res.data)
        })
    },
    getUserKeep({ commit, dispatch }) {
      api.get('keeps/userId')
        .then(res => {
          commit('setKeeps', res.data)
        })
    },
    deleteKeep({ commit, dispatch }, payload) {
      api.delete('keeps/' + payload.keepId)
        .then(res => {
          dispatch('getUserKeep')
        })
    },
    createVault({ commit, dispatch }, payload) {
      api.post('vaults', payload)
        .then(res => {
          commit('addVaults', res.data)
        })
    },
    getVaults({ commit, dispatch }) {
      api.get('vaults/')
        .then(res => {
          commit('setVaults', res.data)
        })
    },
    deleteVault({ commit, dispatch }, payload) {
      api.delete('vaults/' + payload)
        .then(res => {
          dispatch('getVaults')
        })
    },
    
    addToVault({ commit, dispatch }, payload) {
      api.post('vaultkeeps/' , payload)
          .then(res=>{
      dispatch("getVaultKeeps", payload.VaultId)
          })
        
    },
    getVaultKeeps({ commit, dispatch }, payload) {
      api.get("vaultkeeps/"  + payload)
        .then(res => {
          let newPayload = {
            keeps: res.data,
            vaultId: payload
          }
          commit("setVaultKeeps", newPayload)
        })
    },
    removeFromVault({ commit, dispatch }, payload) {
      debugger
      api.delete('vaultkeeps/' + payload.VaultId + '/' + payload.KeepId)
        .then(res => {
          dispatch('getVaultKeeps', payload.VaultId)
        })
    },



  },
  //#endregion
 
})
