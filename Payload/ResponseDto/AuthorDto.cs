using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QulixTask.Entities;

namespace QulixTask.Payload.ResponseDto
{
    public class AuthorDto
    {
        //public AuthorDto(Author author)
        //{
        //    FirstName = author.FirstName;
        //    LastName = author.LastName;
        //    NickName = author.NickName;
        //}
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
    }
}
