using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class CaseDto
    {
        public int Id { get; set; } // primary key
        public int OffenderId { get; set; } // foreign key
        public string CaseNumber { get; set; } = string.Empty;
        public string CaseDescription { get; set; } = string.Empty;
        public string Status { get; set; } = "Open";
        public DateTime FiledDate { get; set; }
    }
}
