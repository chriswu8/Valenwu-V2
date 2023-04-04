using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Valenwu.Entities
{
    public class Service
    {
        /// <summary>
        /// A service entity with it's corresponding attributes.
        /// This class is used to construct a Service object to be used in the database.
        /// </summary>
        
        public int Id
        {
            get; set;
        }
        public string? Code
        {
            get; set;
        }
        public int Fee
        {
            get; set;
        }
        public string? Description
        {
            get; set;
        }
    }
}
    