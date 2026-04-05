namespace Shared
{
    public class OffenderDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public DateOnly DOB { get; set; }
        public decimal FeesOwed { get; set; }
        public string Status { get; set; } = "Active";
    }
}
