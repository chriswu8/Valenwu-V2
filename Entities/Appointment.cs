using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valenwu.Entities
{
    public class Appointment
    {
        /// <summary>
        /// An appointment entity with it's corresponding attributes.
        /// This class is used to construct an Appointment object to be used in the database.
        /// </summary>
        public int ID { get; set; }
        public string? Month { get; set; }
        public string? Day { get; set; }
        public string? Year { get; set; }
        public string? Time { get; set; }
        public string? Exam { get; set; }
        public string? Fee { get; set; }
        public int PatientID { get; set; }
        public int InvoiceID { get; set; }
        
    }
}
