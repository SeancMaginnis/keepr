<template>
  <div class="home">
    <h1>Welcome Home</h1>
    <Keep v-for="keep in keeps" :keep="keep"></Keep>
  </div>
</template>

<script>
  import Keep from "../components/Keep";
  export default {
    name: "home",
    components: {Keep},
    mounted() {
      //blocks users not logged in
      if (!this.$store.state.user.id) {
        this.$router.push({name: "login"})
      } else {
        this.$router.push({name: "keeps"})
      }
    },
    computed: {
      keeps() {
        return this.$store.state.keeps
      },
    }
  }
</script>