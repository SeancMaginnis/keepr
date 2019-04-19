<template>
    <div class="col-12">
    <div class="Keep pt-4 px-3" >
        <div class="card px-3" style="width: 18rem;">
            <img class="card-img-top" style="" :src="keep.img" alt="Card image cap">
            <div class="card-body">
                <h5 class="card-title">{{keep.name}}</h5>
                <p class="card-text">{{keep.description}}</p>
                <div class="row">
                    <i class="fab fa-accessible-icon"></i>
                    <i class="fas fa-allergies"></i>
                </div>
                <button type="button" class="btn btn-primary" @click="" data-toggle="modal" data-target="#singleKeep">
                    View Keep
                </button>

                <button class="btn" @click="removeFromVault(keep.id)">Delete</button>
            
    </div>
    </div>
            <!-- Modal -->
            <div class="modal fade" id="singleKeep" tabindex="-1" role="dialog" aria-hidden="true">
                <div class="modal-dialog modal-dialog-centered" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" >{{keep.name}}</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <div class="card px-3" style="width: 18rem;">
                                <img class="card-img-top" style="" :src="keep.img" alt="Card image cap">
                                <div class="card-body">
                                    <p class="card-text">{{keep.description}}</p>

                                </div>
                            </div>
                        </div>
                    </div>
                
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    export default {
        
        name: "vaultkeeps",
        props: ["keep", "vault"],
        components: {},
        methods:{
            removeFromVault(keep){
                debugger
                let vaultId = +this.$route.params.VaultId
                let payload = {
                    KeepId: keep,
                    VaultId: vaultId
                    
                }
                this.$store.dispatch("removeFromVault", payload)
            }
        },
       mounted() {
            this.$store.dispatch("getVaultKeeps", parseInt( this.$route.params.VaultId))
       }
    }
    
</script>

<style scoped>

</style>