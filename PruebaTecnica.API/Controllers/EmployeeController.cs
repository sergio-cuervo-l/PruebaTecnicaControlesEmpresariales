using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Application.DTOs;
using PruebaTecnica.Application.Interfaces;

namespace PruebaTecnica.API.Controllers
{
    /// <summary>
    /// Defines HTTP endpoints for managing employee resources, including retrieving, creating, updating, and deleting
    /// employees.
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        /// <summary>
        /// Initializes a new instance of the EmployeeController class with the specified employee service.
        /// </summary>
        /// <param name="employeeService"></param>
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        /// <summary>
        /// Retorna una lista de todos los empleados.
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin, User")]
        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await _employeeService.GetAllAsync();

            return Ok(employees);
        }

        /// <summary>
        /// Retorna los detalles de un empleado específico por ID.
        /// </summary>
        /// <param name="id">Id del Empleado</param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var employee = await _employeeService.GetByIdAsync(id);

            if (employee == null)
            {
                return NotFound(new
                {
                    Message = $"Employee with ID {id} was not found"
                });
            }

            return Ok(employee);
        }

        /// <summary>
        /// Agrega un nuevo empleado
        /// </summary>
        /// <param name="employeeDto"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateEmployee(
                CreateEmployeeDto employeeDto)
        {
            var employee = await _employeeService
                .CreateAsync(employeeDto);

            return CreatedAtAction(
                nameof(GetEmployeeById),
                new { id = employee.Id },
                employee);
        }

        /// <summary>
        /// Actualiza un empleado existente
        /// </summary>
        /// <param name="id"></param>
        /// <param name="employeeDto"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(
            int id,
            CreateEmployeeDto employeeDto)
        {
            var updated = await _employeeService
                .UpdateAsync(id, employeeDto);

            if (!updated)
            {
                return NotFound();
            }

            return NoContent();
        }

        /// <summary>
        /// Elimina un empleado.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var deleted = await _employeeService.DeleteAsync(id);

            if (!deleted)
            {
                return NotFound(new
                {
                    Message = $"Employee with ID {id} was not found"
                });
            }

            return NoContent();
        }

    }
}
