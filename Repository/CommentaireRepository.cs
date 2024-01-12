using Entities;
using IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CommentaireRepository : ICommentaireRepository
    {
        private TPWikyContext _context;
        public CommentaireRepository(TPWikyContext context)
        {
            _context = context;
        }
        public async Task<int> AddAsync(Commentaire commentaire)
        {
            commentaire.DateModification = DateOnly.FromDateTime(DateTime.Now);
            commentaire.DateCreation = DateOnly.FromDateTime(DateTime.Now);
            _context.Commentaires.Add(commentaire);
            return await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int idToDelete)
        {
            bool ok;
            try
            {
                _context.Commentaires.Remove(_context.Commentaires.FirstOrDefault(c => c.Id == idToDelete));
                await _context.SaveChangesAsync();
                ok = true;
            }
            catch (Exception ex)
            {
                ok = false;
            }
            return ok;
        }

        public Commentaire Detail(int id)
        {
            return _context.Commentaires.FirstOrDefault(a => a.Id == id);
        }
    }
}
