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
            return View(_articleService.GetLastArticleAsync().Result);
        }

        // GET: ArticleController/ListAll
        public IActionResult ListeAll()
        {
            return View(_articleService.GetAllArticle());
        }

        // GET: ArticleController/Details/5
        public IActionResult Detail(int id)
        {
            // ToDo Redirect to perso 404
            return View(_articleService.Detail(id));
        }

        // GET: ArticleController/Add
        public IActionResult Add()
        {
            return View();
        }

        // POST: ArticleController/Add
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
                    await _articleService.AddAsync(article);
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
                TempData["Message"] = await _articleService.EditAsync(article) ? "Message modifié" : "Message Non Modifié";
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

        [HttpPost]
        public async Task<IActionResult> SearchAjax(string auteur)
        {
            var messages = await _articleService.SearchAjax(auteur);

            return PartialView("_displayArticles", messages);
            //return RedirectToRoute("Detail/" + pet.Id);
        }

        [HttpGet]
        public IActionResult GetAllJson()
        {
            //return Json(await petRepository.GetAllAsync());
            return PartialView("_displayArticles", _articleService.GetAllArticle());
        }


    }
}
