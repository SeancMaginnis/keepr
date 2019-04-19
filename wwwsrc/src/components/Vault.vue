<template>
    <div class="Vault">
      <div class="col-4" >
          <h5>{{vault.name}}</h5>
                  <h6>{{vault.description}}</h6>
                  <div class="row d-flex justify-content-around">
                      <img  class="img-fluid border border-danger" v-for="keep in keeps" :src="keep.img" id="vaultImg" alt="">
                
                  <button class="btn" @click="deleteVault(vault.id)">Delete</button>
                      <button class="btn" @click="vaultKeep(vault.id)">Go to VaultKeeps</button>
                    
          </div>
      </div>  
    </div>
</template>

<script>
    export default {
        name: "vault",
        props: ["vault", "keep"],
        
        methods:{
            deleteVault(vaultId){
                this.$store.dispatch("deleteVault", vaultId);
            },
            vaultKeep(id) {
                this.$router.push('/vault/' + id + '/keeps')
               
            }
        },
        computed:{
          keeps(){
              return this.$store.state.vaultkeeps[this.vault.id]
          }  
        },
        
    }
</script>

<style>
#vaultImg{
    max-height: 55px;
    width: 55px;
}
    
</style>