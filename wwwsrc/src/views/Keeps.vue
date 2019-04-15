<template>
    <div class="keeps container-fluid">
        <AddKeep></AddKeep>
        <div class="row justify-content-center">
            <h2>Keeps</h2>
        </div>
        
        <Keep v-for="keep in keeps" :keep="keep"></Keep>
    





    </div>
</template>

<script>

    import Keep from "../components/Keep";
    import AddKeep from "../components/addKeep";
    export default {
        name: "keeps",
        components: {AddKeep, Keep },
        data() {
            return {
                
            }
        },

        computed: {
            keeps() {
                return this.$store.state.keeps
            },
        },
        mounted() {
            this.$store.dispatch("getKeeps");
            if (!this.$store.state.user.id) {
                this.$router.push({ name: "login" });
            }
        }

    }
</script>

<style scoped>

</style>