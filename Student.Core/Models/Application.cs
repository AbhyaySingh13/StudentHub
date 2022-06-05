using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Core.Models
{
    public class Application : BaseEntity
    {
        public string JobId { get; set; }

        [DisplayName("Student Name")]
        public string StudentName { get; set; }
        public string University { get; set; }
        public string Qualification { get; set; }
        public string Email { get; set; }
        public string Cell { get; set; }
        public string CV { get; set; }
        public string Image { get; set; }

    }
}
