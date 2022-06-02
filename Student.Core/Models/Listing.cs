using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Core.Models
{
   public class Listing: BaseEntity
    {

        [DisplayName("Area")]
        [StringLength(50)]
        [Required]
        public string Area { get; set; }

        
        [StringLength(50)]
        [Required]
        public string Address { get; set; }

       
        [Required]
        public decimal Price { get; set; }
        public string Image { get; set; }

        
        [StringLength(300)]
        [Required]
        public string Description { get; set; }

        [DisplayName("Bedrooms")]
        [Required]
        public int NumBedrooms { get; set; }

        [DisplayName("Bathrooms")]
        [Required]
        public int NumBathrooms { get; set; }

        [DisplayName("Garages")]
        [Required]
        public int NumGarages { get; set; }

        [DisplayName("University")]
        [StringLength(30)]
        [Required]
        public string University { get; set; }

        [Required]
        public bool  Alarm { get; set; }
 
        [Required]
        public bool Fencing { get; set; }


        [Required]
        public bool Wifi { get; set; }

    }
}
