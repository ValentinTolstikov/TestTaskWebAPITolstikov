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

        /// <summary>
        /// Получает список всех клиентов.
        /// </summary>
        /// <returns>Список клиентов</returns>
        [HttpGet]
        public List<Client> Get()
        {
            Task<List<Client>> tGetClients = _clientService.GetAllAsync();
            tGetClients.Wait();
            return tGetClients.Result;
        }

        /// <summary>
        /// Получение клиента с заданным Ид
        /// </summary>
        /// <param name="id">Ид клиента</param>
        /// <returns>Клиента с заданным Ид</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_clientService.GetById(id));
            }
            catch { return NotFound(); }
        }

        /// <summary>
        /// Позволяет добавить нового клиента
        /// </summary>
        /// <param name="client">Данные нового клиента</param>
        /// <returns>200 если все клиент был добавлен, 400 если он добавлен небыл</returns>
        [HttpPost]
        public IActionResult Post([FromBody] ClientDTO client)
        {
            Client c = new Client {INN = client.INN,
                                   Name = client.Name,
                                   UserTypeId = client.TypeId};
            try
            {
                _clientService.AddAsync(c).Wait();
                return Ok(c);
            }
            catch {return BadRequest();}
        }

        /// <summary>
        /// Изменяет данные клиента
        /// </summary>
        /// <param name="id">Ид клиента</param>
        /// <param name="client">Новые данные</param>
        /// <returns>204 если все прошло успешно и 400 если произошла ошибка</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ClientDTO client)
        {
            Client c = new Client{INN = client.INN,
                                  Name = client.Name,
                                  UserTypeId = client.TypeId};
            try
            {
                Task tEdit = _clientService.EditAsync(c, id);
                tEdit.Wait();
                return NoContent();
            }
            catch { return BadRequest(); }
        }

        /// <summary>
        /// Удаляет клиента
        /// </summary>
        /// <param name="id">Ид удаляемого клиента</param>
        /// <returns>204 если клиент удален, 400 если произошла ошибка</returns>
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
