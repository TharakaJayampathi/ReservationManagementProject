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
    }

    public static class CustomerViewModel
    {

        public static Expression<Func<Customer, object>> SelectAllCustomer =>
            x => new
            {
                Id = x.Id,
                Email = x.Email,
                FirstName = x.FirstName,
                LastName = x.LastName,
                PhoneNo = x.PhoneNo,
                Address = x.Address,
                Age = x.Age,
                UsermanagementId = x.UsermanagementId
            };
        public static Expression<Func<Customer, object>> SelectById =>
            x => new
            {
                Id = x.Id,
                Email = x.Email,
                FirstName = x.FirstName,
                LastName = x.LastName,
                PhoneNo = x.PhoneNo,
                Address = x.Address,
                Age = x.Age,
                UsermanagementId = x.UsermanagementId
            };


    }
}
