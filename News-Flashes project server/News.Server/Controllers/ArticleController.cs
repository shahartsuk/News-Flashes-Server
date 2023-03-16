using Microsoft.AspNetCore.Mvc;
using News.Entities;
using News.Model;
using News.DataSql;

namespace News.Server.Controllers
{
    [ApiController]
    [Route("api/articles")]
    public class GetArticles
    {
        [HttpGet("GetArticlesFromRSS")]
        public void GetAllSubjectsList()
        {
            RequestGet request = new RequestGet();
           
            Task.Run(async () =>
            {
                while (true)
                {
                     List<RssSubjectsUrl> rssSubjectsUrls= DataLayer.Data.RssUrls.ToList();
                    foreach (RssSubjectsUrl RssUrl in rssSubjectsUrls)
                    {
                        await request.XMLRequestGet(RssUrl.Link);
                    }
                    MainManager.Instance.InitSave();
                }
              
            });


            
        }
        [HttpPost("GetArticlesFromDB")]
        public void SetUserSubjects(string[] userSubjects)
        {
            
        }

    }
}
