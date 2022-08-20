using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QulixTask.Entities;
using QulixTask.Payload.RequestDto;
using QulixTask.Payload.ResponseDto;

namespace QulixTask.Services
{
    public interface ITextService
    {
        ICollection<TextDto> GetTexts(int pageNumber, int pageSize);
        TextDto GetText(Guid id);
        Text CreateText(CreateTextDto textDto);
        public TextDto ConvertToDto(Text text);
    }
}
