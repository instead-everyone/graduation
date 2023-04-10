import { pages, basicLayout } from 'mooho-base-admin';

/**
 * 在主框架内显示
 */

const frameIn = [
  {
    path: '/',
    redirect: {
      name: 'login'
    },
    component: basicLayout,
    children: [
      {
        path: 'index',
        name: 'index',
        redirect: {
          name: 'home'
        }
      },
      // 首页
      {
        path: '/home',
        name: 'home',
        meta: {
          title: '首页',
          description: 'Home',
          closable: false
        },
        component: () => import('@/pages/home')
      },
      // 刷新页面 必须保留
      {
        path: 'refresh',
        name: 'refresh',
        hidden: true,
        component: {
          beforeRouteEnter(to, from, next) {
            next(instance => instance.$router.replace(from.fullPath));
          },
          render: h => h()
        }
      },
      // 页面重定向 必须保留
      {
        path: 'redirect/:route*',
        name: 'redirect',
        hidden: true,
        component: {
          beforeRouteEnter(to, from, next) {
            next(instance => instance.$router.replace(JSON.parse(from.params.route)));
          },
          render: h => h()
        }
      }
    ]
  }
];

/**
 * 在主框架之外显示
 */

const frameOut = [
  // 登录
  {
    path: '/login',
    name: 'login',
    meta: {
      title: '$t:page.login.title'
    },
    component: resolve => {
      require([], () => {
        resolve(pages['account/login.vue']);
      });
    }
  }
];

// 导出需要显示菜单的
export const frameInRoutes = frameIn;

// 重新组织后导出
export default [...frameOut, ...frameIn];
