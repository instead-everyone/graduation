if (!!window.ActiveXObject || 'ActiveXObject' in window) {
  alert('本系统不支持ie，请使用Chrome、Firefox、Edge等现代浏览器访问！');
}

// 基础框架
import moohoBaseAdmin, { pages, Vue, App, router, store, i18n, basicLayout, created, routeChanged } from 'mooho-base-admin';

// 固定路由
import routes from './router/routes';
import { frameInRoutes } from './router/routes';

// 自定义css
import './styles/css/custom.css';

// 页面
const files = require.context('./pages', true, /\.vue$/);

files.keys().forEach(key => {
  pages[key.replace(/(\.\/)/g, '')] = files(key).default;
});

Vue.use(moohoBaseAdmin);

new Vue({
  router,
  store,
  i18n,
  render: h => h(App),
  async created() {
    routes.forEach(route => {
      router.addRoute(route);
    });
    created(frameInRoutes, pages, basicLayout, this);
  },
  watch: {
    // 监听路由
    $route(to, from) {
      routeChanged(to, from);
    }
  }
}).$mount('#app');
