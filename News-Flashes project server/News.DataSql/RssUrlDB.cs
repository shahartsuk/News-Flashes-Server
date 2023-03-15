using News.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.DataSql
{
    public class RssUrlDB
    {
        public static List<RssSubjectsUrl> GetRssUrlsDB()
        {
            return DataLayer.Data.RssUrls.ToList();
        }
    }
}
