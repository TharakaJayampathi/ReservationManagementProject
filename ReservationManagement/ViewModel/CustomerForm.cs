using ReservationManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ReservationManagement.ViewModel
{
    public class CustomerForm
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

    public static class CustomerViewModel
    {

        public static Expression<Func<Customer, object>> SelectAllCustomer =>
            x => new
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                PhoneNo = x.PhoneNo,
                Email = x.Email,
                Address = x.Address,
                PassportNo = x.PassportNo,
                RegisteredDate = x.RegisteredDate,
                PostalCode = x.PostalCode,
                City = x.City,
                Country = x.Country,
                PaymentMethod = x.PaymentMethod,
                CardNo = x.CardNo,
                ExpiryDate = x.ExpiryDate,
                CardName = x.CardName




            };
        public static Expression<Func<Customer, object>> SelectById =>
            x => new
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                PhoneNo = x.PhoneNo,
                Email = x.Email,
                Address = x.Address,
                PassportNo = x.PassportNo,
                RegisteredDate = x.RegisteredDate,
                PostalCode = x.PostalCode,
                City = x.City,
                Country = x.Country,
                PaymentMethod = x.PaymentMethod,
                CardNo = x.CardNo,
                ExpiryDate = x.ExpiryDate,
                CardName = x.CardName

            };


    }
}
