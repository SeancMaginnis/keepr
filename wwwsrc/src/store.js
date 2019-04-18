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
    nativeEvent: {},
    items: [],
    owner: null,
    droptarget: null,
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
     setVaultKeeps(state, allKeeps) {
       state.vaultkeeps[allKeeps.vaultId] = allKeeps.keeps
     },
     addVaultKeep(state, vaultkeep) {
       state.vaultkeeps.find(vault => vault.vaultId == vaultkeep.vaultId).keeps = vaultkeep.keeps
     },

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
    getKeeps({ commit, dispatch }) {
      api.get('keeps/')
        .then(res => {
          commit('setKeeps', res.data)
        })
    },
    deleteKeep({ commit, dispatch }, payload) {
      api.delete('keeps/' + payload)
        .then(res => {
          dispatch('getKeeps')
        })
    },
    createVault({ commit, dispatch }, payload) {
      debugger
      api.post('vaults', payload)
        .then(res => {
          commit('addVaults', res.data)
        })
    },
    getVaults({ commit, dispatch }, myVaults) {
      api.get('vaults')
        .then(res => {
          commit('setVaults', res.data)
        })
    },
    /*getVaults({ commit, dispatch }, myVaults) {
      let query = 'vaults'
      if (myVaults){
        query += '/myVaults'
      }
      api.get('query')
          .then(res => {
            let user = res.data.map(vault ={
              if(!vault.userId){
              vault.userId = {}
            }
            return vault
          })
            commit('setVaults', user)
          })
    },*/
    deleteVault({ commit, dispatch }, payload) {
      api.delete('vaults/' + payload)
        .then(res => {
          dispatch('getVaults')
        })
    },
    addToVault({commit, dispatch}, payload){
      api.post('vaultkeeps/'+ payload.vaultId, payload)
          .then(res=>{
            dispatch('getVaultKeeps', payload.vaultId)
            dispatch('getVaults')
          })
    },
    getVaultKeeps({commit, dispatch}, payload){
      api.get("vaultkeeps/" + payload + "/keeps")
          .then(res=>{
            let newPayload = {
              keeps: res.data,
              vaultId: payload
            }
            commit("setVaultKeeps", newPayload)
          })
    },
    removeFromVault({commit, dispatch}, payload){
      api.delete('vaultkeeps/'+ payload.vaultId, payload)
          .then(res=>{
            dispatch('getVaultKeeps', payload.vaultId)
          })
    }
    

  },
  //#endregion
   /*getters: {
    myKeeps(state){
      debugger
      let mine = state.keeps.filter(k => k.userId[state.user.id])
      return mine || []
    }
   }*/
})
