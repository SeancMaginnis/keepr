<template>
    

    <!-- Modal -->
    <div class="modal-xl fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true" data-backdrop="false">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Create a Keep!</h5>
                    <button type="button" class="navbar-toggler" data-toggle="collapse" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                <form @submit.prevent="createKeep">
                    <div class="form-group">
                        <label for="keepName">Keep Name</label>
                        <input v-model="newKeep.name" type="text" class="form-control" id="keepName" aria-describedby="keepName" placeholder="Name your Keep">
                    </div>
                    <div class="form-group">
                        <label for="keepDescription">Describe your Keep</label>
                        <input v-model="newKeep.description" type="text" class="form-control" id="keepDescription" placeholder="Give your keep a Description">
                    </div>
                    <div class="form-group">
                        <label for="keepImg">Add Image Url</label>
                        <input v-model="newKeep.img" type="text" class="form-control" id="keepImg" placeholder="Image Url">
                    </div>
                    <div class="form-group form-check">
                        <input v-model="newKeep.isPrivate" type="checkbox" class="form-check-input" id="privateCheck">
                        <label class="form-check-label" for="privateCheck">Mark as Private?</label>
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
        name: "createKeep",
        data() {
            return {
                newKeep: {},
                
            }
        },

        


        methods: {
            createKeep(){
                let payload ={
                    name: this.newKeep.name,
                    description: this.newKeep.description,
                    img: this.newKeep.img,
                    isPrivate: this.newKeep.isPrivate || false,
                    
                }
                console.log(payload)
                this.$store.dispatch("createKeep", payload);
               

            },
            
        }
    }
</script>

<style scoped>
    .kForm {
        display: flex;
        flex-direction: column;
        justify-content: center;
    }
    .modal-xl { background: rgba(000, 000, 000, 0.8); min-height:1000000px; }
</style>