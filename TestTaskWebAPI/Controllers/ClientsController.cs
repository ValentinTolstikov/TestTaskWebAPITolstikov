using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace TestTaskWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly UserDBContext _dbContext;

        public ClientsController(UserDBContext userDBContext)
        { 
            _dbContext = userDBContext;
        }

        // GET: api/<ClientsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ClientsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ClientsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ClientsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ClientsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
