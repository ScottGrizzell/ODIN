
using System.ComponentModel.DataAnnotations;

namespace Server.Data.Entities
{
    public class Offender
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required, MaxLength(50)]
        public string LastName { get; set; } = string.Empty;
        public DateOnly DOB { get; set; }

        public decimal FeesOwed { get; set; }

        public string Status { get; set; } = "Active";

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;



    }
}
