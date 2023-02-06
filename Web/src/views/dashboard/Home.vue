<template>
    <span>
        <v-row>
            <v-col>
                <v-layout justify-center align-center column pa-5>
                    <div
                        class="display-2 font-weight-black black--text text-xs-center"
                    >
                        Executive hand
                    </div>
                    <div
                        class="display-1 font-weight-black black--text text-xs-center mb-3"
                    >
                        Book trusted
                    </div>
                    <div
                        class="display-1 font-weight-bold black--text text-xs-center"
                    >
                        The easy, reliable way to take care of your home.
                    </div>
                    <v-btn fab class="mt-5teal lighten-3">
                        <v-icon color="white"></v-icon>
                    </v-btn>
                </v-layout>
            </v-col>
        </v-row>
        <v-row mt-6>
            <v-col> </v-col>
            <v-col>
                <v-autocomplete
                    v-model="serviceType"
                    :loading="loading"
                    :items="serviceItems"
                    item-value="id"
                    item-text="cleaning_type"
                    placeholder="Start typing to Search"
                    prepend-icon="mdi-database-search"
                >
                </v-autocomplete>
            </v-col>

            <v-col>
                <v-btn color="primary" @click="getServices">Get Price</v-btn>
            </v-col>
        </v-row>

        <cleaning-type :service-items="serviceItems"></cleaning-type>

        <home-details style="margin-top:10px"></home-details>

        <home-hero> </home-hero>
    </span>
</template>

<script>
import HomeHero from '@/views/dashboard/HomeHero';
import HomeDetails from '@/views/dashboard/HomeDetails.vue';
import CleaningType from '@/views/dashboard/CleaningType.vue';
import RepositoryFactory from '@/repositories/CommonRepository.js';
export default {
    name: 'Home',
    components: {
        HomeHero,
        HomeDetails,
        CleaningType
    },
    data() {
        return {
            loading: false,
            serviceType: '',
            serviceItems: []
        };
    },
    created() {
        this.getServices();
    },
    methods: {
        getServices() {
            RepositoryFactory.get('cleaning/getAll')
                .then(result => {
                    console.log(
                        'result.data=' + JSON.stringify(result.data.model)
                    );
                    this.serviceItems.push(...result.data.model);
                })
                .catch(err => {
                    console.log(err);
                    //  this.showError = true;
                    //  this.errorMessage = "Invalid Log In/Password. Try again with valid credentials";
                });
        }
    }
};
</script>
<style scoped>
.home-hero {
    /* background: url('http://source.unsplash.com/0BhSKStVtdM');*/
    /* background: url('../assets/background.jpg');*/
    background-size: cover;
    width: 100%;
    height: 100%;
}
</style>
