using Entities;
using IRepository;
using IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ArticleService : IArticleService
    {
        private IArticleRepository _articleRepository;

        public ArticleService(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }
        public Task<int> AddAsync(Article article)
        {
            article.DateCreation = DateOnly.FromDateTime(DateTime.Now);
            article.DateModification = DateOnly.FromDateTime(DateTime.Now);
            return _articleRepository.AddAsync(article);
        }

        public Task<bool> CheckUniqTheme(string theme)
        {
            return _articleRepository.CheckUniqTheme(theme);
        }

        public Task<bool> DeleteAsync(int idToDelete)
        {
            return _articleRepository.DeleteAsync(idToDelete);
        }

        public Article Detail(int id)
        {
            return _articleRepository.Detail(id);
        }

        public Task<bool> EditAsync(Article article)
        {
            article.DateModification = DateOnly.FromDateTime(DateTime.Now);
            return _articleRepository.EditAsync(article);
        }

        public List<Article> GetAllArticle()
        {
            return _articleRepository.GetAllArticle();
        }
    }
}
