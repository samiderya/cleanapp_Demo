<template>
    <v-container grid-list-lg style="max-height: 100vh">
        <!-- <v-layout row>
            <v-flex xs12 class="text-xs-center display-1 font-weight-green--text my-5">Green Cleaning</v-flex>
        </v-layout> -->
        <v-layout row wrap>
            <v-flex
                xs12
                sm12
                md4
                v-for="(item, index) in dataItems"
                :key="index"
            >
                <v-card
                    :to="{
                        name: 'serviceList',
                        params: { item: item.cleaning_type, id: item.id },
                    }"
                >
                    <v-img
                        :src="getPic(item.imgName)"
                        v-bind:alt="item.imgName"
                        height="400px"
                    >
                    </v-img>
                    <v-card-title primary-title>
                        <div>
                            <h3 class="headline mb-0">
                                {{ item.cleaning_type }}
                            </h3>
                            <div>{{ item.descriptions }}</div>
                        </div>
                    </v-card-title>
                </v-card>
            </v-flex>
        </v-layout>
    </v-container>
</template>
<script>
const IP_ADDRESS = 'http://198.12.227.32:5050/uploads/';
export default {
    name: 'CleaningType',
    props: ['serviceItems'],
    data() {
        return {
            url: 'https://picsum.photos/id/11/500/300',
            dataItems: [],
            // dataItems:[
            //     {
            //         route_url:'/serviceList',
            //         imgName:'home.jpg',
            //         cleaning_type:'Home Cleaning',
            //         descriptions:'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam mauris felis, varius rutrum massa a, dignissim ornare dui. Cras eget velit eu dui tristique lobortis sit amet vel tellus.'
            //     },
            //        {
            //         route_url:'/service',
            //         imgName:'office-cleaning.jpg',
            //         cleaning_type:'Office Cleaning',
            //         descriptions:'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam mauris felis, varius rutrum massa a, dignissim ornare dui. Cras eget velit eu dui tristique lobortis sit amet vel tellus.'
            //     },
            //        {
            //         route_url:'/service',
            //         imgName:'construction.jpg',
            //         cleaning_type:'Constraction Cleaning',
            //         descriptions:'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam mauris felis, varius rutrum massa a, dignissim ornare dui. Cras eget velit eu dui tristique lobortis sit amet vel tellus.'
            //     }
            // ]
        };
    },
    watch: {
        serviceItems(val) {
            console.log('serviceItems=' + JSON.stringify(val));
            this.dataItems.push(...val);
        },
    },
    methods: {
        getPic(pic) {
            var address = IP_ADDRESS + pic;
            return address;
        },
        // getRoute(url){
        //     var rt="name: 'serviceList', params: { userId: 123 }";
        //     return rt;
        // }
    },
};
</script>
