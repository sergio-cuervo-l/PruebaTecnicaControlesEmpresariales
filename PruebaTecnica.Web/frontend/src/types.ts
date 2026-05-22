export interface Employee {
  id: number
  name: string
  currentPosition?: number
  salary?: number
}

export interface CreateEmployeeDto {
  name: string | null
  currentPosition?: number
  salary?: number
}

export interface LoginDto {
  username: string
  password: string
}
