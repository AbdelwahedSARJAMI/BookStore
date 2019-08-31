using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApp.Models.Repositories
{
    public class AuthorRepository : IRepo<Author>
    {
        List<Author> Authors;
        public AuthorRepository()
        {
            Authors = new List<Author>()
            {
                new Author{ Id = 1, Name = "Abdelwahed"},
                new Author{ Id = 2, Name = "Hamza"},
                new Author{ Id = 3, Name = "Kamal"},
                new Author{ Id = 4, Name = "Hicham"}
            };
        }

        public void Add(Author newauthor)
        {
            Authors.Add(newauthor);
        }

        public int Commit()
        {
            return 1;
        }

        public void Delete(int Id)
        {
            var author = Find(Id);
            Authors.Remove(author);
        }

        public Author Find(int id)
        {
            var author = Authors.SingleOrDefault(a => a.Id == id);
            return author;
        }

        public List<Author> GetAll()
        {
            return Authors;
        }

        public void Update(Author t)
        {
            var OldAuthor = Find(t.Id);
            OldAuthor.Name = t.Name;
        }
    }
}
