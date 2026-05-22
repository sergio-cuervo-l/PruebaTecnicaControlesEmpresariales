using PruebaTecnica.Dominio.Entities;

namespace PruebaTecnica.Infrastructure.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllAsync();

        Task<Employee?> GetByIdAsync(int id);

        Task<Employee> CreateAsync(Employee employee);

        Task UpdateAsync(Employee employee);

        Task DeleteAsync(Employee employee);
        Task<List<Employee>> EmployeeWithoutProject(int departmentId);
    }
}
