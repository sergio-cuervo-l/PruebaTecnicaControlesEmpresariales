import React, { useState } from 'react'
import { login } from '../services/authService'
import { LoginDto } from '../types'

type Props = {
  onLogin: (token: string) => void
}

export default function Login({ onLogin }: Props) {
  const [username, setUsername] = useState('')
  const [password, setPassword] = useState('')
  const [loading, setLoading] = useState(false)
  const [error, setError] = useState<string | null>(null)

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault()
    setError(null)
    setLoading(true)
    try {
      const payload: LoginDto = { username, password }
      const res = await login(payload)
      const token = res.token ?? res
      onLogin(token)
    } catch (e: any) {
      setError(e.message || 'Error al autenticar')
    } finally {
      setLoading(false)
    }
  }

  return (
    <div className="row justify-content-center">
      <div className="col-12 col-sm-10 col-md-8 col-lg-5">
        <div className="card shadow-sm">
          <form className="card-body p-4" onSubmit={handleSubmit}>
            <h3 className="card-title mb-3">Iniciar sesión</h3>
            {loading && <div className="alert alert-info py-2">Cargando...</div>}
            {error && <div className="alert alert-danger py-2">{error}</div>}
            <div className="mb-3">
              <label className="form-label">Usuario</label>
              <input className="form-control" value={username} onChange={e => setUsername(e.target.value)} />
            </div>
            <div className="mb-3">
              <label className="form-label">Contraseña</label>
              <input className="form-control" type="password" value={password} onChange={e => setPassword(e.target.value)} />
            </div>
            <div className="d-grid">
              <button type="submit" className="btn btn-primary">Entrar</button>
            </div>
          </form>
        </div>
      </div>
    </div>
  )
}
