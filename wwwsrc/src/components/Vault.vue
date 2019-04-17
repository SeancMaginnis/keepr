<template>
    <div class="Vault">
      <div class="col-4" >
          <div class="card" style="width: 18rem;">
              <div class="card-body">
                  <h5 class="card-title">{{vault.name}}</h5>
                  <h6 class="card-subtitle mb-2 text-muted">{{vault.description}}</h6>
              </div>
          </div>
      </div>  
    </div>
</template>

<script>
    export default {
        name: "vault",
        props: ["vault"]
    }
</script>

<style scoped>

</style>