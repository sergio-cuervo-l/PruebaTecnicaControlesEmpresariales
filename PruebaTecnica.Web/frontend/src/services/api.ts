import axios from 'axios'

const apiBase = (import.meta.env as any).VITE_API_URL || '/api'

const api = axios.create({
  baseURL: apiBase
})

api.interceptors.request.use(config => {
  const token = localStorage.getItem('token')
  if (token && config.headers) {
    config.headers.Authorization = `Bearer ${token}`
  }
  return config
})

export default api
