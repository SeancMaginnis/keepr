<template>
    <div class="container-fluid">
        <div class="row">
            <div class="col-12">

                <AddVault></AddVault>
            </div>
            <div class="row">
                <div class="col">
                    <Vault v-for="vault in vaults" :vault="vault"></Vault>
                </div>
            </div>
        </div>
        <div class="row"></div>
    </div>
</template>

<script>
    import AddVault from "../components/AddVault";
    import Vault from "../components/Vault";

    export default {
        name: "myVault",
        components: { Vault, AddVault },

        computed: {
            vaults() {
                return this.$store.state.vaults
            },

        },
        mounted() {
            this.$store.dispatch("getVaults");

        }
    }
</script>

<style scoped>

</style>