using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationManagement.Models
{
    public class Payment
    {
        public int Id { get; set; }

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
