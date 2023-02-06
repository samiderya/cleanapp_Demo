<template>
    <v-container>
        <v-card>
            <v-card-title primary-title class="justify-center">
                <h1>Service Type</h1>
            </v-card-title>
            <v-list v-for="service in serviceItems">
                <v-list-group :value="true" no-action sub-group>
                    <template v-slot:activator>
                        <v-list-item-content>
                            <v-list-item-title>{{service.cleaning_type}}</v-list-item-title>
                        </v-list-item-content>
                    </template>

                    <v-list-item
                        v-for="([title, icon], i) in admins"
                        :key="i"
                        link
                    >
                        <v-list-item-title v-text="title"></v-list-item-title>

                        <v-list-item-icon>
                            <v-icon v-text="icon"></v-icon>
                        </v-list-item-icon>
                    </v-list-item>
                </v-list-group>
                
            </v-list>
        </v-card>
    </v-container>
</template>

<script>
import RepositoryFactory from '@/repositories/CommonRepository.js';
export default {
    data: () => ({
         serviceItems: [],
        admins: [
            ['Management', 'mdi-account-multiple-outline'],
            ['Settings', 'mdi-cog-outline'],
        ],
    }),
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

<style></style>
