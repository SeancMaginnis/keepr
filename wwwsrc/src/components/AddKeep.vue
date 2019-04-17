<template>
    <div class="kForm col">
        <form @submit.prevent="createKeep">
            <input type="text" placeholder="Name" v-model="newKeep.name">
            <input type="text" placeholder="Description" v-model="newKeep.description">
            <input type="text" placeholder="URL for Image" v-model="newKeep.img">

            <button class="btn btn-outline-danger" type="submit">Create Keep</button>
        </form>



    </div>
</template>

<script>
    export default {
        name: "createKeep",
        data() {
            return {
                newKeep: {}
            }
        },



        methods: {
            createKeep(){
                let payload ={
                    userId: this.$store.state.user.id,
                    name: this.newKeep.name,
                    description: this.newKeep.description,
                    img: this.newKeep.img,
                    
                }
                console.log(payload)
                this.$store.dispatch("createKeep", payload)

            }
        }
    }
</script>

<style scoped>
    .kForm {
        display: flex;
        flex-direction: column;
        justify-content: center;
    }
</style>