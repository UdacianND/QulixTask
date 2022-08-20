using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace QulixTask.Payload.RequestDto
{
    public class UpdatePhotoDto
    {    
        [Required]
        public string Name { get; set; }
        [Required]
        public string Link { get; set; }
        [Required]
        [Range(1, 10000)]
        public double Cost { get; set; }
    }
}
