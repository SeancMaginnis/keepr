<template>
    <div class="keeps container-fluid">

        <div class="row justify-content-center">
            <h2>Keeps</h2>
            <button class="btn btn-outline-info" @click="myVault()">My Profile</button>
            <button class="btn btn-outline-danger" @click="logout()">Logout</button>

        </div>
        <div  class="row pt-4">
        <div id="try" class="col-12">
            
        <Keep v-for="keep in keeps" :keep="keep"></Keep>
        </div>
         </div>




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
        methods: {
            myVault() {
                this.$router.push({ path: "/vaults" })
            },
            logout() {
                this.$store.dispatch("logout");
            },
            
        }



    }
</script>

<style scoped>
#try{
    display: flex;
    flex-wrap: wrap;
    justify-content: space-between;
    
    
}
</style>