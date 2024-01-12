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
    public class CommentaireService : ICommentaireService
    {
        private ICommentaireRepository _commentaireRepository;

        public CommentaireService(ICommentaireRepository commentaireRepository)
        {
            _commentaireRepository = commentaireRepository;
        }

        public Task<int> AddAsync(Commentaire commentaire)
        {
            commentaire.DateCreation = DateOnly.FromDateTime(DateTime.Now);
            commentaire.DateModification = DateOnly.FromDateTime(DateTime.Now);
            return _commentaireRepository.AddAsync(commentaire);
        }

        public Task<bool> DeleteAsync(int idToDelete)
        {
            return _commentaireRepository.DeleteAsync(idToDelete);
        }

        public Commentaire Detail(int id)
        {
            return _commentaireRepository.Detail(id);
        }

        public Task<List<Commentaire>> GetAllByArticleIdAsync(int articleId)
        {
            return _commentaireRepository.GetAllByArticleIdAsync(articleId);
        }
    }
}
