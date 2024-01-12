using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository
{
    public interface ICommentaireRepository
    {
        Commentaire Detail(int id);

        Task<bool> DeleteAsync(int idToDelete);

        Task<int> AddAsync(Commentaire commentaire);
    }
}
