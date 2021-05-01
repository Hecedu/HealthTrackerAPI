using HBealthTrackerAPI.Authentication;
using HealthTrackerAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HealthTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HealthTrackerController : ControllerBase
    {
        private readonly ILogger<HealthTrackerController> _logger;

        private IRepository _repository;
        public IRepository SqlRepository=> _repository;

        public HealthTrackerController(ILogger<HealthTrackerController> logger, IRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpPost]
        [Route("AddMealLog")]
        public async Task<IActionResult> AddMealLog([FromBody] UserMealLog userMealLog)
        {
            await SqlRepository.AddUserMealLogAsync(userMealLog);
            return Ok(new Response { Status = "Success", Message = "Added UserMealLog Successfuly" });
        }
        [HttpPost]
        [Route("AddMealLogs")]
        public async Task<IActionResult> AddMealLogs([FromBody] IEnumerable<UserMealLog> userMealLogs)
        {
            await SqlRepository.AddUserMealLogsAsync(userMealLogs);
            return Ok(new Response { Status = "Success", Message = "Added UserMealLogs Successfuly" });
        }
        [HttpPost]
        [Route("DeleteMealLog")]
        public async Task<IActionResult> DeleteMealLog([FromBody] UserMealLog userMealLog)
        {
            await SqlRepository.DeleteUserMealLogAsync(userMealLog);
            return Ok(new Response { Status = "Success", Message = "Deleted UserMealLog Successfuly" });
        }
        [HttpPost]
        [Route("GetUserMealLogs")]
        public async Task<IEnumerable<UserMealLog>> GetUserMealLogs(string userId)
        { 
            return await SqlRepository.GetUserMealLogs(userId);
        }
        [HttpGet]
        [Route("GetAllMealLogs")]
        public async Task<IEnumerable<UserMealLog>> GetAllMealLogs()
        {
            return await SqlRepository.GetAllUserMealLogs();
        }


        [HttpPost]
        [Route("AddActivityLog")]
        public async Task<IActionResult> AddActivityLog([FromBody] UserActivityLog userActivityLog)
        {
            await SqlRepository.AddUserActivityLogAsync(userActivityLog);
            return Ok(new Response { Status = "Success", Message = "Added UserActivityLog Successfuly"});
        }
        [HttpPost]
        [Route("AddActivityLogs")]
        public async Task<IActionResult> AddActivityLogs([FromBody] IEnumerable<UserActivityLog> userActivityLogs)
        {
            await SqlRepository.AddUserActivityLogsAsync(userActivityLogs);
            return Ok(new Response { Status = "Success", Message = "Added UserActivityLogs Successfuly" });
        }
        [HttpPost]
        [Route("DeleteActivityLog")]
        public async Task<IActionResult> DeleteActivityLog([FromBody] UserActivityLog userActivityLog)
        {
            await SqlRepository.DeleteUserActivityLogAsync(userActivityLog);
            return Ok(new Response { Status = "Success", Message = "Deleted UserMealLog Successfuly" });
        }
        [HttpPost]
        [Route("GetUserActivityLogs")]
        public async Task<IEnumerable<UserActivityLog>> GetUserActivityLogs(string userId)
        {
            return await SqlRepository.GetUserActivityLogs(userId);
        }
        [HttpGet]
        [Route("GetAllActivityLogs")]
        public async Task<IEnumerable<UserActivityLog>> GetAllActivityLogs()
        {
            return await SqlRepository.GetAllUserActivityLogs();
        }

        [HttpPost]
        [Route("DeleteUserLogs")]
        public async Task<IActionResult> DeleteUserLogs(string userId)
        {
            await SqlRepository.DeleteUserActivityLogsAsync(userId);
            await SqlRepository.DeleteUserMealLogsAsync(userId);
            return Ok(new Response { Status = "Success", Message = $"Deleted all logs with user Id: {userId}" });
        }
    }
}
