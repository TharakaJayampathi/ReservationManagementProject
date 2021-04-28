using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationManagement.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(150)]
        public string LastName { get; set; }

        [Required]
        public string UserType { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PhoneNo { get; set; }

        [Required]
        [StringLength(150)]
        public string Address { get; set; }

        [Required]
        public int Age { get; set; }

        public string Description { get; set; }

        //public Usermanagement Usermanagement{ get; set; }


    }
}
