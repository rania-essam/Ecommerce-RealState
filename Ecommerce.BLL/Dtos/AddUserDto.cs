using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ecommerce.BLL.Dtos
{
    public class AddUserDto
    {

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        [Required]
        [MinLength(6)]

        public string password { get; set; }


        [Required]
        [EmailAddress]
        public string email { get; set; }
    }
}
