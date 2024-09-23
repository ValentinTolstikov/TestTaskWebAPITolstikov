using Core.Entities;
using Core.Exceptions;
using Core.Interfaces;
using System.Linq.Expressions;

namespace Application.Services
{
    public class ClientService : IService<Client>
    {
        private readonly IRepository<Client> _clientRepository;
        private readonly IRepository<UserType> _userTypeRepository;
        private readonly IRepository<Founder> _founderRepository;

        public ClientService(IRepository<Client> clientRepository, IRepository<UserType> userTypeRepository, IRepository<Founder> founderRepository) 
        {
            _clientRepository = clientRepository;
            _userTypeRepository = userTypeRepository;
            _founderRepository = founderRepository;
        }

        public Task AddAsync(Client entity)
        {
            Task<List<Client>> tClient = _clientRepository.GetAsync(p => p.INN == entity.INN);
            tClient.Wait();
            Task<UserType> tUserType = _userTypeRepository.GetByIdAsync(entity.TypeId);
            tUserType.Wait();

            entity.DateEdit = DateTime.Now;
            entity.DateAdd = DateTime.Now;

            if (tClient.Result.Count == 0)
            {
                entity.UserType = tUserType.Result;
                return _clientRepository.AddAsync(entity);
            }
            else throw new UserNotUniqueException();
        }

        public Task DeleteAsync(int id)
        {
            Task<Client> tClient = _clientRepository.GetByIdAsync(id);
            tClient.Wait();
            if (tClient.Result == null)
            {
                throw new UserNotFoundException();
            }

            Task<UserType> tUserType = _userTypeRepository.GetByIdAsync(tClient.Result.TypeId);
            tUserType.Wait();

            if (tUserType.Result.TypeName == "ЮЛ")
            {
                Task<List<Founder>> tFounders = _founderRepository.GetAsync(p => p.ClientId == tClient.Result.Id);
                tFounders.Wait();

                foreach (Founder founder in tFounders.Result)
                {
                    _founderRepository.DeleteAsync(founder);
                }
            }

            return _clientRepository.DeleteAsync(tClient.Result);
        }

        public Task EditAsync(Client entity, int id)
        {
            Task<Client> tClient = _clientRepository.GetByIdAsync(id);
            tClient.Wait();
            if (tClient.Result != null)
            {
                tClient.Result.DateEdit = DateTime.Now;
                tClient.Result.TypeId = entity.TypeId;
                tClient.Result.INN = entity.INN;
                tClient.Result.Name = entity.Name;
                tClient.Result.UserType = entity.UserType;
                return _clientRepository.EditAsync(tClient.Result);
            }
            else throw new UserNotFoundException();
        }

        public Task<List<Client>> GetAllAsync()
        {
            return _clientRepository.GetAllAsync();
        }

        public Client GetById(int id)
        {
            Task<Client> tClient = _clientRepository.GetByIdAsync(id);
            tClient.Wait();
            if (tClient.Result != null)
            {
                return tClient.Result;
            }
            else
            { 
                throw new UserNotFoundException();
            }
        }
    }
}
