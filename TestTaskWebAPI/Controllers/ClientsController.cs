using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using TestTaskWebAPI.DTOs;

namespace TestTaskWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IService<Client> _clientService;

        public ClientsController(IService<Client> clientService)
        { 
            _clientService = clientService;
        }

        // GET: api/<ClientsController>
        [HttpGet]
        public List<Client> Get()
        {
            Task<List<Client>> tGetClients = _clientService.GetAllAsync();
            tGetClients.Wait();
            return tGetClients.Result;
        }

        // GET api/<ClientsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_clientService.GetById(id));
            }
            catch { return NotFound(); }
        }

        // POST api/<ClientsController>
        [HttpPost]
        public IActionResult Post([FromBody] ClientDTO client)
        {
            Client c = new Client {INN = client.INN,
                                   Name = client.Name,
                                   TypeId = client.TypeId};
            try
            {
                _clientService.AddAsync(c).Wait();
                return Ok(c);
            }
            catch (Exception ex) 
            { 
                return BadRequest(); 
            }
        }

        // PUT api/<ClientsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ClientDTO client)
        {
            Client c = new Client{INN = client.INN,
                                  Name = client.Name,
                                  TypeId = client.TypeId};
            try
            {
                Task tEdit = _clientService.EditAsync(c, id);
                tEdit.Wait();
                return NoContent();
            }
            catch { return BadRequest(); }
        }

        // DELETE api/<ClientsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _clientService.DeleteAsync(id).Wait();
                return NoContent();
            }
            catch { return BadRequest(); }
        }
    }
}
