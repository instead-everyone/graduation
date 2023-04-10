if (!!window.ActiveXObject || 'ActiveXObject' in window) {
  alert('本系统不支持ie，请使用Chrome、Firefox、Edge等现代浏览器访问！');
}

import { createApp, h, getCurrentInstance } from 'vue';

// 基础框架
import moohoBaseAdminPlus, { pages, App, store, i18n, basicLayout, createRouter, created, routeChanged } from 'mooho-base-admin-plus';

// 固定路由
import routes from './router/routes';
//import { frameInRoutes } from './router/routes';

// css
import 'mooho-base-admin-plus/dist/style.css';

// 自定义css
import './styles/css/custom.css';

// fa图标
import '@fortawesome/fontawesome-free/css/all.min.css';

// 环境模式
window.$mode = import.meta.env.MODE;

// 页面
const files = import.meta.globEager('./pages/**/*.vue');

Object.keys(files).forEach(key => {
  pages[key.replace(/(\.\/pages\/)/g, '')] = files[key].default;
});

// 创建路由
const router = createRouter(import.meta.env.VITE_APP_BASE_PATH, pages, basicLayout, routes);

const app = createApp({
  // mixins: [mixinApp],
  render: () => h(App),
  created() {
    created(app);

    // 将根实例存全局，可在特殊场景下调用
    if (window) {
      window.$app = getCurrentInstance();
      window.$app.$t = i18n.global.t;
    }
  },
  watch: {
    // 监听路由 控制侧边栏显示 标记当前顶栏菜单（如需要）
    $route(to, from) {
      routeChanged(to, from);
    }
  }
});

app.use(router);
app.use(store);
app.use(i18n);
app.use(moohoBaseAdminPlus);

app.mount('#app');
