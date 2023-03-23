using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valenwu.Entities
{
    internal class Invoice
    {
        public int ID { get; set; }
        public int patientID { get; set; }
        public int serviceID { get; set; }
        public int fee { get; set; }
        public float totalPaid { get; set; }
    }
}
