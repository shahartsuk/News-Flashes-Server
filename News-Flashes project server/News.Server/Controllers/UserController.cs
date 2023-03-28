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
        [HttpPost("userSubjects/{email}/{subjects}")]
        public void GetUserSubjects(string email, string subjects)
        {
            string[] userSubjects = subjects.Split(',');
            MainManager.Instance.userManager.AddUserSubject(email, userSubjects);
        }

        [HttpGet("getArticlesForUser")]
        public JsonResult GetArticlesForEachUser(string email)
        {
            return new JsonResult(MainManager.Instance.articleManager.GetArticleForEachUserEntities(email));
        }
    }
}
