using System;

namespace QulixTask.Entities
{
    public class Author : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public DateTimeOffset BirthDate { get; set; }
    }
}
