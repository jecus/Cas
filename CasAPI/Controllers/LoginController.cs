using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers
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
			try
			{
				var res = await _context.UserDtos.FirstOrDefaultAsync(i => !i.IsDeleted && i.Login.Equals(login) && i.Password.Equals(password));
				return Ok(res);
			}
			catch (Exception e)
			{
				_logger.LogError(e.Message);
				return BadRequest();
			}
		}

		[HttpGet("getall")]
		public async Task<ActionResult<List<UserDTO>>> GetAllList()
		{
			try
			{
				var res = await _context.UserDtos.Where(i => !i.IsDeleted).ToListAsync();
				return Ok(res);
			}
			catch (Exception e)
			{
				_logger.LogError(e.Message);
				return BadRequest();
			}
		}

		[HttpPost("updatepaswword")]
		public async Task<ActionResult> UpdatePassword(int id, string password)
		{
			try
			{
				var user = await _context.UserDtos.FirstOrDefaultAsync(i => i.ItemId == id);
				user.Password = password;
				await _context.SaveChangesAsync();
				return Ok();
			}
			catch (Exception e)
			{
				_logger.LogError(e.Message);
				return BadRequest();
			}
		}

		[HttpPost("delete")]
		public async Task<ActionResult> DeleteUser(int id)
		{
			try
			{
				var user = await _context.UserDtos.FirstOrDefaultAsync(i => i.ItemId == id);
				if (user != null)
				{
					user.IsDeleted = true;
					await _context.SaveChangesAsync();
				}
				return Ok();
			}
			catch (Exception e)
			{
				_logger.LogError(e.Message);
				return BadRequest();
			}
		}

		[HttpPost("addorupdate")]
		public async Task<ActionResult> AddOrUpdateUser(UserDTO user)
		{
			try
			{
				if (user.ItemId > 0)
				{
					var updateUser = await _context.UserDtos.FirstOrDefaultAsync(i => i.ItemId == user.ItemId);
					updateUser.Login = user.Login;
					updateUser.Password = user.Password;
					updateUser.Name = user.Name;
					updateUser.Password = user.Password;
					updateUser.UserType = user.UserType;
					updateUser.UiType = user.UiType;
				}
				else
				{
					var newUser = new UserDTO();
					newUser.Login = user.Login;
					newUser.Password = user.Password;
					newUser.Name = user.Name;
					newUser.Surname = user.Surname;
					newUser.UserType = user.UserType;
					newUser.UiType = user.UiType;

					_context.UserDtos.Add(newUser);

				}

				await _context.SaveChangesAsync();
				return Ok();
			}
			catch (Exception e)
			{
				_logger.LogError(e.Message);
				return BadRequest();
			}
		}
	}
}