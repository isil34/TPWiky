using Entities;
using IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TPWiky.Controllers
{
    public class ArticleController : Controller
    {

        private IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }


        // GET: ArticleController
        public IActionResult Index()
        {
            return View(_articleService.GetAllArticle());
        }

        // GET: ArticleController/Details/5
        public IActionResult Detail(int id)
        {
            // ToDo Redirect to perso 404
            return View(_articleService.Detail(id));
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
                    _articleService.AddAsync(article);
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
            return View(_articleService.Detail(idToEdit));
        }

        // POST: ArticleController/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(Article article)
        {
            if (!ModelState.IsValid)
                return View(article);

            try
            {
                var ok = await _articleService.EditAsync(article);
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
            bool ok = _articleService.DeleteAsync(idToDelete).Result;
            TempData["Message"] = ok ? "Message supprimée" : "Message non supprimée";

            return RedirectToAction("Index");
        }

        public IActionResult CheckUniqTheme(string Theme)
        {
            bool res =  !_articleService.CheckUniqTheme(Theme).Result;
            return Json (res);

        }

        
    }
}
