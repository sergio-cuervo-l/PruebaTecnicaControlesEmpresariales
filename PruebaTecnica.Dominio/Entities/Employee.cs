namespace PruebaTecnica.Dominio.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int CurrentPosition { get; set; }
        public decimal Salary { get; set; }
        public int IdDepartment { get; set; } = 1;
        public int IdProject { get; set; } = 0;

        public decimal CalculateSalaryIncrease(Employee employee, int position)
        {
            if (employee != null)
            {
                if (position == 1)
                {
                    return employee.Salary * 0.1m; // Aumento del 10% para ascenso
                }
                else if (position == 2)
                {
                    return employee.Salary * 0.2m; // Aumento del 20% para permanencia
                }
            }
            return 0m; // Sin aumento
        }
    }
}
