namespace PruebaTecnica.Application.DTOs
{
    public class EmployeeResponseDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int CurrentPosition { get; set; }

        public decimal Salary { get; set; }
    }
}
