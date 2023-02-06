<template>
    <v-container>
        <v-card>
            <v-card-title primary-title class="justify-center">
                <h1>Be a Professional with Executive!</h1>
            </v-card-title>

            <v-row>
                <v-col></v-col>
                <v-col
                    >Gain access to hundreds of jobs in your city and build your
                    own schedule.</v-col
                >
                <v-col></v-col>
            </v-row>
            <v-stepper v-model="e1">
                <v-stepper-header>
                    <v-stepper-step :complete="e1 > 1" step="1">
                        {{ usrInfo }} Information
                    </v-stepper-step>

                    <v-divider></v-divider>

                    <v-stepper-step :complete="e1 > 2" step="2">
                        Work Experience
                    </v-stepper-step>

                    <v-divider v-if="!isAgent"></v-divider>
                    <v-stepper-step :complete="e1 > 3" step="3" v-if="!isAgent">
                        Quiz
                    </v-stepper-step>

                    <v-divider></v-divider>
                    <v-stepper-step :complete="e1 > 4" step="4" v-if="!isAgent">
                        {{ fileInfo }}
                    </v-stepper-step>
                    <v-stepper-step :complete="e1 > 3" step="3" v-else>
                        {{ fileInfo }}
                    </v-stepper-step>

                    <v-divider></v-divider>
                </v-stepper-header>
                <v-stepper-items>
                    <v-stepper-content step="1">
                        <v-row>
                            <v-col cols="2" class="ma-2">
                                <v-row>
                                    <v-switch
                                        class="ma-6"
                                        v-model="isAgent"
                                        label="Is Agent"
                                    ></v-switch>
                                </v-row>
                                <v-row class="mt-4">
                                    <v-avatar size="200" class="ml-4">
                                        <v-img :src="profilePic"></v-img>
                                    </v-avatar>
                                    <!-- <v-radio-group
                                        class="ml-4"
                                        v-model="gender"
                                        row
                                    >
                                        <v-radio
                                            label="Female"
                                            value="0"
                                        ></v-radio>
                                        <v-radio
                                            label="Male"
                                            value="1"
                                        ></v-radio>
                                    </v-radio-group> -->
                                </v-row>
                                <v-row class="ml-2">
                                    <v-col>
                                        <v-file-input
                                            ref="myUpload"
                                            v-model="userInfo.chosenPic"
                                            accept="image/png, image/jpeg, image/bmp"
                                            placeholder="Pick your Photo"
                                            prepend-icon="mdi-camera"
                                        >
                                        </v-file-input
                                    ></v-col>

                                    <!-- <form enctype="multipart/form-data"> -->
                                    <!-- <input
                                        type="file"
                                        v-on:change="getFile($event)"
                                        multiple
                                    /> -->
                                    <!-- </form> -->
                                </v-row>
                            </v-col>
                            <v-col>
                                <v-row class="ma-6">
                                    <v-col class="mt-4"
                                        ><v-autocomplete
                                            v-model="userInfo.prServiceType"
                                            :loading="loading"
                                            :items="primaryServiceItems"
                                            multiple
                                            outlined
                                            dense
                                            item-value="id"
                                            item-text="cleaning_type"
                                            placeholder="Service you want to give"
                                        >
                                        </v-autocomplete
                                    ></v-col>
                                    <v-col
                                        ><v-text-field
                                            :label="userName"
                                            v-model="userInfo.firstName"
                                            :error-messages="firstnameErrors"
                                            required
                                            @input="
                                                $v.userInfo.firstName.$touch()
                                            "
                                            @blur="
                                                $v.userInfo.firstName.$touch()
                                            "
                                        ></v-text-field
                                    ></v-col>
                                    <v-col v-if="!isAgent"
                                        ><v-text-field
                                            label="Last Name"
                                            v-model="userInfo.lastName"
                                            :rules="[rulesLastName.required]"
                                        ></v-text-field
                                    ></v-col>
                                </v-row>
                                <v-row class="mx-6">
                                    <v-col
                                        ><v-text-field
                                            v-model="userInfo.phone"
                                            :error-messages="phoneErrors"
                                            label="Phone #"
                                            required
                                            @input="$v.userInfo.phone.$touch()"
                                            @blur="$v.userInfo.phone.$touch()"
                                        ></v-text-field
                                    ></v-col>
                                    <v-col>
                                        <v-text-field
                                            v-model="userInfo.email"
                                            :error-messages="emailErrors"
                                            label="E-mail"
                                            required
                                            @input="$v.userInfo.email.$touch()"
                                            @blur="$v.userInfo.email.$touch()"
                                        ></v-text-field>
                                    </v-col>
                                </v-row>
                                <v-row class="ma-6">
                                    <v-col cols="6">
                                        <v-textarea
                                            outlined
                                            label="Address,City,Postal Code"
                                            v-model="userInfo.address"
                                            ref="search"
                                            :error-messages="addressErrors"
                                            required
                                            @input="
                                                $v.userInfo.address.$touch()
                                            "
                                            @blur="$v.userInfo.address.$touch()"
                                        ></v-textarea>
                                    </v-col>
                                    <v-col cols="6">
                                        <v-textarea
                                            outlined
                                            :label="
                                                isAgent
                                                    ? 'History-Tell us about your agent'
                                                    : 'History-Tell us about yourself'
                                            "
                                            v-model="userInfo.history"
                                        ></v-textarea>
                                    </v-col>
                                </v-row>
                            </v-col>
                        </v-row>
                        <v-row class="ml-12">
                            <v-col cols="10"> </v-col>

                            <v-col>
                                <v-btn
                                    @click="clear"
                                    color="error"
                                    class="mr-4"
                                >
                                    clear
                                </v-btn>
                                <v-btn color="success" @click="goTo(2)"
                                    >Next</v-btn
                                >
                            </v-col>
                        </v-row>
                    </v-stepper-content>
                    <v-stepper-content step="2">
                        <v-row>
                            <v-list class="ma-2" dense>
                                <v-subheader>Work Experiance</v-subheader>
                                <ul id="example-1">
                                    <li
                                        v-for="(item, i) in workExprince"
                                        :key="i"
                                    >
                                        {{ item.id }}- {{ item.quation }}
                                        <v-col v-if="i == 0">
                                            <v-combobox
                                                :items="item.choice.answer"
                                                label="Select"
                                                outlined
                                                dense
                                                v-model="workExInfo.paid"
                                            ></v-combobox
                                        ></v-col>
                                        <v-col v-else-if="i == 1">
                                            <v-radio-group
                                                v-model="workExInfo.rdlegal"
                                            >
                                                <v-layout align-start row>
                                                    <v-radio
                                                        v-for="n in item.choice
                                                            .answer"
                                                        :key="n"
                                                        :label="n"
                                                        :value="n"
                                                    />
                                                </v-layout>
                                            </v-radio-group>
                                        </v-col>
                                        <v-col v-else-if="i == 2">
                                            <v-text-field
                                                v-model="workExInfo.hearAbout"
                                            ></v-text-field>
                                        </v-col>
                                        <v-col v-else-if="i == 3">
                                            <v-text-field
                                                v-model="workExInfo.referalCode"
                                            ></v-text-field>
                                        </v-col>
                                        <v-col v-else>
                                            <v-combobox
                                                v-model="workExInfo.pCampany"
                                                :items="item.choice.answer"
                                                label="Select"
                                                outlined
                                                dense
                                            ></v-combobox
                                        ></v-col>
                                    </li>
                                </ul>
                            </v-list>
                        </v-row>
                        <v-row>
                            <v-col cols="10"></v-col>
                            <v-col>
                                <v-btn
                                    color="primary"
                                    class="mr-4"
                                    @click="goTo(1)"
                                    >Back</v-btn
                                >
                                <v-btn color="success" @click="goTo(3)"
                                    >Next</v-btn
                                >
                            </v-col>
                        </v-row>
                    </v-stepper-content>
                    <v-stepper-content step="3">
                        <v-row>
                            <v-list class="ma-2" dense>
                                <ul id="example-1">
                                    <li
                                        v-for="(item, index) in quizList"
                                        :key="index"
                                    >
                                        {{ item.id }}- {{ item.quation }}-{{
                                            quizInfo.chosen[index]
                                        }}
                                        <v-col>
                                            <v-radio-group
                                                v-model="
                                                    quizInfo.chosen[index].sel
                                                "
                                            >
                                                <v-radio
                                                    v-for="(
                                                        chitem, i
                                                    ) in item.listChoice"
                                                    :key="i"
                                                    :label="
                                                        sel[i] +
                                                        ')      ' +
                                                        chitem.choice
                                                    "
                                                    :value="sel[i]"
                                                />
                                            </v-radio-group>
                                        </v-col>
                                    </li>
                                </ul>
                            </v-list>
                        </v-row>
                        <v-row>
                            <v-col cols="10"> </v-col>
                            <v-col>
                                <v-btn
                                    color="primary"
                                    class="mr-4"
                                    @click="goTo(2)"
                                    >Back</v-btn
                                >
                                <v-btn color="success" @click="goTo(4)"
                                    >Next</v-btn
                                >
                            </v-col>
                        </v-row>
                    </v-stepper-content>
                    <v-stepper-content step="4">
                        <h2 primary-title class="justify-center">
                            Please Upload the necessary documents for Security
                            check
                        </h2>
                        <v-row>
                            <v-col>
                                <v-file-input
                                    v-model="bkCheckInfo.idCard"
                                    :rules="rules"
                                    accept="image/png, image/jpeg, image/bmp,application/pdf"
                                    placeholder="Upload your ID"
                                    prepend-icon="mdi-camera"
                                >
                                </v-file-input>
                            </v-col>
                        </v-row>
                        <v-row>
                            <v-col>
                                <v-file-input
                                    v-model="bkCheckInfo.sin"
                                    :rules="rules"
                                    accept="image/png, image/jpeg, image/bmp,application/pdf"
                                    placeholder="Upload your SIN"
                                    prepend-icon="mdi-camera"
                                >
                                </v-file-input>
                            </v-col>
                        </v-row>
                        <v-row>
                            <v-col cols="8"> </v-col>
                            <v-col>
                                <v-btn
                                    color="primary"
                                    class="mr-4"
                                    @click="goTo(3)"
                                    >Back</v-btn
                                >
                                <v-btn color="success" @click="saveInfo()"
                                    >Save/Finish</v-btn
                                >
                            </v-col>

                            <v-col></v-col>
                        </v-row>
                    </v-stepper-content>
                </v-stepper-items>
            </v-stepper>
            <v-snackbar
                v-model="snackbar.visible"
                auto-height
                :color="snackbar.color"
                :multi-line="snackbar.mode === 'multi-line'"
                :timeout="snackbar.timeout"
                :top="snackbar.position === 'top'"
            >
                <v-layout align-center pr-4>
                    <v-icon class="pr-3" dark large>{{ snackbar.icon }}</v-icon>
                    <v-layout column>
                        <div>
                            <strong>{{ snackbar.title }}</strong>
                        </div>
                        <div>{{ snackbar.text }}</div>
                    </v-layout>
                </v-layout>
                <v-btn
                    v-if="snackbar.timeout === 0"
                    icon
                    @click="snackbar.visible = false"
                >
                    <v-icon>clear</v-icon>
                </v-btn>
            </v-snackbar>
        </v-card>
    </v-container>
