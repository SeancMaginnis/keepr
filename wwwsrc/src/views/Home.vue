<template>
 
   
<div class="keeps container-fluid">
        <h2>Keeps</h2>
          <AddKeep></AddKeep>
        <AddVault></AddVault>
        <button class="btn btn-outline-info" @click="myVault()">My Profile</button>
        <button class="btn btn-outline-danger" @click="logout()">Logout</button>
      <div class="row justify-content-center">
          
      </div>
    
      <div  class="row pt-4">
            
          
        <div id="try" class="col-12">
          <Keep v-for="keep in keeps" :keep="keep"></Keep>
        </div>
          <div id="try2" class="col-12">
              <Vault v-for="vault in vaults" :vault="vault"></Vault>
          </div>
      </div>
             



  </div>
    

</template>

<script>
    import Vault from "../components/Vault";
  import Keep from "../components/Keep";
  import AddKeep from "../components/AddKeep";
  import AddVault from "../components/AddVault";
 
  export default {
    name: "home",
    components: { AddKeep, Keep, Vault, AddVault},
    mounted() {
      //blocks users not logged in
        this.$store.dispatch("getVaults");
        this.$store.dispatch("getKeeps");
      if (!this.$store.state.user.id) {
        this.$router.push({name: "login"})
      }
    },
    computed: {
      keeps() {
        return this.$store.state.keeps
      },
        vaults(){
          return this.$store.state.vaults 
      }
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
    #try {
        display: flex;
        flex-wrap: wrap;
        justify-content: space-between;
    }
.keeps{
    background-color: transparent;
}
    #try2{
        display: flex;
        flex-wrap: wrap;
        justify-content: space-between; 
    }

    
</style>