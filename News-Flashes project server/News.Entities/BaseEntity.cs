using News.DataSql;
using News.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
                return DataLayer.Data.SubjectsAllIncludes();
                case "article":
                    return DataLayer.Data.Articles.ToList();
                case "rssurl":
                    return DataLayer.Data.RssUrls.ToList();
                case "user":
                    return DataLayer.Data.Users.ToList();
                case "userSubjects":
                    return DataLayer.Data.UserSubjectAllIncludes();
            }
            return null;
        }

        public static void InitSave()
        {
            SaveLocalChanges.SaveInData(); 
        }

        public static void InitClear()
        {
            SaveLocalChanges.ClearData();
        }

    }
}
