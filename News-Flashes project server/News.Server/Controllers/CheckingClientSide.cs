using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using News.Entities;
using News.Model;

namespace News.Server.Controllers
{
    [ApiController]
    [Route("api/Subjects")]
    public class CheckingClientSide
    {
        [HttpGet("GetSubjects")]
        public JsonResult GetAllSubjectsList()
        {
            List<Subject> subjects = DataLayer.Data.Subjects.ToList();
            return new JsonResult(subjects);
        }
    }
}
