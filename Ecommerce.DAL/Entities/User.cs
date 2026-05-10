using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ecommerce.DAL.Entities
{


    public class User
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // ← add this

        public int Id { get; set; }

        public string FirstName{ get; set; }
        public string LastName{ get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public DateTime CreatedAt { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
