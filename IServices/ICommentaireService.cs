using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IServices
{
    public interface ICommentaireService
    {
        Commentaire Detail(int id);

        Task<bool> DeleteAsync(int idToDelete);

        Task<int> AddAsync(Commentaire commentaire);

        Task<List<Commentaire>> GetAllByArticleIdAsync(int articleId);
    }
}
