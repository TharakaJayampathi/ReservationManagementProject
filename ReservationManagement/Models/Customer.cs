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
        [StringLength(150)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(150)]
        public string LastName { get; set; }
       
        public string PhoneNo { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [StringLength(150)]
        public string Address { get; set; }

        [Required]
        public string PassportNo { get; set; }

        [Required]
        public DateTime RegisteredDate { get; set; }

        [Required]
        public string PostalCode { get; set; }

        [Required]
        public string City { get; set; }


        [Required]
        public string Country { get; set; }

        [Required]
        public string PaymentMethod { get; set; }

        [Required]
        public string CardNo { get; set; }

        [Required]
        public string ExpiryDate { get; set; }

        [Required]
        public string CardName { get; set; }

    }
}
