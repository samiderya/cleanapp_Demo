<template>
    <v-container fluid fill-height class="home-hero" style="max-height: 100vh;">
        <v-layout justify-center align-center column pa-5>
            <div class="display-4 font-weight-black white--text text-xs-center">
                Executive hand
            </div>
            <div
                class="display-2 font-weight-black white--text text-xs-center mb-3"
            >
                Book trusted
            </div>
            <div class="display-1 font-weight-bold white--text text-xs-center">
                The easy, reliable way to take care of your home.
            </div>
            <v-btn fab class="mt-5teal lighten-3">
                <v-icon color="white"></v-icon>
            </v-btn>
        </v-layout>
    </v-container>
</template>

<script>
export default {
    name: 'HomeHero'
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.home-hero {
    /*background: url('http://source.unsplash.com/0BhSKStVtdM');*/
    background-image: url('../../assets/background.jpg');
    background-size: cover;
    width: 100%;
    height: 100%;
}
</style>
