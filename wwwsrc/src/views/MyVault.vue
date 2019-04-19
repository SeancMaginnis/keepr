<template>
    <div class="container-fluid">
        <div class="row">
            <div class="col-12">
                <button type="button" class="btn" data-toggle="modal" data-target="#vaultModal">
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
                    <vault  v-for="vault in vaults" :vault="vault"></vault>
                    
                </div>
            </section>
        <section class="row d-flex justify-content-center">
            <h1>Your Keeps</h1>
        </section>
           
        
        </div>
      
</template>

<script>
    import Vault from "../components/Vault";
    
    
    import MyKeeps from "../components/MyKeeps";
    

    export default {
        name: 'myVault',
        props: ["myKeeps"],
        components: { Vault, MyKeeps },
        data(){
            return{
                newVault: {}
            }
        },

        computed: {
            vaults() {
                return this.$store.state.vaults
            },
            

        },
        mounted() {
            if (!this.$store.state.user.id) {
                this.$router.push({name: "login"});
            }
            this.$store.dispatch("getVaults");
            
            

        },
        methods: {
            createVault() {
                let payload ={
                    name: this.newVault.name,
                    description: this.newVault.description,
                }
                this.$store.dispatch("createVault", payload);
                
                },
            
                
            }
        
    }
</script>

<style scoped>
.cen{
    display: flex;
    justify-content: center;
}
.btn{
     color: #f90092;
 }
.btn:hover{
    color: #9854bb;
}

</style>