</template>

<script>
import { required, email } from 'vuelidate/lib/validators';
import RepositoryFactory from '@/repositories/CommonRepository.js';
const userType = Object.freeze({ Admin: 1, Selfemployed: 2, AgentCompany: 4 });
const loginType = Object.freeze({ app: 1, facebook: 2, twitter: 3, gmail: 4 });
export default {
    validations: {
        userInfo: {
            firstName: { required },
            // lastName: { required },
            phone: { required },
            address: { required },
            email: { required, email },
        },
        // paidExperiance: { required },
    },
    data() {
        return {
            rules: [
                (value) =>
                    !value ||
                    value.size < 2000000 ||
                    'Avatar size should be less than 2 MB!',
            ],
            rulesLastName: {
                required: (value) => !!value || 'Required.',
            },
            snackbar: {
                color: 'success',
                icon: 'check_circle',
                mode: 'multi-line',
                position: 'top',
                timeout: 7500,
                title: 'Success',
                text: 'That worked, hoorah.',
                visible: false,
            },
            // gender: '0',
            file: '',
            dd: 'Yes',
            userid: 0,
            agentid: 0,
            select: 1,
            fileInfo: 'background Check',
            searchResults: [],
            userName: 'First Name',
            e1: 1,
            usrInfo: 'Personal',
            isAgent: false,
            loading: false,
            profilePic: require('@/assets/defaultProfile.jpg'),
            primaryServiceItems: [],
            workExprince: [],
            quizList: [],
            chosenPicId: null,
            sel: ['A', 'B', 'C', 'D', 'E'],
            userInfo: {
                prServiceType: '',
                chosenPic: null,
                firstName: '',
                lastName: '',
                phone: '',
                email: '',
                address: '',
                history: '',
            },
            workExInfo: {
                paid: '0-6 months',
                rdlegal: 'Yes',
                hearAbout: '',
                referalCode: '',
                pCampany: 'I work individually',
            },
            quizInfo: {
                chosen: [],
            },
            bkCheckInfo: {
                idCard: null,
                sin: null,
            },
        };
    },
    created() {
        this.getWorkExperiance();
        this.getQuizList();
        this.getService();
    },
    computed: {
        firstnameErrors() {
            const errors = [];
            if (!this.$v.userInfo.firstName.$dirty) return errors;
            !this.$v.userInfo.firstName.required &&
                errors.push(this.userInfo.userName + ' is required.');
            return errors;
        },
        lastnameErrors() {
            const errors = [];
            if (!this.isAgent) {
                // if (!this.$v.userInfo.lastName.$dirty) return errors;
                !this.$v.userInfo.lastName.required &&
                    errors.push('Last Name is required.');
            }
            console.log('lastnameErrors={errors}', errors);
            return errors;
        },
        addressErrors() {
            const errors = [];
            if (!this.$v.userInfo.address.$dirty) return errors;
            !this.$v.userInfo.address.required &&
                errors.push('address is required.');
            return errors;
        },
        emailErrors() {
            const errors = [];
            if (!this.$v.userInfo.email.$dirty) return errors;
            !this.$v.userInfo.email.email &&
                errors.push('Must be valid e-mail');
            !this.$v.userInfo.email.required &&
                errors.push('E-mail is required');
            return errors;
        },
        phoneErrors() {
            const errors = [];
            if (!this.$v.userInfo.phone.$dirty) return errors;
            !this.$v.userInfo.phone.required &&
                errors.push('Phone is required');
            return errors;
        },
        // paidErrors() {
        //     const errors = [];
        //     if (!this.$v2.paidExperiance.$dirty) return errors;
        //     !this.$v2.paidExperiance.required &&
        //         errors.push('Paid cleaning experiance is required');
        //     return errors;
        // },
    },
    watch: {
        'userInfo.chosenPic'(file) {
            if (file) {
                const reader = new FileReader();
                reader.onload = (e) => {
                    this.profilePic = e.target.result;
                    // console.log(this.$refs.myUpload);
                };
                reader.readAsDataURL(file);
            }
        },

        isAgent(val) {
            this.usrInfo = val == true ? 'Agent' : 'Personal';
            this.userName = val == true ? 'Agent Name' : 'First Name';
            this.fileInfo =
                val == true ? 'Files necessary' : 'background Check';
        },
    },
    //   mounted() {
    //       for (let ref in this.$refs) {
    //       const autocomplete = new google.maps.places.Autocomplete(this.$refs[ref]);
    //       autocomplete.addListener("place_changed", () => {
    //         const place = autocomplete.getPlace();
    //         console.log("place="+place);
    //        })
    //       }
    //     },
    methods: {
        getWorkExperiance() {
            RepositoryFactory.get(`/test/getWorkExperiance`)
                .then((result) => {
                    console.log(
                        'workExprince.data=' + JSON.stringify(result.data.model)
                    );
                    this.workExprince = result.data.model;
                })
                .catch((err) => {
                    console.log(err);
                });
        },
        getQuizList() {
            RepositoryFactory.get(`/quiz/GetQuiz`)
                .then((result) => {
                    this.quizList = result.data.model;

                    this.quizList.forEach((element) => {
                        console.log('element.id=' + element.id);
                        this.quizInfo.chosen.push({
                            id: element.id,
                            sel: null,
                        });
                    });
                })
                .catch((err) => {
                    console.log(err);
                });
        },
        getService() {
            RepositoryFactory.get(`/cleaning/getAll`)
                .then((result) => {
                    this.primaryServiceItems = result.data.model;
                })
                .catch((err) => {
                    console.log(err);
                });
        },
        getFile(event) {
            this.file = event.target.files[0];
            if (this.file) {
                const reader = new FileReader();
                reader.onload = (e) => {
                    this.profilePic = e.target.result;
                    // console.log(this.$refs.myUpload);
                };
                reader.readAsDataURL(this.file);
            }
        },
        goTo(param) {
            alert(this.e1);
            if (param == 2) {
                this.$v.$touch();
                if (this.$v.$error) return;
            }
            if (param == 3 && this.isAgent) {
                if (this.e1 == 2) param = param + 1;
            }
            if (param == 3 && this.isAgent) {
                if (this.e1 == 4) param = param - 1;
            }
            this.e1 = param;
        },
        clear() {
            this.$v.$reset();
            this.firstName = '';
            this.lastName = '';
            this.email = '';
        },

        saveInfo() {
            this.$v.userInfo.$touch();
            if (this.$v.userInfo.$error) return;

            if (this.isAgent) {
                //Create Agent
                this.createAgent();
            } else {
                console.log(this.profilePic + 'pic');
                console.log(this.userInfo.chosenPic + 'chpic');
                let config = {
                    headers: {
                        'Content-Type': 'multipart/form-data',
                    },
                };
                var formData = new FormData();
                formData.append('serviceId', this.userInfo.prServiceType);
                formData.append('file', this.userInfo.chosenPic);
                formData.append('first_name', this.userInfo.firstName);
                formData.append('last_name', this.userInfo.lastName);
                formData.append('phone_no', this.userInfo.phone);
                formData.append('email', this.userInfo.email);
                formData.append('address', this.userInfo.address);
                formData.append('history', this.userInfo.history);
                formData.append('user_typeid', userType.Selfemployed);
                formData.append('login_typeid', loginType.app);
                RepositoryFactory.post('/account/Register', formData, config)
                    .then((result) => {
                        if (result.status == 200) {
                            this.userid = result.data.model.id;
                            this.saveWorkExp();
                        } else {
                            alert(
                                'Error in the Agent/Personel Info.,please try again'
                            );
                        }
                    })
                    .catch((err) => {
                        console.log(err + '=Error in the Agent/Personel Info');
                        //  this.showError = true;
                        //  this.errorMessage = "Invalid Log In/Password. Try again with valid credentials";
                    });
            }
        },
        saveWorkExp() {
            let payload = [
                { userid: this.userid, Qid: 1, Qanswer: this.workExInfo.paid },
                {
                    userid: this.userid,
                    Qid: 2,
                    Qanswer: this.workExInfo.rdlegal,
                },
                {
                    userid: this.userid,
                    Qid: 3,
                    Qanswer: this.workExInfo.hearAbout,
                },
                {
                    userid: this.userid,
                    Qid: 4,
                    Qanswer: this.workExInfo.referalCode,
                },
                {
                    userid: this.userid,
                    Qid: 5,
                    Qanswer: this.workExInfo.pCampany,
                },
            ];
            RepositoryFactory.post('/general/Save', payload)
                .then((result) => {
                    if (result.status == 200) {
                        this.isAgent ? this.SaveBkCheck() : this.SaveQuiz();
                    } else {
                        alert('Error in the saveWorkExp.,please try again');
                    }
                })
                .catch((err) => {
                    console.log(err);
                    //  this.showError = true;
                    //  this.errorMessage = "Invalid Log In/Password. Try again with valid credentials";
                });
        },
        SaveQuiz() {
            var payload = [];
            this.quizInfo.chosen.forEach((element) => {
                payload.push({
                    userid: this.userid,
                    Qid: element.id,
                    Qanswer: element.sel,
                });
            });
            RepositoryFactory.post('/quiz/Save', payload)
                .then((result) => {
                    if (result.status == 200) {
                        this.SaveBkCheck();
                    } else {
                        alert('Error in the SaveQuiz.,please try again');
                    }
                    console.log(result.data);
                })
                .catch((err) => {
                    console.log(err);
                    //  this.showError = true;
                    //  this.errorMessage = "Invalid Log In/Password. Try again with valid credentials";
                });
        },
        SaveBkCheck() {
            var formData = new FormData();
            formData.append('userid', this.userid);
            formData.append('file_sin', this.bkCheckInfo.sin);
            formData.append('file_id', this.bkCheckInfo.idCard);

            RepositoryFactory.post('/backgroundcheck/Save', formData)
                .then((result) => {
                    if (result.status == 200) {
                        this.snackbar.text =
                            'successfully completed,we will contact you soon';
                        this.snackbar.visible = true;
                        this.bkCheckInfo.sin = null;
                        this.bkCheckInfo.idCard = null;
                        ///  this.$router.push({ name: 'profile' });
                    } else {
                        alert('Error in the SaveBkCheck.,please try again');
                        this.snackbar.text =
                            'Error in the SaveBkCheck.,please try again';
                        this.snackbar.visible = true;
                    }
                })
                .catch((err) => {
                    console.log(err);
                    //  this.showError = true;
                    //  this.errorMessage = "Invalid Log In/Password. Try again with valid credentials";
                });
        },
        createUser() {
            let config = {
                headers: {
                    'Content-Type': 'multipart/form-data',
                },
            };

            var formData = new FormData();
            formData.append('serviceId', this.userInfo.prServiceType);
            formData.append('file', this.userInfo.chosenPic);
            formData.append('first_name', this.userInfo.firstName);
            formData.append('last_name', this.userInfo.lastName);
            formData.append('phone_no', this.userInfo.phone);
            formData.append('email', this.userInfo.email);
            formData.append('address', this.userInfo.address);
            formData.append('history', this.userInfo.history);
            formData.append(
                'user_typeid',
                this.isAgent ? userType.AgentCompany : userType.Selfemployed
            );
            formData.append('login_typeid', loginType.app);
            RepositoryFactory.post('/account/Register', formData, config)
                .then((result) => {
                    console.log('Register res=' + JSON.stringify(result));
                    if (result.status == 200) {
                        this.userid = result.data.model.id;
                        if (this.isAgent) this.SaveAgentUser();
                        this.saveWorkExp();
                    } else {
                        alert('Error in createUser.,please try again');
                    }
                })
                .catch((err) => {
                    this.snackbar.text =
                        err + '=Error in the createUser.,please try again';
                    this.snackbar.visible = true;
                    console.log(err + '=Error in createUser');
                    //  this.showError = true;
                    //  this.errorMessage = "Invalid Log In/Password. Try again with valid credentials";
                });
        },
        createAgent() {
            let config = {
                headers: {
                    'Content-Type': 'multipart/form-data',
                },
            };
            var formData = new FormData();
            formData.append('serviceId', this.userInfo.prServiceType);
            formData.append('file', this.userInfo.chosenPic);
            formData.append('agent_name', this.userInfo.firstName);
            formData.append('phone_no', this.userInfo.phone);
            formData.append('email', this.userInfo.email);
            formData.append('address', this.userInfo.address);
            formData.append('history', this.userInfo.history);
            RepositoryFactory.post(`/agent/create`, formData, config)
                .then((result) => {
                    console.log('Agent result=' + JSON.stringify(result));
                    if (result.status === 200) {
                        this.agentid = result.data.id;
                        this.createUser();
                    } else {
                        alert('Error Fetching Data from Server');
                    }
                })
                .catch((err) => {
                    console.log(err);
                });
        },
        SaveAgentUser() {
            let data = {
                userid: this.userid,
                agent_id: this.agentid,
            };
            RepositoryFactory.post(`/agent/SaveAgentUser`, data)
                .then((result) => {
                    if (result.status === 200) {
                        console.log('save rxn agent user');
                    } else {
                        alert('Error Fetching Data from Server');
                    }
                })
                .catch((err) => {
                    console.log(err);
                });
        },
    },
};
</script>
