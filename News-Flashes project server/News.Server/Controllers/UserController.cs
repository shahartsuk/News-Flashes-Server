using Microsoft.AspNetCore.Mvc;
using News.Entities;
using News.Model;

namespace News.Server.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController
    {
        [HttpPost("CreateNewUser")]
        public void GetUserDetails(User user)
        {
            MainManager.Instance.userManager.SendUserDetails(user);
        }
        [HttpPost("userSubjects/{email?}")]
        public void GetUserSubjects(string email, string[] subjects)
        {
            MainManager.Instance.userManager.AddUserSubject(email, subjects);
        }
    }
}
