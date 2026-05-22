import api from './api'
import { Employee, CreateEmployeeDto } from '../types'

export const getEmployees = async (): Promise<Employee[]> => {
  const res = await api.get('/Employee')
  return res.data
}

export const getEmployee = async (id: number): Promise<Employee> => {
  const res = await api.get(`/Employee/${id}`)
  return res.data
}

export const createEmployee = async (payload: CreateEmployeeDto) => {
  const res = await api.post('/Employee', payload)
  return res.data
}

export const updateEmployee = async (id: number, payload: CreateEmployeeDto) => {
  const res = await api.put(`/Employee/${id}`, payload)
  return res.data
}

export const deleteEmployee = async (id: number) => {
  const res = await api.delete(`/Employee/${id}`)
  return res.data
}
