using ElasticDemo.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nest;

namespace ElasticDemo.Controller
{
    public class ArticleController
    {
        //private readonly IElasticClient _elasticClient;
        //private readonly IWebHostEnvironment _hostingEnvironment;
        //public ArticleController(IElasticClient elasticClient, IWebHostEnvironment hostingEnvironment)
        //{
        //    _elasticClient = elasticClient;
        //    _hostingEnvironment = hostingEnvironment;
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(ArticleModel model)
        //{
        //    try
        //    {
        //        var article = new ArticleModel()
        //        {
        //            Id = 1,
        //            Title = model.Title,
        //            Link = model.Link,
        //            Author = model.Author,
        //            AuthorLink = model.AuthorLink,
        //            PublishedDate = DateTime.Now
        //        };
        //        await _elasticClient.IndexDocumentAsync(article);
        //        model = new ArticleModel();
        //    }
        //    catch (Exception ex) { }
        //    return View(model);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Import()
        //{
        //    try
        //    {
        //        var rootPath = _hostingEnvironment.ContentRootPath; //get the root path
        //        var fullPath = Path.Combine(rootPath, "articles.json"); //combine the root path with that of our json file inside mydata directory
        //        var jsonData = System.IO.File.ReadAllText(fullPath); //read all the content inside the file
        //        var articleList = JsonConvert.DeserializeObject<List<ArticleModel>>(jsonData);
        //        if (articleList != null)
        //        {
        //            foreach (var article in articleList)
        //            {
        //                _elasticClient.IndexDocumentAsync(article);
        //            }
        //        }
        //    }
        //    catch (Exception ex) { }
        //    return RedirectToAction("Index");
        //}

        //[HttpGet]
        //public ActionResult Index(string keyword)
        //{
        //    var articleList = new List<ArticleModel>();
        //    if (!string.IsNullOrEmpty(keyword))
        //    {
        //        articleList = GetSearch(keyword).ToList();
        //    }
        //    return View(articleList.AsEnumerable());
        //}
        //public IList<ArticleModel> GetSearch(string keyword)
        //{
        //    var result = _elasticClient.SearchAsync<ArticleModel>(s => s.Query(q => q.QueryString(d => d.Query('*' + keyword + '*'))).Size(5000));
        //    var finalResult = result;
        //    var finalContent = finalResult.Result.Documents.ToList();
        //    return finalContent;
        //}
    }
    //public class ArticleController : Controller
    //{
    //    // GET: ArticleController
    //    public ActionResult Index()
    //    {
    //        return View();
    //    }

    //    // GET: ArticleController/Details/5
    //    public ActionResult Details(int id)
    //    {
    //        return View();
    //    }

    //    // GET: ArticleController/Create
    //    public ActionResult Create()
    //    {
    //        return View();
    //    }

    //    // POST: ArticleController/Create
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult Create(IFormCollection collection)
    //    {
    //        try
    //        {
    //            return RedirectToAction(nameof(Index));
    //        }
    //        catch
    //        {
    //            return View();
    //        }
    //    }

    //    // GET: ArticleController/Edit/5
    //    public ActionResult Edit(int id)
    //    {
    //        return View();
    //    }

    //    // POST: ArticleController/Edit/5
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult Edit(int id, IFormCollection collection)
    //    {
    //        try
    //        {
    //            return RedirectToAction(nameof(Index));
    //        }
    //        catch
    //        {
    //            return View();
    //        }
    //    }

    //    // GET: ArticleController/Delete/5
    //    public ActionResult Delete(int id)
    //    {
    //        return View();
    //    }

    //    // POST: ArticleController/Delete/5
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult Delete(int id, IFormCollection collection)
    //    {
    //        try
    //        {
    //            return RedirectToAction(nameof(Index));
    //        }
    //        catch
    //        {
    //            return View();
    //        }
    //    }
    //}
}
