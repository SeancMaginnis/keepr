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
            addKeep: function () {
                this.$store.dispatch("createKeep", this.makeKeep)
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