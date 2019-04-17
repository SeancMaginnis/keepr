<template>
  <div class="home">
   
<div class="keeps container-fluid">
      <div class="row justify-content-center">
        <h2>Keeps</h2>
        <button class="btn btn-outline-info" @click="myVault()">My Profile</button>
        <button class="btn btn-outline-danger" @click="logout()">Logout</button>

      </div>
            
      <div  class="row pt-4">
            <AddKeep></AddKeep>
        <div id="try" class="col-12">
          <Keep v-for="keep in keeps" :keep="keep"></Keep>
        </div>
          <div class="col-12">
          </div>
      </div>
             



  </div>
    
  </div>
</template>

<script>
    
  import Keep from "../components/Keep";
  import AddKeep from "../components/AddKeep";
 
  export default {
    name: "home",
    components: { AddKeep, Keep},
    mounted() {
      //blocks users not logged in
        this.$store.dispatch("getKeeps");
      if (!this.$store.state.user.id) {
        this.$router.push({name: "login"})
      }
    },
    computed: {
      keeps() {
        return this.$store.state.keeps
      },
    },
      methods: {
          myVault (){
            this.$router.push({path: "/vault"})  
          },
          logout() {
              this.$store.dispatch("logout");
          },

      },
  }
</script>

<style scoped>
    #try{
        display: flex;
        flex-wrap: wrap;
        justify-content: space-between;


    }
</style>