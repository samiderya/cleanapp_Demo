<template>
    <v-container fill-height>
        <v-layout align-center justify-center>
            <v-flex xs12 sm8 md4>
                <v-card class="elevation-12">
                    <v-toolbar dark color="teal lighten-3">
                        <v-toolbar-title>Login Form</v-toolbar-title>
                    </v-toolbar>
                    <v-card-text>
                        <v-form ref="form" v-model="valid">
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
                                :append-icon="
                                    showpassword ? 'mdi-eye' : 'mdi-eye-off'
                                "
                                name="password"
                                label="Password"
                                :type="showpassword ? 'text' : 'password'"
                                data-cy="signinPasswordField"
                                v-model="password"
                                :rules="passwordRules"
                                required
                                @click:append="showpassword = !showpassword"
                            >
                            </v-text-field>
                        </v-form>
                    </v-card-text>
                    <v-card-actions>
                        <v-spacer></v-spacer>
                        <v-btn color="success">Register</v-btn>
                        <v-btn
                            color="primary"
                            :disabled="!valid"
                            @click="submit"
                            data-cy="signinSubmitBtn"
                            >Login</v-btn
                        >
                    </v-card-actions>
                </v-card>
            </v-flex>
        </v-layout>
    </v-container>
</template>

<script>
export default {
    name: 'Signin',
    data() {
        return {
            valid: false,
            email: '',
            password: '',
            showpassword: false,
            emailRules: [
                v => !!v || 'E-mail is required',
                v => /.+@.+/.test(v) || 'E-mail must be valid'
            ],
            passwordRules: [
                v => !!v || 'Password is required',
                v =>
                    v.length >= 6 ||
                    'Password must be greater than 6 characters'
            ]
        };
    },
    methods: {
        submit() {
            if (this.$refs.form.validate()) {
                // this.$store.dispatch('userLogin', {
                //     email: this.email,
                //     password: this.password
                // });
            }
        }
    }
};
</script>

<style scoped></style>
