import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'

const apiBaseUrl = process.env.VITE_API_BASE_URL ?? 'http://localhost:5127'

export default defineConfig({
  plugins: [react()],
  server: {
    proxy: {
      '/events': {
        target: apiBaseUrl,
        changeOrigin: true,
        secure: false,
      },
    },
  },
})
