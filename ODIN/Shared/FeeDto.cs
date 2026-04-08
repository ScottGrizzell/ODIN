using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class FeeDto
    {
        public int Id { get; set; }
        public int OffenderId { get; set; }
        public string FeeType { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; } = "Unpaid"; // This such be a struct or enum with  unpai, paid, collections but brevitiy
    }
}
