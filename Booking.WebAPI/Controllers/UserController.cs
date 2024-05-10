using Booking.BLL.Interfaces;
using Booking.BLL.Models;
using Booking.WebAPI.Validation;
using Microsoft.AspNetCore.Mvc;

namespace Booking.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserModel>>> Get()
        {
            var users = await _userService.GetAllAsync();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> GetById(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("User id cant be empty");
            }

            var user = await _userService.GetByIdAsync(id);

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> Create(UserModel model)
        {
            string errors = Validator.User(model);

            if(!string.IsNullOrEmpty(errors))
            {
                return BadRequest(errors);
            }

            var user = await _userService.AddAsync(model);

            return Ok(user);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(Guid id)
        {
            if(id == Guid.Empty)
            {
                return BadRequest("User id cant be empty");
            }

            await _userService.DeleteAsync(id);

            return Ok();
        }

        [HttpPatch]
        public async Task<ActionResult<UserModel>> Update(UserModel model)
        {
            string errors = Validator.User(model);

            if (!string.IsNullOrEmpty(errors))
            {
                return BadRequest(errors);
            }

            var user = await _userService.UpdateAsync(model);

            return Ok(user);
        }
    }
}
