<template>
    <div class="Vault">
      <div class="col-4" >
          <div class="card" style="width: 18rem;">
              <div class="card-body">
                  <h5 class="card-title">{{vault.name}}</h5>
                  <h6 class="card-text">{{vault.description}}</h6>
                  <button class="btn btn-outline-danger" @click="deleteVault(vault.id)">Delete</button>
              </div>
          </div>
      </div>  
    </div>
</template>

<script>
    export default {
        name: "vault",
        props: ["vault"],
        
        methods:{
            deleteVault(vaultId){
                debugger
                this.$store.dispatch("deleteVault", vaultId);
            }
        },
        
    }
</script>

<style scoped>

</style>