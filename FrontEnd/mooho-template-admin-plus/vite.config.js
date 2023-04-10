import { defineConfig } from 'vite';
import vue from '@vitejs/plugin-vue';
import { resolve } from 'path';
import Setting from './src/setting.env';

export default defineConfig({
  plugins: [vue()],
  base: Setting.publicPath,
  build: {
    sourcemap: false, // 输出.map文件
    outDir: Setting.outputDir,
    assetsDir: Setting.assetsDir
    // minify: 'terser'
  },
  resolve: {
    alias: {
      '@': resolve(__dirname, '.', 'src')
    }
    // extensions: ['.js', '.json', '.vue']
  }
});
