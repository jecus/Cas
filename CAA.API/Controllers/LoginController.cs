﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CAA.Entity.Core;
using CAA.Entity.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CAA.API.Controllers
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
		public async Task<ActionResult<CAAUserDTO>> GetUser(string login, string password)
		{
            var res = await _context.UserDtos.FirstOrDefaultAsync(i => !i.IsDeleted && i.Login.Equals(login) && i.Password.Equals(password));
            return Ok(res);
		}

		[HttpGet("getall")]
		public async Task<ActionResult<List<CAAUserDTO>>> GetAllList()
		{
            var res = await _context.UserDtos.Where(i => !i.IsDeleted).ToListAsync();
            return Ok(res);
		}

        [HttpGet("getall/{operatorId}")]
        public async Task<ActionResult<List<CAAUserDTO>>> GetAllList(int operatorId)
        {
            var res = await _context.UserDtos.Where(i => !i.IsDeleted && i.OperatorId == operatorId).ToListAsync();
            return Ok(res);
        }

        [HttpGet("{userId}")]
		public async Task<ActionResult<CAAUserDTO>> GetById(int userId)
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
		public async Task<ActionResult> AddOrUpdateUser(CAAUserDTO caaUser)
		{
            if (caaUser.ItemId > 0)
            {
                var updateUser = await _context.UserDtos.FirstOrDefaultAsync(i => i.ItemId == caaUser.ItemId);
                updateUser.Login = caaUser.Login;
                updateUser.Password = caaUser.Password;
                updateUser.Name = caaUser.Name;
                updateUser.Surname = caaUser.Surname;
                updateUser.OperatorId = caaUser.OperatorId;
                updateUser.CAAUserType = caaUser.CAAUserType;
                updateUser.UiType = caaUser.UiType;
                updateUser.PersonnelId = caaUser.PersonnelId;
                updateUser.CorrectorId = caaUser.CorrectorId;
                updateUser.Updated = DateTime.Now;
            }
            else
            {
                var newUser = new CAAUserDTO
                {
                    Login = caaUser.Login,
                    Password = caaUser.Password,
                    Name = caaUser.Name,
                    Surname = caaUser.Surname,
                    OperatorId = caaUser.OperatorId,
                    CAAUserType = caaUser.CAAUserType,
                    UiType = caaUser.UiType,
                    PersonnelId = caaUser.PersonnelId,
                    CorrectorId = caaUser.CorrectorId,
                    Updated = DateTime.Now
                };

                _context.UserDtos.Add(newUser);

            }

            await _context.SaveChangesAsync();
            return Ok();
		}
	}
}