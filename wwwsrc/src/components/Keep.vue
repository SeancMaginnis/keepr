<template>
    <div class="Keep pt-4 px-3">
        <div class="card px-3" style="width: 18rem;">
            <img class="card-img-top" style="" :src="keep.img" alt="Card image cap">
            <div class="card-body">
                <h5 class="card-title">{{keep.name}}</h5>
                <p class="card-text">{{keep.description}}</p>
                <div class="row">
                    
                        <button type="button" class="btn btn-secondary dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Add to Vault</button>
                        <div class="dropdown-menu">
                            <a class="dropdown-item" @click="addToVault(vault.id, keep.id)" v-for="vault in vaults">{{vault.name}}</a>
                        </div>
                    
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    export default {
        name: 'keep',
        props: ['keep', 'vault', 'id'],
        data() {
            return {
               
            }
        },
        computed: {
            vaults(){
                return this.$store.state.vaults
            }
        },
        methods: {
            addToVault(vaultId, keepId){
                let payload = {
                    VaultId: vaultId,
                    KeepId: keepId,
                }
                this.$store.dispatch("addToVault", payload)

            }
        }
        
            
        
    }
    
</script>

<style scoped>
    .card {
        box-shadow: 0 4px 8px 0 black;
    }
</style>