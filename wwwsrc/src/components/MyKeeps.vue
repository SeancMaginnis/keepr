<template>
    <div class="Keep pt-4 px-3">
        <div class="card px-3" style="width: 18rem;">
            <img class="card-img-top" style="" :src="keep.img" alt="Card image cap">
            <div class="card-body">
                <h5 class="card-title">{{keep.name}}</h5>
                <p class="card-text">{{keep.description}}</p>
                <div class="row">
                    <i class="fab fa-accessible-icon"></i>
                    <i class="fas fa-allergies"></i>
                </div>

                <button class="btn" @click="deleteKeep()">Delete</button>
            </div>
            <button type="button" class="btn btn-primary" @click="" data-toggle="modal" data-target="#exampleModalCenter">
                View Keep
            </button>

            <!-- Modal -->
            <div class="modal fade" id="exampleModalCenter" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
                <div class="modal-dialog modal-dialog-centered" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="exampleModalLongTitle">Modal title</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                           
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                            <button type="button" class="btn btn-primary">Save changes</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    export default {
        name: 'myKeep',
        props: ["keep", "id"],
        data() {
            return {

            }
        },



        methods:{
            deleteKeep() {
                let payload = {
                    keepId: this.keep.id
                }
                this.$store.dispatch("deleteKeep", payload);
            },
        },


    }

</script>

<style scoped>
    .card {
        box-shadow: 0 4px 8px 0 black;
    }
    .btn{
        color: #f90092;
    }
    .btn:hover{
        color: #9854bb;
    }
</style>