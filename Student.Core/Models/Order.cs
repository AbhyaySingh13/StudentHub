using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Core.Models
{
   public class Order : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string OrderStatus { get; set; }
        public string DeliverMethod { get; set; }
        public decimal BasketTotal { get; set; }
        public decimal FinalTotal { get; set; }
        public string Driver { get; set; }
    }
}
