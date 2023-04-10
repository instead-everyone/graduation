/**
 * iView Admin Pro 开发配置
 * */
import { loadEnv } from 'vite';

let env = loadEnv(process.env.NODE_ENV, process.cwd());

const basePath = env.VITE_APP_BASE_PATH;
const path = basePath == '' || basePath == null ? '/' : '/' + basePath + '/';

const Setting = {
  // 是否使用 Mock 的数据，默认 开发环境为 true，生产环境为 false
  // isMock: false,
  // 部署应用包时的基本 URL
  publicPath: path,
  // 生产环境构建文件的目录名
  outputDir: 'dist',
  // 放置生成的静态资源 (js、css、img、fonts) 的 (相对于 outputDir 的) 目录。
  assetsDir: 'assets',
  // 开发环境每次保存时 lint 代码，会将 lint 错误输出为编译警告
  // true || false || error
  lintOnSave: false
};

export default Setting;
