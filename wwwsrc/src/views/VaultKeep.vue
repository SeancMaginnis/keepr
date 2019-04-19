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
             return   this.$store.state.keeps
            }
        },
        mounted() {
            //blocks users not logged in
            if (!this.$store.state.user.id) {
                this.$router.push({ name: "login" });
                this.$store.dispatch('getVaultKeeps', parseInt(this.$route.params.vaultId));
                

            }
        },
    }
</script>

<style scoped>

</style>