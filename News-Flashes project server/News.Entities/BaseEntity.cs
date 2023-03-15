using News.DataSql;
using News.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Entities
{
    public abstract class BaseEntity
    {
        public object GetDataFromDB(string provider)
        {
            switch (provider)
            {
                case "subject":
                return DataLayer.Data.Subjects.ToList();
                case "article":
                    return DataLayer.Data.Articles.ToList();
                case "rssurl":
                    return DataLayer.Data.RssUrls.ToList();
            }
            return null;
        }
    }
}
