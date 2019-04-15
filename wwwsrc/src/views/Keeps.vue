<template>
    <div class="keeps container-fluid">

        <div class="row justify-content-center">
            <h2>Keeps</h2>
            <button class="btn btn-outline-info" @click="myVault()">My Profile</button>

        </div>

        <Keep v-for="keep in keeps" :keep="keep"></Keep>






    </div>
</template>

<script>

    import Keep from "../components/Keep";
    ;
    export default {
        name: "keeps",
        components: { Keep },
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
        },
        logout() {
            this.$store.dispatch("logout");
        },
        methods: {
            myVault() {
                this.$router.push({ path: "/vaults" })
            }
        }



    }
</script>

<style scoped>

</style>