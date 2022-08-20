using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QulixTask.Payload.RequestDto
{
    public class CreatePhotoDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Link { get; set; }
        [Required]
        public Guid AuthorId { get; set; }
        [Required]
        [Range(1,100000000)]
        public double OriginalSize { get; set; }
        [Required]
        [Range(1, 10000)]
        public double Cost { get; set; }
    }
}
