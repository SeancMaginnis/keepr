<template>
    <div class="vForm col">
        <form @submit.prevent="createVault">
            <input type="text" placeholder="Title" v-model="newVault.name">
            <input type="text" placeholder="Description" v-model="newVault.description">
            <button class="btn btn-outline-success" type="submit">Create Vault</button>
        </form>
    
        
        
        
    </div>
</template>

<script>
    export default {
        name: "createVault",
        data(){
            return {
                newVault: {}
            }
        },
        methods: {
            createVault() {
                let payload ={
                    userId: this.$store.state.user.id,
                    name: this.newVault.name,
                    description: this.newVault.description,
                }
                console.log(payload)
                this.$store.dispatch("createVault", payload)
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