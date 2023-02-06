import Vue from 'vue';
import Router from 'vue-router';
Vue.use(Router);
/* Layout */
//import Layout from '@/components'
/* Router Modules */
//import componentsRouter from './modules/components'
export const constantRoutes = [
    {
        path: '/signin',
        component: () => import('@/views/login/Signin'),
        hidden: true
    },
    {
        path: '/join',
        component: () => import('@/views/Join'),
        hidden: true
    },
    {
        path: '/profission',
        component: () => import('@/views/profission'),
        hidden: true
    },
    {
        path:'/set/profile',
        component:()=>import('@/views/profiles/home'),
        hidden:true
    },
    {
        path: '/service',
        name: 'service',
        component: () => import('@/views/serviceDetail'),
        hidden: true
    },
    {
        path: '/404',
        component: () => import('@/views/error-page/404'),
        hidden: true
    },
    {
        path: '/401',
        component: () => import('@/views/error-page/401'),
        hidden: true
    },
    {
        path: '/',
        component: () => import('@/views/dashboard/Home'),
        name: 'home',
        meta: { title: 'home', icon: 'home', affix: true }
    },
    {
        path: '/serviceList/:item',
        component: () => import('@/views/dashboard/serviceList'),
        name: 'serviceList',
        meta: { title: 'serviceList', icon: 'home', affix: true }
    },
    {
        path: '/test',
        component: () => import('@/views/dashboard/test'),
        name: 'test',
        meta: { title: 'test', icon: 'home', affix: true }
    },
    {
        path: '/admin/serviceType',
        component: () => import('@/admin/pages/ServiceType'),
        name: 'serviceType',
        hidden: true
    },
    {
        path: '/admin/userList',
        component: () => import('@/admin/pages/UserList'),
        name: 'userList',
        hidden: true
    }
    // 404 page must be placed at the end !!!
    //{ path: '*', redirect: '/404', hidden: true }
];
/** when your routing map is too long, you can split it into small modules **/
//componentsRouter
const createRouter = () =>
    new Router({
        mode: 'history', // require service support
        scrollBehavior: () => ({ y: 0 }),
        routes: constantRoutes
    });
const router = createRouter();
// export function resetRouter() {
//   const newRouter = createRouter()
//   router.matcher = newRouter.matcher // reset router
// }
// router.beforeEach((to, from, next) => {
//     if (to.matched.some(record => record.meta.authRequired)) {
//         if (!store.state.isAuthenticated) {
//             next({
//                 path: '/sign-in'
//             });
//         } else {
//             next();
//         }
//     } else {
//         next();
//     }
// });
export default router;
