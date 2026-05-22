import React, { useState } from 'react'
import { CreateEmployeeDto, Employee } from '../types'

type Props = {
  initial?: Employee
  onCreate: (payload: CreateEmployeeDto) => void
  onUpdate: (id: number, payload: CreateEmployeeDto) => void
  onCancel: () => void
}

export default function EmployeeForm({ initial, onCreate, onUpdate, onCancel }: Props) {
  const [name, setName] = useState(initial?.name ?? '')
  const [currentPosition, setCurrentPosition] = useState<number | undefined>(initial?.currentPosition)
  const [salary, setSalary] = useState<number | undefined>(initial?.salary)
  const [error, setError] = useState<string | null>(null)

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault()
    setError(null)
    if (!name || name.trim() === '') {
      setError('El nombre es requerido')
      return
    }

    const payload: CreateEmployeeDto = {
      name,
      currentPosition,
      salary
    }

    if (initial && initial.id) {
      onUpdate(initial.id, payload)
    } else {
      onCreate(payload)
    }
  }

  return (
    <div className="modal show d-block bg-dark bg-opacity-25">
      <div className="modal-dialog modal-dialog-centered">
        <div className="modal-content shadow-lg">
          <div className="modal-header">
            <h5 className="modal-title">{initial ? 'Editar empleado' : 'Crear empleado'}</h5>
            <button type="button" className="btn-close" onClick={onCancel} aria-label="Cerrar" />
          </div>
          <form className="modal-body" onSubmit={handleSubmit}>
            {error && <div className="alert alert-danger">{error}</div>}
            <div className="mb-3">
              <label className="form-label">Nombre</label>
              <input className="form-control" value={name} onChange={e => setName(e.target.value)} />
            </div>
            <div className="mb-3">
              <label className="form-label">Posición (id)</label>
              <input className="form-control" type="number" value={currentPosition ?? ''} onChange={e => setCurrentPosition(e.target.value ? Number(e.target.value) : undefined)} />
            </div>
            <div className="mb-3">
              <label className="form-label">Salario</label>
              <input className="form-control" type="number" step="0.01" value={salary ?? ''} onChange={e => setSalary(e.target.value ? Number(e.target.value) : undefined)} />
            </div>
            <div className="d-flex justify-content-end gap-2">
              <button type="button" className="btn btn-secondary" onClick={onCancel}>Cancelar</button>
              <button type="submit" className="btn btn-primary">Guardar</button>
            </div>
          </form>
        </div>
      </div>
    </div>
  )
}
