import React, { useState } from 'react'
import EmployeeList from './components/EmployeeList'
import Login from './components/Login'

export default function App() {
  const [token, setToken] = useState<string | null>(() => localStorage.getItem('token'))

  const handleLogin = (jwt: string) => {
    localStorage.setItem('token', jwt)
    setToken(jwt)
  }

  const handleLogout = () => {
    localStorage.removeItem('token')
    setToken(null)
  }

  return (
    <div className="container py-4">
      <header className="d-flex flex-column flex-md-row align-items-md-center justify-content-between mb-4 gap-3">
        <div>
          <h1 className="h3 mb-1">Gestión de Empleados</h1>
          <p className="text-muted mb-0">Administra el equipo con creación, edición y eliminación.</p>
        </div>
        {token && (
          <button className="btn btn-outline-secondary" onClick={handleLogout}>
            Cerrar sesión
          </button>
        )}
      </header>
      <main>{!token ? <Login onLogin={handleLogin} /> : <EmployeeList />}</main>
    </div>
  )
}
