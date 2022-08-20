using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QulixTask.Payload.RequestDto
{
    public class CreateTextDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public Guid AuthorId { get; set; }
        [Required]
        [Range(0,10000)]
        public double Cost { get; set; }
    }
}
