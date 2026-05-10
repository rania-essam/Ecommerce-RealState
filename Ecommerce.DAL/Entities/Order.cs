using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.DAL.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal TotalAmount { get; set; }

        public string Status { get; set; }

        public User user { get; set; }
        public int UserId { get; set; }
    }
}
