using LayerTemplate.Business.Abstract;
using LayerTemplate.Business.Mapping;
using LayerTemplate.DataAccess.Context;
using LayerTemplate.DataAccess.Models;
using LayerTemplate.Dto.ApiDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerTemplate.Business.Concrete
{
    public class UserManager : IUserService
    {
        public IRepository<Person> _repository;

        public UserManager(IRepository<Person> repository)
        {
            _repository = repository;  //bu ve üstteki satır incelenecek.
        }


        public async Task AddUser(UserProfileDto user)
        {
            await _repository.Insert(AutoMapperBase._mapper.Map<UserProfileDto, Person>(user));
        }

        public async Task DeleteUser(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<List<Person>> GetAllUsers()
        {
            return await _repository.GetAll();
        }

        public Task<Person> GetUser(int id)
        {
            return _repository.Find(id);
        }

        public List<Person> SpecialRequestExample(string country)
        {
            return _repository.Queryable().Where(x => x.country == country).ToList();
        }

        public async Task UpdateUser(UserProfileDto user)
        {
            await _repository.Update(AutoMapperBase._mapper.Map<UserProfileDto, Person>(user));
        }

    }
}
