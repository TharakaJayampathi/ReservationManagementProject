using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationManagement.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [StringLength(150)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(150)]
        public string LastName { get; set; }
       
        public string PhoneNo { get; set; }

        [Required]
        [StringLength(150)]
        public string Address { get; set; }
        public int Age { get; set; }

        public int UsermanagementId { get; set; }
        public Usermanagement Usermanagement { get; set; }


    }
}
