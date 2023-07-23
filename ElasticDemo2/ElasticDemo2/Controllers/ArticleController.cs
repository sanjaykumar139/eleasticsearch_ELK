﻿using ElasticDemo2.Model;
using Microsoft.AspNetCore.Mvc;
using Nest;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElasticDemo2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IElasticClient _elasticClient;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public ArticleController(IElasticClient elasticClient, IWebHostEnvironment hostingEnvironment)
        {
            _elasticClient = elasticClient;
            _hostingEnvironment = hostingEnvironment;
        }


        [HttpPost(Name = "Create")]
        public async Task<string> Create(ArticleModel model)
        {
            string strResult = string.Empty;
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
                //model = new ArticleModel();
            }
            catch (Exception ex) { strResult = "failed"; }
            return strResult = "success";
        }

        //[HttpPost(Name = "Import")]
        //public string Import()
        //{
        //    string strResult = string.Empty;
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
        //    catch (Exception ex) { strResult = "failed"; }
        //    return strResult = "success";
        //}

        [HttpGet(Name = "GetSearch")]
        public IList<ArticleModel> GetSearch(string keyword)
        {
            var result = _elasticClient.SearchAsync<ArticleModel>(s => s.Query(q => q.QueryString(d => d.Query('*' + keyword + '*'))).Size(5000));
            var finalResult = result;
            var finalContent = finalResult.Result.Documents.ToList();
            return finalContent;
        }


        // GET: api/<ArticleController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<ArticleController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<ArticleController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<ArticleController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<ArticleController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
