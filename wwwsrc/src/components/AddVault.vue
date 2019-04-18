<template>
        <div class="modal-xl fade" id="vaultModal" tabindex="-1" role="dialog" aria-labelledby="vaultModalLabel" aria-hidden="true" data-backdrop="false">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="vaultModalLabel">Create a Vault!</h5>
                        <button type="button" class="navbar-toggler" data-toggle="collapse" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <form @submit.prevent="createVault">
                            <div class="form-group">
                                <label for="vaultName">Vault Name</label>
                                <input v-model="newVault.name" type="text" class="form-control" id="vaultName" aria-describedby="vaultName" placeholder="Name your Vault">
                            </div>
                            <div class="form-group">
                                <label for="vaultDescription">Describe your Vault</label>
                                <input v-model="newVault.description" type="text" class="form-control" id="vaultDescription" placeholder="Give your vault a Description">
                            </div>
                            <div class="modal-footer">
                                <button type="submit" class="btn btn-primary" data-dismiss="modal">Submit</button>
                                <button type="button" class="btn btn-outline-danger" data-dismiss="modal">Close</button>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
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
                debugger
                let payload ={
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
.modal-xl { background: rgba(000, 000, 000, 0.8); min-height:1000000px; }
    
    
    
</style>