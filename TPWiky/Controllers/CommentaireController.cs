using Entities;
using IServices;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace TPWiky.Controllers
{
    public class CommentaireController : Controller
    {
        private ICommentaireService _commentaireService;

        public CommentaireController(ICommentaireService commentaireService)
        {
            _commentaireService = commentaireService;
        }

        public IActionResult Index()
        {
            return View();
        }

        // GET: CommentaireController/Add
        public IActionResult Add(int articleId)
        {
            ViewBag.ArticleId = articleId;
            return View();
        }

        // POST: CommentaireController/Add
        [HttpPost]
        public async Task<IActionResult> Add(Commentaire commentaire)
        {
            if (!ModelState.IsValid)
            {
                return View(commentaire);
            }
            else
            {
                try
                {
                    await _commentaireService.AddAsync(commentaire);
                    return RedirectToAction("Index", "Article");
                }
                catch
                {
                    return View();
                }

            }
        }

        // GET: CommentaireController/Details/5
        public IActionResult Detail(int id)
        {
            // ToDo Redirect to perso 404
            return View(_commentaireService.Detail(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAjax(int idToDelete, int idArticle)
        {
            bool ok = _commentaireService.DeleteAsync(idToDelete).Result;

            TempData["Message"] = ok ? "Message supprimée" : "Message non supprimée";


            return PartialView("_displayCommentaires", await _commentaireService.GetAllByArticleIdAsync(idArticle));
        }
    }
}
