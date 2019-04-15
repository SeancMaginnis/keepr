<template>
    <div class="kForm col">
        <form @submit.prevent="addKeep">
            <input type="text" placeholder="Name" v-model="makeKeep.name">
            <input type="text" placeholder="Description" v-model="makeKeep.description">
            <input type="text" placeholder="URL for Image" v-model="makeKeep.img">

            <button class="btn btn-outline-danger" type="submit">Create Keep</button>
        </form>



    </div>
</template>

<script>
    export default {
        name: "addKeep",
        data() {
            return {
                makeKeep: {}
            }
        },



        methods: {
            addKeep(){
                let payload ={
                    name: this.makeKeep.name,
                    description: this.makeKeep.description,
                    img: this.makeKeep.img
                }
                console.log(payload)
                this.$store.dispatch("createKeep", payload).then((this.$router.push({path: '/Keeps'})))

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