import api from './api'
import { LoginDto } from '../types'

export const login = async (payload: LoginDto) => {
  const res = await api.post('/Auth/login', payload)
  return res.data
}

export const register = async (payload: any) => {
  const res = await api.post('/Auth/register', payload)
  return res.data
}
