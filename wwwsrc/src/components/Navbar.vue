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
                    <button class="btn" @click="goHome">Home </button>
                </li>
                <li class="nav-item active">
                    <button class="btn bt" @click="myProfile">My Profile</button>
                </li>
                <li class="nav-item active">
                    <button class="btn " @click="logout()">Logout</button>
                </li>
            </ul>
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
        },
        methods: {
            goHome(){
                this.$router.push('/')
            },
            myProfile(){
                this.$router.push('/vault')
            },
            logout() {
                this.$store.dispatch("logout");
            },
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
    .btn{
        color: #f90092;
    }
     .btn:hover{
        color: #9854bb;
    }
</style>