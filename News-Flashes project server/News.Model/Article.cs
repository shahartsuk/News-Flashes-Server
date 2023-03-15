using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace News.Model
{
    public  class Article
    {
        [Key]
        public int Id { get; set; }
        [Required, Display(Name = "Title")]
        public string Title { get; set; }
        [Display(Name = "LinkImage")]
        public string LinkImage { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required, Display(Name = "WebLink")]
        public string WebLink { get; set; }

        [Required, Display(Name = "Subject")]
        public string subjectName { get; set; }

        [Required, Display(Name = "Source")]
        public string Source { get; set;}


        public  string ExtractImageFromItem(XmlNode itemNode)
        {
            XmlNode descriptionNode = itemNode.SelectSingleNode("description");
            if (descriptionNode != null)
            {
                string description = descriptionNode.InnerText;
                // Regular expressions
                Match match = Regex.Match(description, @"<img.+?src=[\""'](.+?)[\""'].*?>");
                if (match.Success)
                {
                    return match.Groups[1].Value;
                }
            }
            return null;
        }

        public  string ExtractClearDescriptionFromItem(XmlNode itemNode)
        {
            string plainText;
            XmlNode descriptionNode = itemNode.SelectSingleNode("description");
            if (descriptionNode != null)
            {
                string description = descriptionNode.InnerText;
                // Regular expressions
                plainText = Regex.Replace(description, "<.*?>", string.Empty);
                return plainText.Trim();
            }
            return null;
        }


    }
}
