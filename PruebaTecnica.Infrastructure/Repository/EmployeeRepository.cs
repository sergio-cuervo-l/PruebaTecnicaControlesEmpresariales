using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Dominio.Entities;
using PruebaTecnica.Infrastructure.Data;
using PruebaTecnica.Infrastructure.Interfaces;

namespace PruebaTecnica.Infrastructure.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _context.Employee.ToListAsync();
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
            return await _context.Employee
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Employee> CreateAsync(Employee employee)
        {
            _context.Employee.Add(employee);

            await _context.SaveChangesAsync();

            return employee;
        }

        public async Task UpdateAsync(Employee employee)
        {
            _context.Employee.Update(employee);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Employee employee)
        {
            _context.Employee.Remove(employee);

            await _context.SaveChangesAsync();
        }

        public async Task<List<Employee>> EmployeeWithoutProject(int departmentId)
        {
            var employees = await _context.Employee
                                    .Where(e => e.IdDepartment == departmentId
                                                && e.IdProject > 0)
                                    .ToListAsync();

            return employees;
        }
    }
}
