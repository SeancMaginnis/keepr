<template>
    <div class="container-fluid">
       <div class="row">
           <div class="col-12">
               <button class="btn btn-outline-success" @click="addKeep()">Create a Keep</button>
               <button class="btn btn-outline-info" @click="addVault()">Create a Vault</button>
           </div>
           <div class="row">
               <div class="col">
                   <Vault v-for="vault in vaults" :vault="vault"></Vault>
               </div>
           </div>
       </div>
        <div class="row"></div>
    </div>
</template>

<script>
    import Vault from "../components/Vault"
    export default {
        name: "myVault",
        components:{ Vault},
        methods: {
            addKeep(){
                this.$router.push({path: '/addKeep'})
            },
            addVault(){
                this.$router.push({path: '/addVault'})
            }
        },
        computed:{
            vaults(){
                return this.$store.state.vaults;
            },
            
        },
        
    }
</script>

<style scoped>

</style>