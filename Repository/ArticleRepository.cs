using Entities;
using IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public async Task<int> AddAsync(Article article)
        {
            article.DateModification = DateOnly.FromDateTime(DateTime.Now);
            article.DateCreation = DateOnly.FromDateTime(DateTime.Now);
            _context.Articles.Add(article);
            return await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int idToDelete)
        {
            bool ok;
            try
            {
                _context.Articles.Remove(_context.Articles.FirstOrDefault(a => a.Id == idToDelete));
                await _context.SaveChangesAsync();
                ok = true;
            }
            catch (Exception ex)
            {
                ok = false;
            }
            return ok;
        }

        public Article Detail(int id)
        {
            return _context.Articles.Include(c => c.Commentaires).FirstOrDefault(a => a.Id == id);
        }

        public async Task<bool> EditAsync(Article article)
        {
            bool ok;
            try
            {
                var ArticleToEdit = _context.Articles.FirstOrDefault(c => c.Id == article.Id);
                ArticleToEdit.Auteur = article.Auteur;
                ArticleToEdit.Contenu = article.Contenu;
                ArticleToEdit.DateModification = DateOnly.FromDateTime(DateTime.Now); ;
                _context.SaveChanges();
                ok = true;
            }
            catch (Exception ex)
            {
                ok = false;

            }
            return ok;
        }

        public List<Article> GetAllArticle()
        {
            var maliste = _context.Articles.Include(c => c.Commentaires).ToList();
            return maliste;
        }

        public async Task<bool> CheckUniqTheme(string theme)
        {
            bool ok;
            try
            {
                _context.Articles.Any(a => a.Theme == theme);
                await _context.SaveChangesAsync();
                ok = true;
            }
            catch (Exception ex)
            {
                ok = false;
            }
            return ok;
        }

    }
}
