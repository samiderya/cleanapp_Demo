<template>
    <v-container>
        <v-card>
            <v-card-title primary-title class="justify-center">
                <h1>Users List</h1>
            </v-card-title>
            <v-data-table
                :headers="headers"
                :items="userList"
                sort-by="first_name"
                class="elevation-1"
            >
                <template v-slot:top>
                    <v-toolbar flat>
                        <v-toolbar-title>My CRUD</v-toolbar-title>
                        <v-divider class="mx-4" inset vertical></v-divider>
                        <v-spacer></v-spacer>
                        <v-dialog v-model="dialog" persistent max-width="50%">
                            <v-card>
                                <v-tabs>
                                    <v-tab active> Personal Information </v-tab>
                                    <v-tab> Work Experience </v-tab>
                                    <v-tab>Quiz</v-tab>
                                    <v-tab>background Check</v-tab>
                                    <v-tab-item
                                        ><v-card>
                                            <!-- <v-card-title>
                                                <span class="headline"
                                                    >Personal Information</span
                                                >
                                            </v-card-title> -->

                                            <v-card-text>
                                                <v-container>
                                                    <v-row>
                                                        <v-col
                                                            cols="12"
                                                            sm="6"
                                                            md="4"
                                                        >
                                                            <v-text-field
                                                                v-model="
                                                                    editedItem.first_name
                                                                "
                                                                label="First Name"
                                                            ></v-text-field>
                                                        </v-col>
                                                        <v-col
                                                            cols="12"
                                                            sm="6"
                                                            md="4"
                                                        >
                                                            <v-text-field
                                                                v-model="
                                                                    editedItem.last_name
                                                                "
                                                                label="Last Name"
                                                            ></v-text-field>
                                                        </v-col>
                                                        <v-col
                                                            cols="12"
                                                            sm="6"
                                                            md="4"
                                                        >
                                                            <v-text-field
                                                                v-model="
                                                                    editedItem.email
                                                                "
                                                                label="Email"
                                                            ></v-text-field>
                                                        </v-col>
                                                        <v-col
                                                            cols="12"
                                                            sm="6"
                                                            md="4"
                                                        >
                                                            <v-text-field
                                                                v-model="
                                                                    editedItem.phone_no
                                                                "
                                                                label="Phone#"
                                                            ></v-text-field>
                                                        </v-col>
                                                        <v-col
                                                            cols="12"
                                                            sm="6"
                                                            md="4"
                                                        >
                                                            <v-text-field
                                                                v-model="
                                                                    editedItem.address
                                                                "
                                                                label="Address"
                                                            ></v-text-field>
                                                        </v-col>
                                                    </v-row>
                                                </v-container>
                                            </v-card-text>

                                            <v-card-actions>
                                                <v-spacer></v-spacer>
                                                <v-btn
                                                    color="blue darken-1"
                                                    text
                                                    @click="close"
                                                >
                                                    Cancel
                                                </v-btn>
                                                <v-btn
                                                    color="blue darken-1"
                                                    text
                                                    @click="save"
                                                >
                                                    Save
                                                </v-btn>
                                            </v-card-actions>
                                        </v-card>
                                    </v-tab-item>
                                    <v-tab-item> b</v-tab-item>
                                    <v-tab-item> c</v-tab-item>
                                    <v-tab-item> d</v-tab-item>
                                </v-tabs>
                            </v-card>
                        </v-dialog>
                        <!-- <v-dialog v-model="dialog" max-width="500px">
                            <template v-slot:activator="{ on, attrs }">
                                <v-btn
                                    color="primary"
                                    dark
                                    class="mb-2"
                                    v-bind="attrs"
                                    v-on="on"
                                >
                                    New Item
                                </v-btn>
                            </template>
                            <v-card>
                                <v-card-title>
                                    <span class="headline">{{
                                        formTitle
                                    }}</span>
                                </v-card-title>

                                <v-card-text>
                                    <v-container>
                                        <v-row>
                                            <v-col cols="12" sm="6" md="4">
                                                <v-text-field
                                                    v-model="
                                                        editedItem.first_name
                                                    "
                                                    label="First Name"
                                                ></v-text-field>
                                            </v-col>
                                            <v-col cols="12" sm="6" md="4">
                                                <v-text-field
                                                    v-model="
                                                        editedItem.last_name
                                                    "
                                                    label="Last Name"
                                                ></v-text-field>
                                            </v-col>
                                            <v-col cols="12" sm="6" md="4">
                                                <v-text-field
                                                    v-model="editedItem.email"
                                                    label="Email"
                                                ></v-text-field>
                                            </v-col>
                                            <v-col cols="12" sm="6" md="4">
                                                <v-text-field
                                                    v-model="
                                                        editedItem.phone_no
                                                    "
                                                    label="Phone#"
                                                ></v-text-field>
                                            </v-col>
                                            <v-col cols="12" sm="6" md="4">
                                                <v-text-field
                                                    v-model="editedItem.address"
                                                    label="Address"
                                                ></v-text-field>
                                            </v-col>
                                        </v-row>
                                    </v-container>
                                </v-card-text>

                                <v-card-actions>
                                    <v-spacer></v-spacer>
                                    <v-btn
                                        color="blue darken-1"
                                        text
                                        @click="close"
                                    >
                                        Cancel
                                    </v-btn>
                                    <v-btn
                                        color="blue darken-1"
                                        text
                                        @click="save"
                                    >
                                        Save
                                    </v-btn>
                                </v-card-actions>
                            </v-card>
                        </v-dialog> -->
                        <v-dialog v-model="dialogDelete" max-width="500px">
                            <v-card>
                                <v-card-title class="headline"
                                    >Are you sure you want to delete this
                                    item?</v-card-title
                                >
                                <v-card-actions>
                                    <v-spacer></v-spacer>
                                    <v-btn
                                        color="blue darken-1"
                                        text
                                        @click="closeDelete"
                                        >Cancel</v-btn
                                    >
                                    <v-btn
                                        color="blue darken-1"
                                        text
                                        @click="deleteItemConfirm"
                                        >OK</v-btn
                                    >
                                    <v-spacer></v-spacer>
                                </v-card-actions>
                            </v-card>
                        </v-dialog>
                    </v-toolbar>
                </template>
                <template v-slot:item.is_active="{ item }">
                    <v-chip :color="getColor(item.is_active)" dark>
                        {{ item.is_active == 1 ? 'active' : 'InProgress' }}
                    </v-chip>
                </template>
                <template v-slot:item.actions="{ item }">
                    <v-icon small class="mr-4" @click="editItem(item)">
                        mdi-pencil
                    </v-icon>
                    <v-icon small class="mr-6" @click="deleteItem(item)">
                        mdi-delete
                    </v-icon>
                    <v-icon small @click="showItem(item)"> mdi-magnify </v-icon>
                </template>
                <template v-slot:no-data>
                    <v-btn color="primary" @click="initialize"> Reset </v-btn>
                </template>
            </v-data-table>
        </v-card>
    </v-container>
