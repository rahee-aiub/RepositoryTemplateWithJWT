using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecruitmentManagement.Interface;
using RecruitmentManagement.Model;

namespace RecruitmentManagement.Controllers
{
    [ApiController]
    [Route("controller")]
    public class UserController : ControllerBase
    {

        private IUserService service;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService service, ILogger<UserController> logger)
        {
            this.service = service;
            this._logger = logger;
        }

        [HttpGet]
        [Route("GetAllUser"),Authorize]
        public IList<User> GetAllUser()
        {
            _logger.LogDebug("Getting all user");
            var data = service.GetList();
            return data;
        }
    }

}