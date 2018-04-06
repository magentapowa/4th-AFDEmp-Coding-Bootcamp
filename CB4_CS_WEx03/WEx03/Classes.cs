using System;
using System.Net;
using System.Collections.Generic;
using HtmlAgilityPack;


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


    public class Guid : IEquatable
    {
        private readonly string url = "https://www.uuidgenerator.net/api/guid";
        public string ID { get; private set; }

		public override string ToString()
		{
            return this.ID;
		}

        public override bool Equals(object obj)
        {
            Guid guid = obj as Guid;
            if (this.ID == guid.ID )
            {
                return true;
            }
            return false;
        }

        public Guid()
        {
            WebClient wb = new WebClient();
            this.ID =wb.DownloadString(url).Trim();
        }
        public Guid(string ID)
        {
            this.ID = ID;
        }
    }


    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }

		public override string ToString()
		{
            return this.Username + ", " + this.Id;
		}

		public User(string Username)
        {
            this.Id = new Guid();
            this.Username = Username;
        }
    }


    public class BlogPost
    {
        public Guid Id { get; set; }
        public User User { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        // Converts BlogPost object to json string format
        public static string ConvertBlogToJSONstring(BlogPost post, List<User> userList)
        {
            string result = "";
            result = ("{ \"id\" : \"" + post.Id + "\", \"user\" : { \"username\" : \"" + post.User.Username + "\", \"id\" : \"" + userList.Find(j => j.Username == post.User.Username).Id + "\" }, \"Title\" : \"" + post.Title + "\", \"Body\" : \"" + post.Body + "\" }");
            return result;
        }

        // Converts BlogPost list object to json string format
        public static string ConvertBlogListToJSONstring(List<BlogPost> list, List<User> userList)
        {
            string result = "[ ";
            string[] parts = new string[list.Count];

            for (int i = 0; i < list.Count; i++)
            {
                //parts[i] = ("{ \"id\" : \"" + list[i].Id + "\", \"user\" : { \"username\" : \"" + list[i].User.Username + "\", \"id\" : \"" + userList.Find(j => j.Username == list[i].User.Username).Id + "\" }, \"Title\" : \"" + list[i].Title + "\", \"Body\" : \"" + list[i].Body + "\" }");
                parts[i] = ConvertBlogToJSONstring(list[i], userList);
            }
            result += string.Join(", ", parts) + "]";
            return result;
        }


        public static int FindPostByID(List<BlogPost> list, Guid Id)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Id == Id)
                {
                    return i;
                }
            }
            return -1;
        }

        public static List<BlogPost> FindAllWithWord(List<BlogPost> list, string word)
        {
            List<BlogPost> result = new List<BlogPost>();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Body.ToLower().Contains(word.ToLower()))
                {
                    result.Add(list[i]);
                }
            }
            return result;
        }
        public static List<BlogPost> FindAllByTitleWordsMoreThan(List<BlogPost> list, int words)
        {
            List<BlogPost> result = new List<BlogPost>();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Title.Split(' ').Length > words)
                {
                    result.Add(list[i]);
                }
            }
            return result;
        }
        public static List<BlogPost> FindAllByUsername(List<BlogPost> list,List<User> userList, string username)
        {
            List<BlogPost> result = new List<BlogPost>();
            User user = userList.Find(i => i.Username == username);
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].User == user)
                {
                    result.Add(list[i]);
                }
            }
            return result;
        }

        public static List<Guid> GetAllIDs(List<BlogPost> list)
        {
            List<Guid> result = new List<Guid>();
            for (int i = 0; i < list.Count; i++)
            {
                result.Add(list[i].Id);
            }
            return result;
        }

		public override string ToString()
		{
            return this.Id + ", " + this.User.Username + ", " + this.Title;
		}

		public BlogPost(User user, string Title, string Body)
        { 
            this.Id = new Guid();
            this.User = user;
            this.Title = Title;
            this.Body = Body;
        }
    }
}
