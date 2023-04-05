using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valenwu.Entities
{
    public class Invoice
    {
        /// <summary>
        /// An invoice entity with it's corresponding attributes.
        /// This class is used to construct an Invoice object to be used in the database.
        /// </summary>
        public int ID { get; set; }
        public int patientID { get; set; }
        public int serviceID { get; set; }
        public int fee { get; set; }
        public float totalPaid { get; set; }
    }
}
