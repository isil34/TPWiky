using Entities;
using IRepository;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ArticleRepository : IArticleRepository
    {
        private TPWikyContext _context;
        public ArticleRepository(TPWikyContext context)
        {
            _context = context;
        }
        public void Add(Article article)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int idToDelete)
        {
            throw new NotImplementedException();
        }

        public Article Detail(int id)
        {
            throw new NotImplementedException();
        }

        public bool Edit(Article article)
        {
            throw new NotImplementedException();
        }

        public List<Article> GetAllMessage()
        {
            throw new NotImplementedException();
        }
    }
}
