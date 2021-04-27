using ReservationManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ReservationManagement.ViewModel
{
    public class PaymentForm
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

    public static class PaymentViewModel
    {

        public static Expression<Func<Payment, object>> SelectAllPayment =>
            x => new
            {
                Id = x.Id,
                PaymentMethod = x.PaymentMethod,
                CardNo = x.CardNo,
                ExpiryDate = x.ExpiryDate,
                CardName = x.CardName

            };
        public static Expression<Func<Payment, object>> SelectById =>
            x => new
            {
                Id = x.Id,
                PaymentMethod = x.PaymentMethod,
                CardNo = x.CardNo,
                ExpiryDate = x.ExpiryDate,
                CardName = x.CardName

            };


    }
}
