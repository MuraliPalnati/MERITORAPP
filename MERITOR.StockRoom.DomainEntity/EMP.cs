using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MERITOR.StockRoom.DomainEntity
{


    [Table("EMPLOYEE")]
    public class EMP
    {
        public decimal ID { get; set; }
        public string NAME { get; set; }
        public string PASSWORD { get; set; }
        //public IDictionary<string, string> ErrorMessage { get; set; }
        public string teja { get; set; }
    }
}
