//using LayerTemplate.DataAccess.Repository;
using LayerTemplate.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using LayerTemplate.Dto.ApiDto;
using LayerTemplate.Business.Mapping;
using LayerTemplate.Business.Abstract;

namespace LayerTemplate.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        public IUserService _userService;
        public PersonController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var userList = await _userService.GetAllUsers();
            return Ok(AutoMapperBase._mapper.Map<List<Person>, List<UserProfileDto>>(userList));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _userService.GetUser(id);
            if (user == null) return NotFound();
            return Ok(AutoMapperBase._mapper.Map<Person, UserProfileDto>(user));
        }
        [HttpPost]
        public async Task<IActionResult> Post(UserProfileDto user)
        {
            await _userService.AddUser(user);               
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Put(UserProfileDto user)
        {
            if (user == null || user.Id == 0) return BadRequest();
            var userCheck = await _userService.GetUser(user.Id);
            if (userCheck == null) return NotFound();
            await _userService.UpdateUser(user);
            return Ok(user);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.DeleteUser(id);
            return Ok();
        }
    }
}
