using ReservationManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ReservationManagement.ViewModel
{
    public class UserForm
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
    }

    public static class UserViewModel
    {

        public static Expression<Func<User, object>> SelectAllUser =>
            x => new
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                UserType = x.UserType,
                Email = x.Email,
                PhoneNo = x.PhoneNo,
                Address = x.Address,
                Age = x.Age,
                Description = x.Description
            };
        public static Expression<Func<User, object>> SelectById =>
            x => new
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                UserType = x.UserType,
                Email = x.Email,
                PhoneNo = x.PhoneNo,
                Address = x.Address,
                Age = x.Age,
                Description = x.Description
            };


    }
}
