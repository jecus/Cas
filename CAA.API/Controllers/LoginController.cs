using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CAA.Entity.Core;
using CAA.Entity.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers
{
	[ApiController]
	[Route("user")]
	public class LoginController : ControllerBase
	{
		private readonly DataContext _context;
		private readonly ILogger<LoginController> _logger;

		public LoginController(DataContext context,ILogger<LoginController> logger)
		{
			_context = context;
			_logger = logger;
		}

		[HttpGet("get")]
		public async Task<ActionResult<UserDTO>> GetUser(string login, string password)
		{
            var res = await _context.UserDtos.FirstOrDefaultAsync(i => !i.IsDeleted && i.Login.Equals(login) && i.Password.Equals(password));
            return Ok(res);
		}

		[HttpGet("getall")]
		public async Task<ActionResult<List<UserDTO>>> GetAllList()
		{
            var res = await _context.UserDtos.Where(i => !i.IsDeleted).ToListAsync();
            return Ok(res);
		}

		[HttpGet("{userId}")]
		public async Task<ActionResult<UserDTO>> GetById(int userId)
		{
			var res = await _context.UserDtos.Where(i => !i.IsDeleted).FirstOrDefaultAsync(i => !i.IsDeleted && i.ItemId == userId);
			return Ok(res);
		}

		[HttpPost("updatepaswword")]
		public async Task<ActionResult> UpdatePassword(int id, string password)
		{
            var user = await _context.UserDtos.FirstOrDefaultAsync(i => i.ItemId == id);
            user.Password = password;
            await _context.SaveChangesAsync();
            return Ok();
		}

		[HttpPost("delete")]
		public async Task<ActionResult> DeleteUser(int id)
		{
            var user = await _context.UserDtos.FirstOrDefaultAsync(i => i.ItemId == id);
            if (user != null)
            {
                user.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
            return Ok();
		}

		[HttpPost("addorupdate")]
		public async Task<ActionResult> AddOrUpdateUser(UserDTO user)
		{
            if (user.ItemId > 0)
            {
                var updateUser = await _context.UserDtos.FirstOrDefaultAsync(i => i.ItemId == user.ItemId);
                updateUser.Login = user.Login;
                updateUser.Password = user.Password;
                updateUser.Name = user.Name;
                updateUser.Surname = user.Surname;
            }
            else
            {
                var newUser = new UserDTO
                {
                    Login = user.Login,
                    Password = user.Password,
                    Name = user.Name,
                    Surname = user.Surname,
                };

                _context.UserDtos.Add(newUser);

            }

            await _context.SaveChangesAsync();
            return Ok();
		}
	}
}