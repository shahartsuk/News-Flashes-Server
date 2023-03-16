using Microsoft.AspNetCore.Mvc;
using News.Entities;

namespace News.Server.Controllers
{
    [ApiController]
    [Route("api/checking")]
    public class CheckingData
    {
        [HttpGet("GetUsers")]
        public JsonResult GetAllUsers()
        {
            return new JsonResult(MainManager.Instance.subjectManager.GetDataFromDB("user"));
        }
    }
}
