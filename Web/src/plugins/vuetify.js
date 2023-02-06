import Vue from 'vue';
import Vuetify from 'vuetify';
import Vuetify2 from 'vuetify/lib';

import 'vuetify/dist/vuetify.min.css';
//import 'material-design-icons-iconfont/dist/material-design-icons.css';
import '@fortawesome/fontawesome-free/css/all.css';
Vue.use(Vuetify, {
    iconfont: 'mdi' || 'md' || 'mdi' || 'fa' || 'fa4'
});
Vue.use(Vuetify2);
import Vuelidate from 'vuelidate';
Vue.use(Vuelidate);
const opts = {
    icons: {
        iconfont:
            'mdiSvg' || 'mdi' || 'mdiSvg' || 'md' || 'fa' || 'fa4' || 'faSvg'
    }
};
export default new Vuetify(opts);
