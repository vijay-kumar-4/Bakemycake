using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Auth_Forms.Models
{
    public class User
    {
        [Key]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Name { get; set; }

        [DataType(DataType.Text)]
        public string PersonalAddress { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }


        [DataType(DataType.Text)]
        public string WorkAddress { get; set; }
        public long PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}