</template>

<script>

import RepositoryFactory from '@/repositories/CommonRepository.js';
export default {
    data: () => ({
        dialog: false,
        dialogDelete: false,
        dialogAll: false,
        headers: [
            {
                text: 'First Name',
                align: 'start',
                sortable: false,
                value: 'first_name',
            },
            { text: 'Last Name', value: 'last_name' },
            { text: 'E-mail', value: 'email' },
            { text: 'Phone#', value: 'phone_no' },
            { text: 'Address', value: 'address' },
            { text: 'Status', value: 'is_active', sortable: false },
            { text: 'Actions', value: 'actions', sortable: false },
        ],
        userList: [],
        editedIndex: -1,
        editedItem: {
            first_name: '',
            last_name: '',
            email: '',
            phone_no: '',
            address: '',
        },
        defaultItem: {
            first_name: '',
            last_name: '',
            email: '',
            phone_no: '',
            address: '',
        },
    }),

    computed: {
        formTitle() {
            return this.editedIndex === -1 ? 'New Item' : 'Edit Item';
        },
    },

    watch: {
        dialog(val) {
            val || this.close();
        },
        dialogDelete(val) {
            val || this.closeDelete();
        },
    },

    created() {
        this.initialize();
    },

    methods: {
        initialize() {
            RepositoryFactory.get(`/account/getUsers`)
                .then((result) => {
                    if (result.status == 200) {
                        this.userList = result.data.model;
                        console.log(this.userList);
                    }
                })
                .catch((err) => {
                    console.log(err);
                });
        },

        editItem(item) {
            this.editedIndex = this.userList.indexOf(item);
            this.editedItem = Object.assign({}, item);
            this.dialog = true;
        },
        showItem(item) {
            this.editedIndex = this.userList.indexOf(item);
            this.editedItem = Object.assign({}, item);
            this.dialog = true;
        },

        deleteItem(item) {
            this.editedIndex = this.userList.indexOf(item);
            this.editedItem = Object.assign({}, item);
            this.dialogDelete = true;
        },

        deleteItemConfirm() {
            this.userList.splice(this.editedIndex, 1);
            this.closeDelete();
        },

        close() {
            this.dialog = false;
            this.$nextTick(() => {
                this.editedItem = Object.assign({}, this.defaultItem);
                this.editedIndex = -1;
            });
        },

        closeDelete() {
            this.dialogDelete = false;
            this.$nextTick(() => {
                this.editedItem = Object.assign({}, this.defaultItem);
                this.editedIndex = -1;
            });
        },

        save() {
            if (this.editedIndex > -1) {
                Object.assign(this.userList[this.editedIndex], this.editedItem);
            } else {
                this.userList.push(this.editedItem);
            }
            this.close();
        },
        getColor(val) {
            if (val == 0) return 'red';
            else if (val < 0) return 'orange';
            else return 'green';
        },
    },
};
</script>
