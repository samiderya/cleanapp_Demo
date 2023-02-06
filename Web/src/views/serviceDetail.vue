<template>
    <v-container>
        <v-card>
            <v-card-title primary-title class="justify-center">
                <h1>{{ serviceType }}</h1>
            </v-card-title>
            <v-stepper v-model="e1">
                <v-stepper-header>
                    <v-stepper-step :complete="e1 > 1" step="1">
                        step 1
                    </v-stepper-step>

                    <v-divider></v-divider>

                    <v-stepper-step :complete="e1 > 2" step="2">
                        step 2
                    </v-stepper-step>

                    <v-divider></v-divider>

                    <v-stepper-step step="3">
                        step 3
                    </v-stepper-step>

                    <v-divider></v-divider>
                    <v-stepper-step step="4">
                        step 4
                    </v-stepper-step>
                </v-stepper-header>

                <v-stepper-items>
                    <v-stepper-content step="1">
                        <v-card class="mb-12" color="cyan lighten-5">
                            <v-card-text>
                                <v-text-field
                                    v-model="zipCode"
                                    label="ZIP Code"
                                    required
                                    @input="$v.zipCode.$touch()"
                                    @blur="$v.zipCode.$touch()"
                                ></v-text-field>
                                <v-select
                                    :items="itemsBedrooms"
                                    label="Bedrooms"
                                ></v-select>
                                <v-select
                                    :items="itemsBathrooms"
                                    label="Bathrooms"
                                ></v-select>

                                <label for=""
                                    >We recommend minimum 3 hours</label
                                >
                                <br />

                                <label style="text-center"
                                    >When would you like us to come?</label
                                >
                                <v-date-picker
                                    v-model="date"
                                    :update-on-input="false"
                                >
                                    <template
                                        v-slot="{ inputValue, inputEvents }"
                                    >
                                        <input
                                            class="bg-white border px-2 py-1 rounded"
                                            :value="inputValue"
                                            v-on="inputEvents"
                                        />
                                    </template>
                                </v-date-picker>

                                <v-select
                                    :items="itemsSchedule"
                                    label="Schedule"
                                ></v-select>
                            </v-card-text>
                        </v-card>

                        <v-btn color="primary" @click="e1 = 2">
                            Continue
                        </v-btn>

                        <v-btn text>
                            Cancel
                        </v-btn>
                    </v-stepper-content>

                    <v-stepper-content step="2">
                        <v-card class="mb-12" color="grey lighten-1">
                            <v-card-text>
                                <label for="">Package</label>
                                <v-select :items="itemPackage"></v-select>
                                <v-switch
                                    v-model="isPets"
                                    label="do you have pets?"
                                ></v-switch>
                            </v-card-text>
                        </v-card>

                        <v-btn color="primary" @click="e1 = 3">
                            Continue
                        </v-btn>

                        <v-btn text>
                            Cancel
                        </v-btn>
                    </v-stepper-content>

                    <v-stepper-content step="3">
                        <v-card class="mb-12" color="grey lighten-1">
                            <v-card-text>
                                <v-textarea
                                    outlined
                                    name="input-7-4"
                                    label="Do you have any note for us?"
                                ></v-textarea>
                                <v-text-field
                                    prepend-icon="person"
                                    name="email"
                                    label="Email"
                                    type="email"
                                    v-model="email"
                                    :rules="emailRules"
                                    required
                                    data-cy="signinEmailField"
                                >
                                </v-text-field>
                                <v-text-field
                                    prepend-icon="lock"
                                    name="password"
                                    label="Password"
                                    :type="showpassword ? 'text' : 'password'"
                                    data-cy="signinPasswordField"
                                    required
                                >
                                </v-text-field>
                            </v-card-text>
                        </v-card>

                        <v-btn color="primary" @click="e1 = 4">
                            Continue
                        </v-btn>

                        <v-btn text>
                            Cancel
                        </v-btn>
                    </v-stepper-content>
                    <v-stepper-content step="4">
                        <v-card class="mb-12" color="grey lighten-1">
                            <v-card-text>
                                <v-text-field
                                    name="input-7-4"
                                    label="Cardholder Name"
                                ></v-text-field>
                                <v-text-field
                                    prepend-icon="person"
                                    name="CardNumber"
                                    label="Card Number"
                                    required
                                >
                                </v-text-field>
                                <v-text-field label="Valid MMYY" required>
                                </v-text-field>
                                <v-text-field label="CRC" required>
                                </v-text-field>
                            </v-card-text>
                        </v-card>

                        <v-btn color="primary" @click="e1 = 0">
                            Continue
                        </v-btn>

                        <v-btn text>
                            Cancel
                        </v-btn>
                    </v-stepper-content>
                </v-stepper-items>
            </v-stepper>
        </v-card>
    </v-container>
</template>

<script>
export default {
    name: 'Service',
    data() {
        return {
            serviceType: 'Home Cleaning',
            e1: 1,
            email: '',
            date: new Date(),
            min: 1,
            max: 30,
            range: [1, 30],
            isPets: false,
            itemsBedrooms: [
                '1 Bedrooms',
                '2 Bedrooms',
                '3 Bedrooms',
                '4 Bedrooms',
                '5 Bedrooms',
                '6 Bedrooms'
            ],
            itemsBathrooms: [
                '1 Bathrooms',
                '2 Bathrooms',
                '3 Bathrooms',
                '4 Bathrooms',
                '5 Bathrooms',
                '6 Bathrooms'
            ],
            itemsSchedule: [
                '7 AM',
                '7.30 AM',
                '8 AM',
                '8.30 AM',
                '9 AM',
                '9.30 AM',
                '10.00 AM',
                '10.30 AM',
                '11.00 AM',
                '11.30 AM'
            ],
            itemPackage: ['One Time', 'Weekly', 'Every Two Week']
        };
    },
    created() {
        //  this.serviceType = this.$route.params.serviceType;
    }
};
</script>

<style></style>
