using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QulixTask.Payload.RequestDto;

namespace QulixTask.Entities
{
    public class Text : BaseModel
    {
        public Text(CreateTextDto textDto)
        {
            Name = textDto.Name;
            Content = textDto.Content;
            AuthorId = textDto.AuthorId;
            Cost = textDto.Cost;
        }

        public string Name { get; set; }
        public string Content { get; set; }
        public Guid AuthorId { get; set; }
        public double Cost { get; set; }
        public int NumberOfSales { get; set; } = 0;
    }
}
