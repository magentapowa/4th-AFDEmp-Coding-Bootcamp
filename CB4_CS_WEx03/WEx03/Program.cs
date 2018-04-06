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


            List<BlogPost> myBlogPostList = new List<BlogPost>();
            Random rnd = new Random();
            int index;
            // Initialize 20 random posts
            for (int i = 0; i < 20; i++)
            {
                index = rnd.Next(users.Count);
                LoremIpsum tempLI = new LoremIpsum();
                myBlogPostList.Add(new BlogPost(users[index],tempLI.Title,tempLI.Body));
            }

            //Print BlogPost list
            Console.WriteLine("\nBlog Post list:");
            Console.WriteLine(BlogPost.ConvertBlogListToJSONstring(myBlogPostList, users));


            // Implement BlogPost.FindPostByID using a random element from the list
            BlogPost postToSearch = myBlogPostList[rnd.Next(myBlogPostList.Count)];

            Console.WriteLine();
            Guid GUIDtoSearch = postToSearch.Id;
            Console.WriteLine("Id to search: " + GUIDtoSearch);
            if (postToSearch != null)
            {
                index = BlogPost.FindPostByID(myBlogPostList, GUIDtoSearch);
                if (index > -1)
                {
                    Console.WriteLine("Result: " + BlogPost.ConvertBlogToJSONstring(myBlogPostList[index], users));
                }
                else
                {
                    Console.WriteLine("THere is no post matching that guid.");
                }
            }
            // Testing BlogPost.FindPostByID using a non-existent guid.
            Console.WriteLine();
            GUIDtoSearch = new Guid("asdjasdf-34fdg-v34-t344t");
            Console.WriteLine("Id to search: " + GUIDtoSearch);
            index = BlogPost.FindPostByID(myBlogPostList,GUIDtoSearch);
            if (index > -1)
            {
                Console.WriteLine("Result: " + BlogPost.ConvertBlogToJSONstring(myBlogPostList[index], users));
            }
            else
            {
                Console.WriteLine("There is no post matching that guid.");
            }
           


            // Testing BlogPost.FindAllWithWord
            string wordToSearch = "if";
            List<BlogPost> result = BlogPost.FindAllWithWord(myBlogPostList,wordToSearch);
            Console.WriteLine();
            Console.WriteLine("Word to search: " + wordToSearch);
            Console.WriteLine("Results: ");
            Console.WriteLine(BlogPost.ConvertBlogListToJSONstring(result, users));

            // Testing BlogPost.FindAllByTitleWordsMoreThan
            int wordLimit = 2;
            result = BlogPost.FindAllByTitleWordsMoreThan(myBlogPostList, wordLimit);
            Console.WriteLine();
            Console.WriteLine("Word limit: " + wordLimit);
            Console.WriteLine("Results: ");
            Console.WriteLine(BlogPost.ConvertBlogListToJSONstring(result, users));

            // Testing BlogPost.FindAllByUsername
            string usernameToSearch = "Mike";
            result = BlogPost.FindAllByUsername(myBlogPostList, users, usernameToSearch);
            Console.WriteLine();
            Console.WriteLine("Userame to search: " + usernameToSearch);
            Console.WriteLine("Results: ");
            Console.WriteLine(BlogPost.ConvertBlogListToJSONstring(result, users));

            // Testing BlogPost.GetAllIDs
            Console.WriteLine("\nAll ids of 'myBlogPostList':");
            List<Guid> IDs= BlogPost.GetAllIDs(myBlogPostList);
            for (int i = 0; i < IDs.Count; i++)
            {
                Console.WriteLine(IDs[i]);
            }

            //
            // How can we create methods for the list object of our own class??
            // 

        }
    }
}
