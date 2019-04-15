<template>
    <div class="container-fluid">
       <div class="row">
           <div class="col-12">
               <button class="btn btn-outline-success" @click="addKeep()">Create a Keep</button>
               <button class="btn btn-outline-info" @click="addVault()">Create a Vault</button>
           </div>
       </div>
    </div>
</template>

<script>
    
    
    export default {
        name: "myVault",
        
        methods: {
            addKeep(){
                this.$router.push({path: '/addKeep'})
            },
            addVault(){
                this.$router.push({path: '/addVault'})
            }
        }
    }
</script>

<style scoped>

</style>