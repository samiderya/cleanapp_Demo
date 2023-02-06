<template>
    <span>
        <v-navigation-drawer
            app
            v-model="drawer"
            class="brown lighten-2"
            dark
            disable-resize-watcher
        >
            <v-list>
                <template v-for="(item, index) in items">
                    <v-list-item :key="index">
                        <v-list-item-content>
                            {{ item.title }}
                        </v-list-item-content>
                    </v-list-item>
                    <v-divider :key="`divider-${index}`"></v-divider>
                </template>
            </v-list>
        </v-navigation-drawer>

        <v-app-bar app color="teal lighten-3" dark>
            <v-app-bar-nav-icon
                class="hidden-md-and-up"
                @click="drawer = !drawer"
            ></v-app-bar-nav-icon>
            <v-spacer class="hidden-md-and-up"></v-spacer>
            <v-toolbar-title @click="$router.push('/')"
                >{{ appTitle }}
            </v-toolbar-title>
            <v-spacer class="hidden-sm-and-down"></v-spacer>
            <v-btn
                rounded
                color="teal lighten-2"
                class="hidden-sm-and-down mx-4"
                to="/profission"
                >Become a Pro</v-btn
            >
            <v-btn
                rounded
                color="teal lighten-2"
                class="hidden-sm-and-down mx-4"
                to="/signin"
                >Sign in</v-btn
            >
            <v-btn
                rounded
                color="teal lighten-2"
                class="hidden-sm-and-down"
                to="/join"
                >Join</v-btn
            >
        </v-app-bar>
    </span>
</template>
<script>
export default {
    name: 'AppNavication',
    data() {
        return {
            appTitle: 'Executive Hand',
            drawer: false,
            items: [{ title: 'Menu' }, { title: 'Sign In' }, { title: 'Join' }]
        };
    }
};
</script>
