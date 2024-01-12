using Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository
{
    public interface IArticleRepository
    {
        List<Article> GetAllArticle();

        Task<Article> GetLastArticleAsync();

        Article Detail(int id);

        Task<bool> EditAsync(Article article);

        Task<bool> DeleteAsync(int idToDelete);

        Task<int> AddAsync(Article article);

        Task<bool> CheckUniqTheme(string theme);

        Task<List<Article>> SearchAjax(string auteur);
    }
}
