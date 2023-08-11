using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElasticDemo.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController1 : ControllerBase
    {
        // GET: api/<TestController1>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<TestController1>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TestController1>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TestController1>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TestController1>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
