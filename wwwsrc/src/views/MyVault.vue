<template>
    <div class="container-fluid">
        <div class="row">
            <div class="col-12">
                <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#vaultModal">
                    Create Vault
                </button>

                <!-- Modal -->
                <div class="modal" id="vaultModal" tabindex="-1" role="dialog" aria-labelledby="vaultModalLabel" aria-hidden="true">
                    <div class="modal-dialog" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title" id="vaultModalLabel">Vault</h5>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                            <div class="modal-body">
                                <form @submit.prevent="createVault">
                                    <input type="text" v-model="newVault.name" placeholder="Name your Vault!">
                                    <input type="text"  v-model="newVault.description" placeholder="What's it for?" id="desc">
                                <button type="submit" class="btn btn-primary" >Submit</button>
                                <button type="button" class="btn btn-outline-danger" data-dismiss="modal">Close</button>
                            </form>
                        
                        </div>
                    </div>
                </div>
            </div>
                
            </div>
    </div>
            <section class="row">
                <div class="col">
                    <vault v-for="vault in vaults" :vault="vault"></vault>
                </div>
            </section>
       <!-- <div class="row cen">
            <div id="keep" class="col" v-for="(keeps, index) in myKeeps" :key="index">
                <div class="row">
                    <div class="col">
                        <img src="myKeeps.img" class="photo" alt="">
                    </div>
                </div>
                <div class="row cen">
                    <div class="col">
                        <h4>{{myKeeps.name}}</h4>
                    </div>
                </div>
                <div class="row cen">
                    <div class="col">
                        <p>{{myKeeps.description}}</p>
                    </div>
                </div>
                <button @click="deleteKeep(keep.id)">Delete</button>
            </div>
        </div>-->
        </div>
      
</template>

<script>
    import Vault from "../components/Vault";

    export default {
        name: "myVault",
        props: ["keep"],
        components: { Vault },
        data(){
            return{
                newVault: {}
            }
        },

        computed: {
            vaults() {
                return this.$store.state.vaults
            },
            /*myKeeps(){
                return this.$store.getters.myKeeps;
            },*/

        },
        mounted() {
            if (!this.$store.state.user.id) {
                this.$router.push({name: "login"});
            }
            this.$store.dispatch("getVaults");
            if(!this.$store.state.keeps.length){
            this.$store.dispatch("getKeeps")
            }

        },
        methods: {
            createVault() {
                let payload ={
                    name: this.newVault.name,
                    description: this.newVault.description,
                }
                this.$store.dispatch("createVault", payload);
                
                }
                
            }
        
    }
</script>

<style scoped>
.cen{
    display: flex;
    justify-content: center;
}
</style>