using ElasticDemo.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nest;
using Newtonsoft.Json;

namespace ElasticDemo.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IElasticClient _elasticClient;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public ValuesController(IElasticClient elasticClient, IWebHostEnvironment hostingEnvironment)
        {
            _elasticClient = elasticClient;
            _hostingEnvironment = hostingEnvironment;
        }


        [HttpPost]
        public async Task<string> Create(ArticleModel model)
        {
            string strResult= string.Empty;
            try
            {
                var article = new ArticleModel()
                {
                    Id = 1,
                    Title = model.Title,
                    Link = model.Link,
                    Author = model.Author,
                    AuthorLink = model.AuthorLink,
                    PublishedDate = DateTime.Now
                };
                await _elasticClient.IndexDocumentAsync(article);
                model = new ArticleModel();
            }
            catch (Exception ex) { strResult = "failed"; }
            return strResult = "success";
        }

        [HttpPost]
        public string Import()
        {
            string strResult = string.Empty;
            try
            {
                var rootPath = _hostingEnvironment.ContentRootPath; //get the root path
                var fullPath = Path.Combine(rootPath, "articles.json"); //combine the root path with that of our json file inside mydata directory
                var jsonData = System.IO.File.ReadAllText(fullPath); //read all the content inside the file
                var articleList = JsonConvert.DeserializeObject<List<ArticleModel>>(jsonData);
                if (articleList != null)
                {
                    foreach (var article in articleList)
                    {
                        _elasticClient.IndexDocumentAsync(article);
                    }
                }
            }
            catch (Exception ex) { strResult = "failed"; }
            return strResult = "success";
        }

        [HttpGet(Name= "GetSearch")]
        public IList<ArticleModel> GetSearch(string keyword)
        {
            var result = _elasticClient.SearchAsync<ArticleModel>(s => s.Query(q => q.QueryString(d => d.Query('*' + keyword + '*'))).Size(5000));
            var finalResult = result;
            var finalContent = finalResult.Result.Documents.ToList();
            return finalContent;
        }

        //public ActionResult Index(string keyword)
        //{
        //    var articleList = new List<ArticleModel>();
        //    if (!string.IsNullOrEmpty(keyword))
        //    {
        //        articleList = GetSearch(keyword).ToList();
        //    }
        //    return View(articleList.AsEnumerable());
        //}
    }
}
