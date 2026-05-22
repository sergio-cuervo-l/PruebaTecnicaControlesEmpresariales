namespace PruebaTecnica.Application.DTOs
{
    public class CreateEmployeeDto
    {
        public string Name { get; set; } = string.Empty;

        public int CurrentPosition { get; set; }

        public decimal Salary { get; set; }
    }
}
