<template>
    <div class="container-fluid">
        <div class="row">
            <div class="col-12">
                <button type="button" class="btn btn-outline-danger" data-toggle="modal" data-target="#keepModal">
                    Create Keep
                </button>


                <div class="modal" id="keepModal" tabindex="-1" role="dialog" aria-labelledby="keepModalLabel"
                    aria-hidden="true">
                    <div class="modal-dialog" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title" id="keepModalLabel">Create a Keep!</h5>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                            <div class="modal-body">
                                <form @submit.prevent="createKeep">
                                    <input type="text" v-model="newKeep.name" placeholder="Give your Keep a Title!"
                                        required>
                                    <input type="text" v-model="newKeep.description" placeholder="Description"
                                        class="ml-2" id="desc">
                                    <input type="text" v-model="newKeep.img" placeholder="Add an Image!" class="ml-2"
                                        id="img">
                                    <div>
                                        <input type="checkbox" v-model="newKeep.isPrivate" class="form-check-input"
                                            id="privateCheck">
                                        <label for="privateCheck" class="form-check-label">Mark as Private?</label>
                                    </div>
                                    <div>
                                        <button type="submit" class="btn btn-primary">Create Keep</button>
                                        <button type="button" class="btn btn-outline-danger"
                                            data-dismiss="modal">Close</button>
                                    </div>
                                </form>
                            </div>
                            <div class="modal-footer">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <section class="row">
            <Keep v-for="keep in keeps" :keep="keep"></Keep>
        </section>

    </div>





</template>

<script>
    import Keep from "../components/Keep";
    import Vault from "../components/Vault";


    export default {
        name: "home",
        props: ["keep", "id"],
        components: { Keep, Vault },
        data() {
            return {
                newKeep: {}

            }
        },
        mounted() {
            //blocks users not logged in
            if (!this.$store.state.user.id) {
                this.$router.push({ name: "login" });
                this.$store.dispatch("getVaults");

            }
        },
        computed: {
            keeps() {
                return this.$store.state.keeps
            },
            vaults() {
                return this.$store.state.vaults
            },
        },
        methods: {
            
            createKeep() {
                let payload = {
                    name: this.newKeep.name,
                    description: this.newKeep.description,
                    img: this.newKeep.img,
                    isPrivate: this.newKeep.isPrivate || false,

                }
                console.log(payload)
                this.$store.dispatch("createKeep", payload);


            },

        },
    }
</script>

<style scoped>
    #try {
        display: flex;
        flex-wrap: wrap;
        justify-content: space-between;
    }

    .keeps {
        background-color: transparent;
    }

    #try2 {
        display: flex;
        flex-wrap: wrap;
        justify-content: space-between;
    }
</style>