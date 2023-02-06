<template>
    <v-container>
        <v-card class="mx-auto">
            <v-toolbar>
                <v-app-bar-nav-icon></v-app-bar-nav-icon>

                <v-toolbar-title
                    >Meet Some of Our Top {{ serviceName }} Professionals near
                    you</v-toolbar-title
                >

                <v-spacer></v-spacer>

                <v-btn icon>
                    <v-icon>mdi-magnify</v-icon>
                </v-btn>

                <v-btn icon>
                    <v-icon>mdi-dots-vertical</v-icon>
                </v-btn>
            </v-toolbar>
            <v-expansion-panels>
                <v-expansion-panel>
                    <v-expansion-panel-header>
                        Filter
                    </v-expansion-panel-header>
                    <v-expansion-panel-content>
                        <v-row>
                            <v-col class="ml-4 mt-0" cols="3"
                                ><v-text-field
                                    label="Enetr address,city or postal code"
                                ></v-text-field
                            ></v-col>
                            <v-col class="ml-0"
                                ><v-btn
                                    ><v-icon>location_on</v-icon>Use Current
                                    Location</v-btn
                                ></v-col
                            >
                            <v-col> </v-col>
                        </v-row>
                        <v-row>
                            <v-col class="ml-4">
                                <v-slider
                                    v-model="ex2.val"
                                    :max="max"
                                    :min="min"
                                    :label="ex2.label"
                                    :thumb-color="ex2.color"
                                    thumb-label="always"
                                >
                                </v-slider>
                            </v-col>
                            <v-col></v-col>
                        </v-row>
                        <v-row>
                            <v-col class="ml-4"
                                ><v-slider
                                    max="50"
                                    min="10"
                                    label="Price Range"
                                    :thumb-color="ex2.color"
                                    thumb-label="always"
                                >
                                </v-slider
                            ></v-col>
                            <v-col></v-col>
                        </v-row>
                    </v-expansion-panel-content>
                </v-expansion-panel>
            </v-expansion-panels>
            <v-card v-for="item in items" :key="item.title">
                <v-row class="ml-6" @click.stop="pushOtherPage">
                    <v-col cols="2">
                        <v-avatar size="200" :to="getRoute(item.route_url)">
                            <v-img
                                :src="
                                    getPic(item.profile_picture_path, item.uid)
                                "
                            ></v-img>
                        </v-avatar>
                    </v-col>
                    <v-col>
                        <v-card-title class="headline">
                            {{ item.first_name }} {{ item.last_name }}
                        </v-card-title>
                        <v-card-text>
                            <div class="text-left ml-8">
                                <v-rating
                                    v-model="rating"
                                    color="yellow darken-3"
                                    background-color="grey darken-1"
                                    empty-icon="$ratingFull"
                                    half-increments
                                    hover
                                    large
                                ></v-rating>
                            </div>
                            <div class="text-left ml-8">
                                <label for="" class="ml-8">$15.0/hour</label>
                                <label for="" class="ml-4">20 mile away</label>
                            </div>
                            <v-row>
                                <v-col class="text-right mt-0">
                                    <v-img
                                        :src="require('@/assets/exp.png')"
                                        max-height="15"
                                        max-width="15"
                                        style="float: right"
                                    ></v-img
                                ></v-col>
                                <v-col cols="11" class="text-left mt-0"
                                    ><p>179 jobs completed</p></v-col
                                >
                            </v-row>

                            Hi there, my name is Vanessa. I have been a
                            professional cleaner for over 10 years, here in the
                            Northwest. I have done many different kinds of
                            cleaning: offices, new construction, residential,
                            move-in/out, deep cleaning and general cleaning. I
                            work very well in homes that have kiddos and pets.
                            Please note I work from 9 AM-4 PM M-F Hope to Here
                            from you soon!!!
                        </v-card-text>
                    </v-col>
                </v-row>
            </v-card>
        </v-card>
    </v-container>
</template>

<script>
import RepositoryFactory from '@/repositories/CommonRepository.js';
const IP_ADDRESS = 'http://198.12.227.32:5050/uploads/';
// const IP_ADDRESS =
//     'C://Users//sami//Documents//GitLab//V2//cleaningapp//Server//uploads//';
export default {
    data() {
        return {
            serviceName: this.$route.params.item,
            serviceId: this.$route.params.id,
            range: [1, 30],
            min: 1,
            max: 30,
            rating: 4.5,
            ex2: { label: 'Mile range(Max 30)', val: 50, color: 'red' },
            items: [],
            // items: [
            //     {
            //         icon: true,
            //         title: 'Jason Oner',
            //         route_url: '/test',
            //         avatar: 'https://cdn.vuetifyjs.com/images/lists/1.jpg',
            //     },
            //     {
            //         title: 'Johns agent Ltd.',
            //         route_url: '/service',
            //         avatar: 'getPic(johns.png)',
            //     },
            //     {
            //         title: 'Travis Howard',
            //         route_url: '/test',
            //         avatar: 'https://cdn.vuetifyjs.com/images/lists/2.jpg',
            //     },
            //     {
            //         title: 'Ali Connors',
            //         route_url: '/service',
            //         avatar: 'https://cdn.vuetifyjs.com/images/lists/3.jpg',
            //     },
            //     {
            //         title: 'Cindy Baker',
            //         route_url: '/service',
            //         avatar: 'https://cdn.vuetifyjs.com/images/lists/4.jpg',
            //     },
            //     {
            //         title: 'elite agent Ltd.',
            //         route_url: '/service',
            //         avatar: 'getPic(elite.jpg)',
            //     },
            // ],
        };
    },
    created() {
        // this.serviceName = JSON.stringify(this.$router.params);
        console.log('params:=' + this.serviceName);
        console.log('params id:=' + this.serviceId);
        this.getUserList();
    },
    methods: {
        getRoute(url) {
            return url;
        },
        pushOtherPage() {
            console.log('click in Id column');
            this.$router.push({ name: 'service' });
        },
        getUserList() {
            RepositoryFactory.get(`/account/getUserByService/` + this.serviceId)
                .then((result) => {
                    if (result.status == 200) {
                        this.items = result.data.model;
                        console.log(this.items);
                    }
                })
                .catch((err) => {
                    console.log(err);
                });
        },
        getPic(pic, uid) {
            var address = '';
            if (uid) {
                address = pic;
            } else {
                address = IP_ADDRESS + pic;
            }

            return address;
        },
    },
};
</script>

<style></style>
