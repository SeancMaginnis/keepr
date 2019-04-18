<template>
    <div class="coolNav">
    <nav class="navbar navbar-expand-lg bg">
        <a class="navbar-brand" href="#">Sean's Keepr</a>
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent"
                aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>

        <div class="collapse navbar-collapse" id="navbarSupportedContent">
            <ul class="navbar-nav mr-auto">
                <li class="nav-item active">
                    <a class="nav-link" href="#">Home <span class="sr-only">(current)</span></a>
                </li>
                
            </ul>
            <!--<span class="justify-content-center float-left ">
                <b  class="nav-link" data-toggle="modal" data-target="#exampleModal">
                    Create Keep
                </b>
            </span>-->
        </div>
    </nav>
    </div>
</template>

<script>
    
  
    export default {
        name: "navbar",
        data(){
            return{
                inVault: false,
            }
        }
        
        
        
    }
</script>

<style scoped>
.nav-link{
    border-color: #f90092;
}
.navbar-brand{
    color: #f90092;
}
    .bg{
        background-color: #191917;
    }
</style>