using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzoneApp.Data
{
    public class room
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        public string? email { get; set; }
        public int? roomcapacity { get; set; }
        public string? roomtype { get; set; }
        public string? floor { get; set; }
        public string? facilities { get; set; }

    }
}
