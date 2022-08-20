using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QulixTask.Entities
{
    public class Photo : BaseModel
    {
        public string Name { get; set; }
        public string Link { get; set; }
        public Guid AuthorId { get; set; }
        public double OriginalSize { get; set; } 
        public double Cost { get; set; }
        public int NumberOfSales { get; set; } = 0;
    }
}
