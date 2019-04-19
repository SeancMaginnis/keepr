<template>
    <div class="container-fluid">
        
          <vault-keeps v-for="keep in keeps" :keep="keep"></vault-keeps>      

           
    </div>
</template>

<script>
   

    import VaultKeeps from "../components/VaultKeeps";
    

    export default {
        
        name: "VaultKeep",
        components: {VaultKeeps},

        computed: {
            keeps(){
                return this.$store.state.vaultkeeps[parseInt(this.$route.params.VaultId)]
            }
        },
        mounted() {
               /* this.$store.dispatch('getUserKeeps');*/
                this.$store.dispatch('getVaultKeeps', parseInt(this.$route.params.VaultId));
                
                
                

            }
        
    }
</script>

<style scoped>

</style>