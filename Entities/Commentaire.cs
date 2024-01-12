using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Commentaire
    {

        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Le nom de l'auteur doit comporter 30 caractères maximum")]
        public string Auteur { get; set; }

        [DataType(DataType.Date)]
        public DateOnly DateCreation { get; set; }

        [DataType(DataType.Date)]
        public DateOnly DateModification { get; set; }

        [MaxLength(100, ErrorMessage ="Commentaire trop long (100 caractères maximum)")]
        public string Contenu { get; set; }

        [ForeignKey("Article")]
        public int ArticleId { get; set; }
        public virtual Article? Article { get; set; }

    }
}
