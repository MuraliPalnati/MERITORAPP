using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MERITOR.StockRoom.DomainEntity
{
    public class Login
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter Name")]
        [Display(Name = "Name")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please Enter Password")]
        public string Password { get; set; }
        public string Roles { get; set; }

        public string ErrorMessage { get; set; }

    }
}
