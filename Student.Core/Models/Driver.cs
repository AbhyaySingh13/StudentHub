using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Core.Models
{
   public class Driver : BaseEntity
    {
        [DisplayName("Driver Name")]
        [StringLength(30)]
        [Required]
        public string DriverName { get; set; }

        [DisplayName("Email")]
        [StringLength(30)]
        [Required]
        public string Email { get; set; }

        [DisplayName("City")]
        [StringLength(30)]
        [Required]
        public string City { get; set; }

        [DisplayName("Street Name")]
        [StringLength(30)]
        [Required]
        public string Street { get; set; }
    }
}
