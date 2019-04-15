<template>
    <div class="Keep">
        
            <div class="row d-flex justify-content-center">
                <div class="col-3 d-flex justify-content-around">
                    <div class="card" style="width: 18rem;">
                        <img class="card-img-top" :src="keep.img" alt="Card image cap">
                        <div class="card-body">
                            <h5 class="card-title">{{keep.name}}</h5>
                            <div class="row">
                                    <i class="fab fa-accessible-icon"></i>
                                    <i class="fas fa-allergies"></i>
                            </div>
                           
                            <p class="card-text">{{keep.description}}</p>
                            
                        </div>
                    </div>
                </div>
            </div>














        
    </div>
</template>

<script>
    export default {
        name: 'keep',
        props: ["keep"]
    }
</script>

<style scoped>

</style>