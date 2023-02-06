<template>
    <v-container>
        <v-layout column>
            <v-row>
                <v-col>
                    <v-layout justify-center align-center column pa-5>
                        <div
                            class="display-2 font-weight-black black--text text-xs-center"
                        >
                            Download the Executive Hand App
                        </div>
                        <div
                            class="display-1 font-weight-bold black--text text-xs-center"
                        >
                            For easier booking,Live notifications and Instant
                            messages
                        </div>
                    </v-layout>
                </v-col>
            </v-row>

            <v-row>
                <v-col cols="4"></v-col>
                <v-col cols="2">
                    <v-img :src="require('@/assets/google-play.png')"></v-img>
                </v-col>
                <v-col cols="2">
                    <v-img :src="require('@/assets/apple-store.png')"></v-img>
                </v-col>
                <v-col></v-col>
            </v-row>

            <v-flex>
                <div class="headline mt-3">
                    Vetted, Background-Checked Professionals
                </div>
                <p class="subheading mt-3">
                    Cleaning and handyman tasks booked and paid for directly
                    through the Handy platform are performed by experienced,
                    background-checked professionals who are highly rated by
                    customers like you. Learn more.
                </p>

                <p class="subheading mt-3">
                    Nullam nec massa eu est fringilla lobortis. Praesent in enim
                    in justo blandit varius. Cras placerat arcu in sapien
                    rhoncus aliquet. Sed interdum tortor et tincidunt
                    condimentum. Etiam consequat mi leo, in suscipit odio
                    scelerisque molestie. Nam et purus consequat, iaculis augue
                    vel, sagittis ligula. Vestibulum aliquet vulputate erat.
                    Phasellus id mauris mauris. Nunc a maximus dolor. Curabitur
                    ut vestibulum arcu. Curabitur non lacus justo. Cras varius a
                    magna in semper. Nulla eros ante, consectetur faucibus
                    sapien eu, rhoncus imperdiet dui. Sed viverra iaculis nunc,
                    id pulvinar massa egestas vitae.
                </p>

                <p class="subheading mt-3">
                    Aenean erat metus, imperdiet eget nisl laoreet, venenatis
                    ultricies ante. In interdum ante vel dictum ullamcorper.
                    Pellentesque habitant morbi tristique senectus et netus et
                    malesuada fames ac turpis egestas. Integer sit amet gravida
                    diam. Aliquam in tempor metus. Fusce pellentesque pharetra
                    sem, et luctus justo tempor dictum. Ut feugiat est sed
                    tristique egestas. Nullam posuere a nunc in blandit.
                    Vestibulum ante ipsum primis in faucibus orci luctus et
                    ultrices posuere cubilia Curae; Suspendisse laoreet ultrices
                    eros, nec malesuada enim semper sit amet. Maecenas efficitur
                    consectetur accumsan. Etiam in aliquam turpis, ut pharetra
                    nulla. Vestibulum malesuada, nulla id elementum cursus, nibh
                    dui rhoncus felis, suscipit mattis felis enim sed ex.
                    Pellentesque scelerisque aliquam lorem, vel mattis nibh
                    tincidunt ac. Suspendisse ac nibh sit amet lacus ullamcorper
                    maximus.
                </p>
            </v-flex>
            <v-flex>
                <div class="headline mt-3">Lorem ipsum</div>
                <p class="subheading mt-3">
                    Nullam nec massa eu est fringilla lobortis. Praesent in enim
                    in justo blandit varius. Cras placerat arcu in sapien
                    rhoncus aliquet. Sed interdum tortor et tincidunt
                    condimentum. Etiam consequat mi leo, in suscipit odio
                    scelerisque molestie. Nam et purus consequat, iaculis augue
                    vel, sagittis ligula. Vestibulum aliquet vulputate erat.
                    Phasellus id mauris mauris. Nunc a maximus dolor. Curabitur
                    ut vestibulum arcu. Curabitur non lacus justo. Cras varius a
                    magna in semper. Nulla eros ante, consectetur faucibus
                    sapien eu, rhoncus imperdiet dui. Sed viverra iaculis nunc,
                    id pulvinar massa egestas vitae.
                </p>
            </v-flex>
        </v-layout>
    </v-container>
</template>
<script>
export default {
    name: 'HomeDetails'
};
</script>

<style scoped></style>
