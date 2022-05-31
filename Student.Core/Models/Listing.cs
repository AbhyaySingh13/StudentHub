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

       
        [StringLength(30)]
        [Required]
        public string Price { get; set; }
        public string Image { get; set; }

        
        [StringLength(300)]
        [Required]
        public string Description { get; set; }

        [DisplayName("Number of Bedrooms")]
        [Required]
        public int NumBedrooms { get; set; }

        [DisplayName("Number of Bathrooms")]
        [Required]
        public int NumBathrooms { get; set; }

        [DisplayName("Number of Garages")]
        [Required]
        public int NumGarages { get; set; }

        [DisplayName("University Name")]
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
