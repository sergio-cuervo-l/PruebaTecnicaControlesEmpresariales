import React, { useEffect, useState } from 'react'
import { Employee, CreateEmployeeDto } from '../types'
import { getEmployees, deleteEmployee, createEmployee, updateEmployee } from '../services/employeeService'
import EmployeeForm from './EmployeeForm'

export default function EmployeeList() {
  const [employees, setEmployees] = useState<Employee[]>([])
  const [loading, setLoading] = useState(false)
  const [error, setError] = useState<string | null>(null)
  const [success, setSuccess] = useState<string | null>(null)
  const [editing, setEditing] = useState<Employee | null>(null)
  const [showForm, setShowForm] = useState(false)

  const fetch = async () => {
    setLoading(true)
    setError(null)
    try {
      const data = await getEmployees()
      setEmployees(data)
    } catch (e: any) {
      setError(e.message || 'Error al cargar empleados')
    } finally {
      setLoading(false)
    }
  }

  useEffect(() => {
    fetch()
  }, [])

  const handleDelete = async (id: number) => {
    if (!confirm('Eliminar empleado?')) return
    setLoading(true)
    try {
      await deleteEmployee(id)
      setSuccess('Empleado eliminado')
      fetch()
    } catch (e: any) {
      setError(e.message || 'Error al eliminar')
    } finally {
      setLoading(false)
    }
  }

  const handleCreate = async (payload: CreateEmployeeDto) => {
    setLoading(true)
    try {
      await createEmployee(payload)
      setSuccess('Empleado creado')
      setShowForm(false)
      fetch()
    } catch (e: any) {
      setError(e.message || 'Error al crear')
    } finally {
      setLoading(false)
    }
  }

  const handleUpdate = async (id: number, payload: CreateEmployeeDto) => {
    setLoading(true)
    try {
      await updateEmployee(id, payload)
      setSuccess('Empleado actualizado')
      setEditing(null)
      setShowForm(false)
      fetch()
    } catch (e: any) {
      setError(e.message || 'Error al actualizar')
    } finally {
      setLoading(false)
    }
  }

  return (
    <div className="card shadow-sm">
      <div className="card-body">
        <div className="d-flex flex-column flex-md-row align-items-md-center justify-content-between mb-3 gap-2">
          <div>
            <h2 className="h5 mb-0">Empleados</h2>
            <p className="text-muted mb-0">Lista actualizada de empleados.</p>
          </div>
          <button className="btn btn-primary" onClick={() => { setShowForm(true); setEditing(null) }}>
            Crear empleado
          </button>
        </div>

        {loading && <div className="alert alert-info py-2">Cargando...</div>}
        {error && <div className="alert alert-danger py-2">{error}</div>}
        {success && <div className="alert alert-success py-2">{success}</div>}

        <div className="table-responsive">
          <table className="table table-hover align-middle mb-0">
            <thead className="table-light">
              <tr>
                <th>ID</th>
                <th>Nombre</th>
                <th>Posición</th>
                <th>Salario</th>
                <th className="text-end">Acciones</th>
              </tr>
            </thead>
            <tbody>
              {employees.map(emp => (
                <tr key={emp.id}>
                  <td>{emp.id}</td>
                  <td>{emp.name}</td>
                  <td>{emp.currentPosition ?? '-'}</td>
                  <td>{emp.salary ?? '-'}</td>
                  <td className="text-end">
                    <button className="btn btn-sm btn-outline-secondary me-2" onClick={() => { setEditing(emp); setShowForm(true) }}>
                      Editar
                    </button>
                    <button className="btn btn-sm btn-outline-danger" onClick={() => handleDelete(emp.id)}>
                      Eliminar
                    </button>
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      </div>

      {showForm && (
        <EmployeeForm
          initial={editing ?? undefined}
          onCancel={() => { setShowForm(false); setEditing(null) }}
          onCreate={handleCreate}
          onUpdate={handleUpdate}
        />
      )}
    </div>
  )
}
