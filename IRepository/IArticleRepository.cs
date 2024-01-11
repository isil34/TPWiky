using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository
{
    public interface IArticleRepository
    {
        List<Article> GetAllMessage();
        Article Detail(int id);

        bool Edit(Article article);

        bool Delete(int idToDelete);

        void Add(Article article);
    }
}
