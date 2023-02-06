<template>
    <v-container>
        <v-card ma-16>
            <v-card-title>
                <h1>Register</h1>
            </v-card-title>
            <v-card-text>
                <v-text-field
                    v-model="firstname"
                    :error-messages="firstnameErrors"
                    label="First Name"
                    required
                    @input="$v.firstname.$touch()"
                    @blur="$v.firstname.$touch()"
                ></v-text-field>
                <v-text-field
                    v-model="lastname"
                    :error-messages="lastnameErrors"
                    label="Last Name"
                    required
                    @input="$v.lastname.$touch()"
                    @blur="$v.lastname.$touch()"
                ></v-text-field>
                <v-text-field
                    v-model="phone"
                    :error-messages="phoneErrors"
                    label="Phone #"
                    required
                    @input="$v.phone.$touch()"
                    @blur="$v.phone.$touch()"
                ></v-text-field>
                <v-text-field
                    v-model="email"
                    :error-messages="emailErrors"
                    label="E-mail"
                    required
                    @input="$v.email.$touch()"
                    @blur="$v.email.$touch()"
                ></v-text-field>
                <v-text-field
                    ref="password"
                    type="password"
                    v-model="pass"
                    v-validate="'required'"
                    label="password"
                    data-vv-name="pass"
                    required
                ></v-text-field>
                <v-text-field
                    v-model="pass2"
                    type="password"
                    v-validate="'required|confirmed:password'"
                    label="confirmed:password"
                    data-vv-name="pass"
                    required
                ></v-text-field>
            </v-card-text>
            <v-card-actions>
                <v-btn class="mr-4" color="primary" @click="submit">
                    submit
                </v-btn>
                <v-btn @click="clear" color="error">
                    clear
                </v-btn>
            </v-card-actions>
        </v-card>
    </v-container>
</template>
<script>
import { required, email } from 'vuelidate/lib/validators';

export default {
    validations: {
        firstname: { required },
        lastname: { required },
        phone: { required },
        email: { required, email }
    },

    data: () => ({
        firstname: '',
        lastname: '',
        phone: '',
        email: '',
        pass: '',
        pass2: ''
    }),

    computed: {
        firstnameErrors() {
            const errors = [];
            if (!this.$v.firstname.$dirty) return errors;
            !this.$v.firstname.required &&
                errors.push('First Name is required.');
            return errors;
        },
        lastnameErrors() {
            const errors = [];
            if (!this.$v.lastname.$dirty) return errors;
            !this.$v.lastname.required && errors.push('Last Name is required.');
            return errors;
        },
        emailErrors() {
            const errors = [];
            if (!this.$v.email.$dirty) return errors;
            !this.$v.email.email && errors.push('Must be valid e-mail');
            !this.$v.email.required && errors.push('E-mail is required');
            return errors;
        },
        phoneErrors() {
            const errors = [];
            if (!this.$v.phone.$dirty) return errors;
            !this.$v.phone.required && errors.push('Phone is required');
            return errors;
        }
    },

    methods: {
        submit() {
            this.$v.$touch();
        },
        clear() {
            this.$v.$reset();
            this.firstname = '';
            this.lastname = '';
            this.email = '';
        }
    }
};
</script>
