using Entities;
using IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TPWiky.Controllers
{
    public class ArticleController : Controller
    {

        private IArticleRepository _articleRepository;

        public ArticleController(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }


        // GET: ArticleController
        public IActionResult Index()
        {
            return View(_articleRepository.GetAllArticle());
        }

        // GET: ArticleController/Details/5
        public IActionResult Details(int id)
        {
            // ToDo Redirect to perso 404
            return View(_articleRepository.Detail(id));
        }

        // GET: ArticleController/Create
        public IActionResult Add()
        {
            return View();
        }

        // POST: ArticleController/Create
        [HttpPost]
        public async Task<IActionResult> Add(Article article)
        {
            if (!ModelState.IsValid)
            {
                return View(article);
            }
            else
            {
                try
                {
                    _articleRepository.AddAsync(article);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
                
            }
        }

        // GET: ArticleController/Edit/5
        public IActionResult Edit(int idToEdit)
        {
            return View(_articleRepository.Detail(idToEdit));
        }

        // POST: ArticleController/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(Article article)
        {
            if (!ModelState.IsValid)
                return View(article);

            try
            {
                var ok = await _articleRepository.EditAsync(article);
                TempData["Message"] = ok ? "Message modifié" : "Message Non Modifié";
                return RedirectToAction("Detail", new {Id = article.Id});
            }
            catch
            {
                return View();
            }
        }

        // GET: ArticleController/Delete/5
        public async Task<IActionResult> Delete(int idToDelete)
        {
            bool ok = _articleRepository.DeleteAsync(idToDelete).Result;
            TempData["Message"] = ok ? "Message supprimée" : "Message non supprimée";

            return RedirectToAction("Index");
        }

    }
}
