<template>
    <v-app>
        <app-navigation></app-navigation>
        <v-main transition="side-x-transition">
            <router-view />
        </v-main>
    </v-app>
</template>
<script>
import AppNavigation from './components/Nav';
export default {
    name: 'App',
    components: {
        AppNavigation
    }
};
</script>

<style></style>
