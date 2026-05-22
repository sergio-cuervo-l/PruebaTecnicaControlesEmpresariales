using PruebaTecnica.Application.DTOs;

namespace PruebaTecnica.Application.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeResponseDto>> GetAllAsync();

        Task<EmployeeResponseDto?> GetByIdAsync(int id);

        Task<EmployeeResponseDto> CreateAsync(CreateEmployeeDto employeeDto);

        Task<bool> UpdateAsync(int id, CreateEmployeeDto employeeDto);

        Task<bool> DeleteAsync(int id);
    }
}
