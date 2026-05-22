using PruebaTecnica.Application.DTOs;
using PruebaTecnica.Application.Interfaces;
using PruebaTecnica.Dominio.Entities;
using PruebaTecnica.Infrastructure.Interfaces;

namespace PruebaTecnica.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<EmployeeResponseDto>> GetAllAsync()
        {
            var employees = await _repository.GetAllAsync();

            return employees.Select(e => new EmployeeResponseDto
            {
                Id = e.Id,
                Name = e.Name,
                CurrentPosition = e.CurrentPosition,
                Salary = e.Salary
            });
        }

        public async Task<EmployeeResponseDto?> GetByIdAsync(int id)
        {
            var employee = await _repository.GetByIdAsync(id);

            if (employee == null)
            {
                return null;
            }

            return new EmployeeResponseDto
            {
                Id = employee.Id,
                Name = employee.Name,
                CurrentPosition = employee.CurrentPosition,
                Salary = employee.Salary
            };
        }

        public async Task<EmployeeResponseDto> CreateAsync(CreateEmployeeDto dto)
        {
            var employee = new Employee
            {
                Name = dto.Name,
                CurrentPosition = dto.CurrentPosition,
                Salary = dto.Salary,

                // Valores automáticos
                IdDepartment = 1,
                IdProject = 1
            };

            var created = await _repository.CreateAsync(employee);

            return new EmployeeResponseDto
            {
                Id = created.Id,
                Name = created.Name,
                CurrentPosition = created.CurrentPosition,
                Salary = created.Salary
            };
        }

        public async Task<bool> UpdateAsync(int id, CreateEmployeeDto dto)
        {
            var employee = await _repository.GetByIdAsync(id);

            if (employee == null)
            {
                return false;
            }

            employee.Name = dto.Name;
            employee.CurrentPosition = dto.CurrentPosition;
            employee.Salary = dto.Salary;

            await _repository.UpdateAsync(employee);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var employee = await _repository.GetByIdAsync(id);

            if (employee == null)
            {
                return false;
            }

            await _repository.DeleteAsync(employee);

            return true;
        }
    }
}
