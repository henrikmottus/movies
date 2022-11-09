import { createApp } from "vue";

import App from "./App.vue";
import router from "./router";

import "./../node_modules/jquery/dist/jquery.min.js";
import "./../node_modules/foundation-sites/dist/css/foundation.min.css";
import "./../node_modules/foundation-sites/dist/js/foundation.min.js";

const app = createApp(App);

app.use(router);

app.mount("#app");
