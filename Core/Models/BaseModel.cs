namespace Core.Models
{
    public class BaseModel
    {
        public Guid Id { get; set; }
        public bool Delete { get; set; }
        public DateTime Date { get; set; }
    }
}