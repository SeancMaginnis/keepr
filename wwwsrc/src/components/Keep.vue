<template>
    <div class="Keep">
                    <div class="card px-3" style="width: 18rem;">
                        <img class="card-img-top" style="" :src="keep.img" alt="Card image cap">
                        <div class="card-body">
                            <h5 class="card-title">{{keep.name}}</h5>
                            <div class="row">
                                    <i class="fab fa-accessible-icon"></i>
                                    <i class="fas fa-allergies"></i>
                            </div>
                           
                            <p class="card-text">{{keep.description}}</p>
                            <button class="btn btn-outline-success" @click="deleteKeep(keep.id)">Delete</button>
                </div>
            </div>
    </div>
</template>

<script>
    export default {
        name: 'keep',
        props: ["keep"],
        
        
        
    methods:{
        deleteKeep(keepId) {
           this.$store.dispatch("deleteKeep", keepId);
        }
    },
        
    }
    
</script>

<style scoped>
    .card {
        box-shadow: 0 4px 8px 0 black;
    }
</style>