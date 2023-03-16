using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valenwu.Entities
{
    public class Patient
    {
        public int ID { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? Address { get; set; }
        public string? Province { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
        public string? BirthDate { get; set; }
        public string? PHN { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Occupation { get; set; }
        public string? Insurance { get; set; }
        public string? Misc { get; set; }
        public string? LastVisit { get; set; }
        public string? FirstVisit { get; set; }
    }
}
