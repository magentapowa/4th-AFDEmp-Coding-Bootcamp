using System;
using System.Net;
using System.Collections.Generic;
using HtmlAgilityPack;
using Newtonsoft.Json;

namespace WEx03
{
    public class LoremIpsum
    {
        private readonly string url = "https://loripsum.net/api/1/headers";
        public string Title { get; private set; }
        public string Body { get; private set; }

        public LoremIpsum()
        {
            WebClient wb = new WebClient();
            string source = wb.DownloadString(url);
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(source);
            this.Title = doc.DocumentNode.Element("h1").InnerText.Trim();
            this.Body = doc.DocumentNode.Element("p").InnerText.Trim();
        }
    }


    public class Guid : IEquatable<Guid>
    {
        private static readonly string url = "https://www.uuidgenerator.net/api/guid";
        public string ID;

		public override string ToString()
		{
            return this.ID;
		}

        public bool Equals(Guid other)
        {
            if (this.ID == other.ID)
            {
                return true;
            }
            return false;
        }

        public Guid()
        {
            WebClient wb = new WebClient();
            this.ID = wb.DownloadString(url).Trim();
        }
        public Guid(string ID)
        {
            this.ID = ID;
        }
    }


    public class User
    {
        public Guid Guid { get; set; }
        public string Username { get; set; }

		public override string ToString()
		{
            return this.Username + ", " + this.Guid;
		}

		public User(string Username)
        {
            this.Guid = new Guid();
            this.Username = Username;
        }
    }


    public class BlogPost
    {
        public Guid Guid { get; set; }
        public User User { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        // Converts BlogPost list object to json string format
        public static string ConvertBlogListToJSONstring(List<BlogPost> list, List<User> userList)
        {
            //
            // 1st - Using Newtonsoft.Json library. Just return the serialized object. 
            // Though it does not produce exactly the required format.
            //
            // return JsonConvert.SerializeObject(list);


            string result = "[ ";
            string[] parts = new string[list.Count];

            for (int i = 0; i < list.Count; i++)
            {
                // 2nd - Just manualy building the string
                parts[i] = ("{ \"id\" : \"" + list[i].Guid + "\", \"user\" : { \"username\" : \"" + list[i].User.Username + "\", \"id\" : \"" + userList.Find(j => j.Username == list[i].User.Username).Guid + "\" }, \"Title\" : \"" + list[i].Title + "\", \"Body\" : \"" + list[i].Body + "\" }");

            }
            result += string.Join(", ", parts) + "]";
            return result;
        }


		public override string ToString()
		{
            return this.Guid + ", " + this.User.Username + ", " + this.Title;
		}

		public BlogPost(User user, string Title, string Body)
        { 
            this.Guid = new Guid();
            this.User = user;
            this.Title = Title;
            this.Body = Body;
        }
    }
}
