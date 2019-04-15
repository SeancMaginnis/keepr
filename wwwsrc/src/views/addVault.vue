<template>
    <div class="vForm col">
        <form @submit="addVault">
            <input type="text" placeholder="Title" v-model="makeVault.name">
            <input type="text" placeholder="Description" v-model="makeVault.description">
            <button class="btn btn-outline-success" type="submit">Create Vault</button>
        </form>
    
        
        
        
    </div>
</template>

<script>
    export default {
        name: "addVault",
        data(){
            return {
                makeVault: {}
            }
        },
        methods: {
            addVault() {
                let payload ={
                    name: this.makeVault.name,
                    description: this.makeVault.description
                }
                console.log(payload)
                this.$store.dispatch("createVault", payload).then((this.$router.push({path: '/Vault'})))
            }
        }
    }
</script>

<style scoped>
.vForm{
    display: flex;
    flex-direction: column;
    justify-content: center;
}
    
    
    
    
</style>