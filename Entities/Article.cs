using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Article 
    {
        [Required]
        public int Id { get; set; }

        [StringLength(50, ErrorMessage = "La taille du nom doit être de maximum 50 caractère !")]
        [Remote("CheckUniq", "ArticleController", ErrorMessage ="Un article du même thème a déjà été crée !")]
        public string Theme { get; set; }

        [Required]
        [StringLength(30, ErrorMessage ="Le nom de l'auteur doit comporter 30 caractères maximum")]
        public string Auteur { get; set; }

        [DataType(DataType.Date)]
        public DateOnly DateCreation { get; set; }

        [DataType(DataType.Date)]
        public DateOnly DateModification { get; set; }

        public string Contenu {  get; set; }

        public List<Commentaire> Commentaires { get; set; }
    }
}
