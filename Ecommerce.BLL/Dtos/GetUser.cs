using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.BLL.Dtos
{
    public class GetUserDto
    {

        public int Id { get; set; }   

        public string Fullname { get; set; }

        public string Email { get; set; }
    }
}
