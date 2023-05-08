using Bookstore.Data;

namespace Bookstore.Models
{
    public class CreateAuthorCommand : EditAuthorBase
    {
        public Author ToAuthor()
        {
            Author author = new Author();
            author.firstName = firstname;
            author.lastName = lastname;
            author.birthdate = birthdate;
            return author;
        }
    }
}
