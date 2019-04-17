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
               <Keep  v-for="keep in keeps" :keep="keep" ></Keep>
       </div>
        <div class="row"></div>
    </div>
</template>

<script>
    import Vault from "../components/Vault"
    import Keep from "../components/Keep";
    export default {
        name: "myVault",
        components:{Keep, Vault},
        methods: {
            addKeep(){
                this.$router.push({path: '/addKeep'})
            },
            addVault(){
                this.$router.push({path: '/addVault'})
            }
        },
        computed:{
            keeps(){
                return this.$store.state.keeps;
            },
            vaults(){
                return this.$store.state.vaults;
            },
            
        },
        
    }
</script>

<style scoped>

</style>