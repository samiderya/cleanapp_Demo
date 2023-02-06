<template>
    <v-container style="border: 1px solid red">
        <v-card>
            <v-card-title primary-title class="justify-center">
                <h1>{{ mainTitle }}</h1>
            </v-card-title>
            <v-row style="border: 1px solid red">
                <v-col cols="3" align="left">
                    <v-navigation-drawer permanent>
                        <v-system-bar></v-system-bar>
                        <v-list>
                            <v-list-item>
                                <v-list-item-avatar>
                                    <v-img
                                        src="https://cdn.vuetifyjs.com/images/john.png"
                                    ></v-img>
                                </v-list-item-avatar>
                            </v-list-item>
                            <v-list-item link>
                                <v-list-item-content>
                                    <v-list-item-title class="title">
                                        John Leider
                                    </v-list-item-title>
                                    <v-list-item-subtitle
                                        >john@vuetifyjs.com</v-list-item-subtitle
                                    >
                                </v-list-item-content>
                                <v-list-item-action>
                                    <v-icon>mdi-menu-down</v-icon>
                                </v-list-item-action>
                            </v-list-item>
                        </v-list>
                        <v-divider></v-divider>
                        <v-list nav dense>
                            <v-subheader>Setting</v-subheader>
                            <v-list-item-group
                                v-model="selectedItem"
                                color="primary"
                            >
                                <v-list-item
                                    v-for="(item, i) in items"
                                    :key="i"
                                >
                                    <v-list-item-icon>
                                        <v-icon v-text="item.icon"></v-icon>
                                    </v-list-item-icon>
                                    <v-list-item-content>
                                        <v-list-item-title
                                            v-text="item.text"
                                        ></v-list-item-title>
                                        <v-list-item-subtitle
                                            v-text="item.subText"
                                        >
                                        </v-list-item-subtitle>
                                    </v-list-item-content>
                                </v-list-item>
                            </v-list-item-group>
                        </v-list>
                        <template v-slot:append>
                            <div class="pa-2">
                                <v-btn block> Logout </v-btn>
                            </div>
                        </template>
                    </v-navigation-drawer>
                </v-col>
                <v-col>
                    <v-tabs
                        background-color="transparent"
                        color="basil"
                        v-model="tabModel"
                        align-with-title
                    >
                        <v-tab v-for="item1 in items" :key="item1.id">
                            {{ item1.text }}
                        </v-tab>
                    </v-tabs>

                    <v-tabs-items v-model="selectedItem">
                        <v-tab-item>
                            <v-card>
                                <v-row>
                                    <v-col cols="2"> </v-col>
                                    <v-col> 0 complited </v-col>
                                </v-row>
                                <v-row>
                                    <v-col cols="2">
                                        <v-icon color="grey lighten-1">
                                            mdi-star-outline
                                        </v-icon></v-col
                                    >
                                    <v-col> 42 Farley lane,ancaster,ON </v-col>
                                </v-row>
                                <v-row>
                                    <v-col cols="2"> </v-col>
                                    <v-col><h3>Customer Comments</h3> </v-col>
                                </v-row>
                                <v-row v-for="n in 5" :key="n">
                                    <v-col cols="1">{{ n }} </v-col>
                                    <v-col cols="1">
                                        <v-icon color="grey lighten-1">
                                            mdi-star-outline
                                        </v-icon>
                                    </v-col>
                                    <v-col cols="9"> </v-col>
                                    <v-col> (0) </v-col>
                                </v-row>
                            </v-card>
                        </v-tab-item>
                        <v-tab-item style="border: 11px solid red">
                            <v-card> Services </v-card>
                        </v-tab-item>
                        <v-tab-item>
                            <v-card> Balance & Payments </v-card>
                        </v-tab-item>
                        <v-tab-item>
                            <v-card> Payment settings </v-card>
                        </v-tab-item>
                    </v-tabs-items>
                </v-col>
            </v-row>
        </v-card>
    </v-container>
</template>
<script>
import { infoView } from './info';
export default {
    components: {
        infoView,
    },
    data: () => ({
        selectedItem: 0,
        tabModel: 0,
        mainTitle: 'Profile',
        items: [
            {
                id: 1,
                text: 'Profile',
                subText: 'You can update your email,address..',
                icon: 'mdi-clock',
            },
            {
                id: 2,
                text: 'Services',
                subText: 'You can add & update your services',
                icon: 'mdi-account',
            },
            {
                id: 3,
                text: 'Balance & Payments',
                subText: 'You can see your Balance & Payment',
                icon: 'mdi-flag',
            },
            {
                id: 4,
                text: 'Payments set',
                subText: 'You can set & update your bank account',
                icon: 'mdi-flag',
            },
            {
                id: 5,
                text: 'Support',
                subText: 'You can call& send issues',
                icon: 'mdi-flag',
            },
        ],
    }),
    watch: {
        selectedItem(id) {
            this.tabModel = id;
        },
    },
};
</script>