using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices
{
    public interface IArticleService
    {
        List<Article> GetAllArticle();
        Article Detail(int id);

        Task<bool> EditAsync(Article article);

        Task<bool> DeleteAsync(int idToDelete);

        Task<int> AddAsync(Article article);

        Task<bool> CheckUniqTheme(string theme);
    }
}
