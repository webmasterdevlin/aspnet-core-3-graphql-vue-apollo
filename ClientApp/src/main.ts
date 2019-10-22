import '@babel/polyfill';
import Vue from 'vue';
import './plugins/axios';
import vuetify from './plugins/vuetify';
import App from './App.vue';
import router from './router';
import './registerServiceWorker';
import dateFilter from '@/filters/date.filter';
import ApolloClient from 'apollo-boost';
import VueApollo from 'vue-apollo';

Vue.config.productionTip = false;
Vue.filter('date', dateFilter);

const apolloProvider = new VueApollo({
  defaultClient: new ApolloClient({
    uri: 'https://localhost:5001/graphql',
  }),
});
Vue.use(VueApollo);
new Vue({
  vuetify,
  router,
  apolloProvider,
  render: (h: any) => h(App),
}).$mount('#app');
