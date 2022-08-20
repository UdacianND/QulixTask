using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QulixTask.Payload.RequestDto;
using QulixTask.Payload.ResponseDto;
using QulixTask.Entities;
using QulixTask.Exceptions;
using QulixTask.Services;
using QulixTask.Repositories;

namespace QulixTask.ServiceImp
{
    public class TextService : ITextService
    {
        private readonly ITextRepository textRepository;
        private readonly IAuthorRepository authorRepository;
        private readonly IRatingService ratingService;
        public TextService(
            ITextRepository textRepository,
            IAuthorRepository authorRepository,
            IRatingService ratingService)
        {
            this.textRepository = textRepository;
            this.authorRepository = authorRepository;
            this.ratingService = ratingService;         
        }
        public Text CreateText(CreateTextDto textDto)
        {
            bool hasAuthor = authorRepository.CheckAuthorExists(textDto.AuthorId);
            if (!hasAuthor)
                throw new AuthorNotFoundException();
            return textRepository.Save(new Text(textDto));
        }

        public TextDto GetText(Guid id)
        {
            return ConvertToDto(textRepository.GetText(id));
        }

        public ICollection<TextDto> GetTexts(int pageNumber, int pageSize)
        {
            return textRepository.GetTexts( pageNumber,  pageSize)
                .Select(text => ConvertToDto(text)).ToList();
        }

        public TextDto ConvertToDto(Text text)
        {
            double ratingValue = ratingService.GetRatingValue(text.Id);
            Author author = authorRepository.GetAuthor(text.AuthorId);
            return new TextDto(text, author, ratingValue);
        }


    }
}
