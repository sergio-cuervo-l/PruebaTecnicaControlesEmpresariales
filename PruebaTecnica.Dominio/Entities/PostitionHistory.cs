namespace PruebaTecnica.Dominio.Entities
{
    public class PostitionHistory
    {
        public int EmployeeId { get; set; }
        public string Position { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
