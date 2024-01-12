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
            try
            {
                var ArticleToEdit = _context.Articles.FirstOrDefault(c => c.Id == article.Id);
                ArticleToEdit.Auteur = article.Auteur;
                ArticleToEdit.Contenu = article.Contenu;
                ArticleToEdit.DateModification = article.DateModification;
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
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
                ok = _context.Articles.Any(a => a.Theme == theme);
            }
            catch (Exception ex)
            {
                ok = false;
            }
            return ok;
        }

        public async Task<List<Article>> SearchAjax(string auteur)
        {
            return await _context.Articles
                    .Where(a => a.Auteur.Contains(auteur) || a.Theme.Contains(auteur) || a.Contenu.Contains(auteur) || a.Commentaires.Any(c => c.Auteur.Contains(auteur) || c.Contenu.Contains(auteur)))
                    .Include(a => a.Commentaires)
                    .ToListAsync();
        }

        public async Task<Article> GetLastArticleAsync()
        {
            return await _context.Articles.OrderByDescending(a => a.DateModification).FirstOrDefaultAsync();
        }
    }
}
