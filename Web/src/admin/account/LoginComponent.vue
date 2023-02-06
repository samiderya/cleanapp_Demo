<template>
    <div class="app flex-row align-items-center">
        <div class="container">
            <b-row class="justify-content-center">
                <b-col md="8">
                    <b-card-group>
                        <b-card no-body class="p-4">
                            <b-card-body class="login-screen">
                                <b-row>
                                    <b-col></b-col>
                                    <b-col cols="10">
                                        <b-row>
                                            <b-col></b-col>
                                            <b-col cols="3">
                                                <img
                                                    class=""
                                                    src="@/assets/img/lg-logo.png"
                                                    width="89"
                                                    height="25"
                                                    alt="In-Ctrl Logo"
                                                />
                                            </b-col>
                                            <b-col></b-col>
                                        </b-row>
                                        <b-row>
                                            <b-col cols="4" class="mx-auto">
                                                <p
                                                    class="text-muted text-center head"
                                                >
                                                    <img
                                                        class="navbar-brand-full"
                                                        src="@/assets/img/CTRL-logo-03.png"
                                                        height="50"
                                                        alt="In-Ctrl Logo"
                                                    />
                                                </p>
                                            </b-col>
                                        </b-row>
                                        <b-form>
                                            <label for="email" class="label"
                                                >LOG IN:</label
                                            >
                                            <b-input-group class="mb-4">
                                                <b-form-input
                                                    id="email"
                                                    type="text"
                                                    class=""
                                                    v-model="userName"
                                                ></b-form-input>
                                            </b-input-group>
                                            <label for="password" class="label"
                                                >PASSWORD:</label
                                            >
                                            <b-input-group class="mb-4">
                                                <b-form-input
                                                    id="password"
                                                    type="password"
                                                    class="form-control"
                                                    v-model="password"
                                                    @keydown.enter.native="
                                                        authenticateUser()
                                                    "
                                                ></b-form-input>
                                            </b-input-group>
                                            <b-alert
                                                v-model="showError"
                                                variant="danger"
                                                dismissible
                                                >{{ errorMessage }}
                                            </b-alert>
                                            <b-row>
                                                <b-col
                                                    cols="12"
                                                    class="text-right loginsBtnWrap"
                                                >
                                                    <b-button
                                                        variant="light"
                                                        class="px-5 py-2"
                                                        v-on:click="
                                                            clearForm()()
                                                        "
                                                    >
                                                        Cancel
                                                    </b-button>
                                                    <b-button
                                                        variant="success"
                                                        class="px-5 py-2"
                                                        v-on:click="
                                                            authenticateUser()
                                                        "
                                                        >Login
                                                    </b-button>
                                                </b-col>
                                            </b-row>
                                        </b-form>
                                    </b-col>
                                    <b-col></b-col>
                                </b-row>
                            </b-card-body>
                        </b-card>
                    </b-card-group>
                </b-col>
            </b-row>
        </div>
    </div>
</template>

<script>
//import  RepositoryFactory  from '@/repositories/RepositoryFactory';
import Authentication from '@/assets/scripts/authentication.js';

export default {
    name: 'LoginComponent',
    data: function() {
        return {
            userName: '',
            password: '',
            showError: false,
            errorMessage: ''
        };
    },
    methods: {
        authenticateUser: function() {
            console.log(Authentication);

            // _commonRepo
            //     .get(`/account/${this.userName}/${this.password}`)
            //     .then(data =>
            //     {
            Authentication.setUser(this.userName); //(data.data.model.userName);

            this.$router.push({ name: 'Home' });
            //     })
            //     .catch(err =>
            //     {
            //         console.error(err);
            //         alert(err.message);
            //     });

            // this.$router.push({ name: "Home" });

            // var componentContext = this;
            // if (
            //   componentContext.userName.length < 1 ||
            //   componentContext.password.length < 1
            // ) {
            //   componentContext.showError = true;
            //   componentContext.errorMessage = "Log In/Password cannot be empty !";
            // } else {
            //   this.$router.push({ name: "Home" });
            // _commonRepo.get("/account/"+ componentContext.userName + "/" + componentContext.password).then((result) => {
            //   if(result.status == 200 || result.status == 204){
            //     this.$router.push({ name: 'Home'});
            //     // if(result.data != null)
            //     //
            //     // else{
            //     //   componentContext.showError = true;
            //     //   componentContext.errorMessage = "Invalid Log In/Password. Try again with valid credentials";
            //     // }
            //   }
            //   else{
            //     componentContext.showError = true;
            //     componentContext.errorMessage = "Error Fetching Data from Server. Try again later.";
            //   }
            // })
            // }
        },
        clearForm() {
            var componentContext = this;
            componentContext.userName = '';
            componentContext.password = '';
        }
    }
};
</script>
<style media="screen" scoped>
.loginsBtnWrap button:last-child {
    margin-left: 1em;
}
</style>
