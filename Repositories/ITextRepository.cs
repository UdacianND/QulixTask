using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QulixTask.Entities;

namespace QulixTask.Repositories
{
    public interface ITextRepository
    {
        Text GetText(Guid id);
        ICollection<Text> GetTexts(int pageNumber, int pageSize);
        Text Save(Text text);
    }
}
