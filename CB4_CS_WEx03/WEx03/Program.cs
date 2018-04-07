using System;
using System.Collections.Generic;


namespace WEx03
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //Initialize Users
            List<User> users = new List<User>{
                new User("Mike"),
                new User("Aki"),
                new User("Kostas"),
                new User("Panos"),
                new User("Christopher")
            };

            // Print User List
            Console.WriteLine("\nUser list:");
            for (int i = 0; i < users.Count; i++)
            {
                Console.WriteLine(users[i]);
            }

            // Initialize 20 random posts
            List<BlogPost> myBlogPostList = new List<BlogPost>();
            Random rnd = new Random();
            int index;
            for (int i = 0; i < 20; i++)
            {
                index = rnd.Next(users.Count);
                LoremIpsum tempLI = new LoremIpsum();
                myBlogPostList.Add(new BlogPost(users[index],tempLI.Title,tempLI.Body));
            }


            //Print BlogPost list
            Console.WriteLine("\nBlog Post list:");
            Console.WriteLine(BlogPost.ConvertBlogListToJSONstring(myBlogPostList, users));


            List<BlogPost> result;

            // 1. Find the blog post with a given id. // using a random element from the list
            BlogPost postToSearch = myBlogPostList[rnd.Next(myBlogPostList.Count)];
            Guid GUIDtoSearch = postToSearch.Id;
            Console.WriteLine("\nId to search: " + GUIDtoSearch);
            Console.WriteLine("Result: ");
            result = myBlogPostList.FindAll(i => i.Id == GUIDtoSearch);
            Console.WriteLine(BlogPost.ConvertBlogListToJSONstring(result, users));

            // 1. Find the blog post with a given id. // using a non-existent guid.
            GUIDtoSearch = new Guid("asdjasdf-34fdg-v34-t344t");
            Console.WriteLine("\nId to search: " + GUIDtoSearch);
            Console.WriteLine("Result: ");
            result = myBlogPostList.FindAll(i => i.Id == GUIDtoSearch);
            Console.WriteLine(BlogPost.ConvertBlogListToJSONstring(result, users));


            // 2. Find all posts that contain a specific word in their bodies.
            string wordToSearch = "if";
            Console.WriteLine("\nWord to search: " + wordToSearch);
            Console.WriteLine("Results: ");
            result = myBlogPostList.FindAll(i => i.Body.Contains(wordToSearch));
            Console.WriteLine(BlogPost.ConvertBlogListToJSONstring(result, users));

            // 3. Find all posts that have a title with more than two words.
            int wordLimit = 2;
            Console.WriteLine("\nTItle word lower limit : " + wordLimit);
            Console.WriteLine("Results: ");
            result = myBlogPostList.FindAll(i => i.Title.Split(' ').Length > wordLimit);
            Console.WriteLine(BlogPost.ConvertBlogListToJSONstring(result, users));

            // 4. Find all posts written from a specific user.
            string usernameToSearch = "Mike";
            Console.WriteLine("\nUserame to search: " + usernameToSearch);
            Console.WriteLine("Results: ");
            result = myBlogPostList.FindAll(i => i.User == users.Find(j => j.Username == usernameToSearch));
            Console.WriteLine(BlogPost.ConvertBlogListToJSONstring(result, users));


            // 5. Return a list of all the post ids.  
            // The method BlogPost.ConvertBlogListToJSONstring can not be used in this case. The output format is not the same.
            Console.WriteLine("\nAll ids of 'myBlogPostList':");
            List<Guid> guids = new List<Guid>();
            foreach (BlogPost item in myBlogPostList)
            {
                guids.Add(item.Id);
                Console.WriteLine(item.Id);
            }

                
            //
            // How can we create methods for the list object of our own class??
            // 

        }
    }
}
