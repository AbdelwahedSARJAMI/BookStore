using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApp.Models.Repositories
{
    public class DBAuthorRepository: IRepo<Author>
    {
        private readonly BookStoreDBContext db;

        public DBAuthorRepository(BookStoreDBContext db)
        {
            this.db = db;
        }

        public void Add(Author newauthor)
        {
            db.Authors.Add(newauthor);
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public void Delete(int Id)
        {
            var author = Find(Id);
            db.Authors.Remove(author);
        }

        public Author Find(int id)
        {
            var author = db.Authors.SingleOrDefault(a => a.Id == id);
            return author;
        }

        public List<Author> GetAll()
        {
            return db.Authors.ToList();
        }

        public void Update(Author t)
        {
            db.Authors.Update(t);
        }
    }
}
