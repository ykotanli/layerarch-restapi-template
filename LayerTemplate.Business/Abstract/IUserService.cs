using LayerTemplate.DataAccess.Models;
using LayerTemplate.Dto.ApiDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerTemplate.Business.Abstract
{
    public interface IUserService
    {
        //crud operasyonlar
        Task AddUser(UserProfileDto user);
        Task<Person> GetUser(int id);
        Task DeleteUser(int id);
        Task UpdateUser(UserProfileDto user);
        Task<List<Person>> GetAllUsers();
        List<Person> SpecialRequestExample(string country);
    }
}
