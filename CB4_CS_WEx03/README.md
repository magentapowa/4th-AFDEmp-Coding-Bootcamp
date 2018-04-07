Coding Bootcamp 4
Exercise 3 – C# Stream
You are developing a blogging application and you want to build a class that has a method
that takes a list of the type List<BlogPost> as input and returns that list in JSON format (string).
First make the following decisions:
1. Will your converter class / method will be a static class / method?
2. Will you use normal strings or a StringBuilder to build the JSON string?
Then, develop the class and the appropriate method.
To test the functionality, initialize a list of sample blog posts, implement the following queries
(in C#), convert the result of each query to JSON and print it to the screen.
1. Find the blog post with a given id.
2. Find all posts that contain a specific word in their bodies.
3. Find all posts that have a title with more than two words.
4. Find all posts written from a specific user.
5. Return a list of all the post ids.
Resources:
 https://www.w3schools.com/js/js_json_intro.asp (JSON)
 https://www.lipsum.com/ (Sample text generator)
 https://www.guidgenerator.com/ (Online GUID generator)

// Sample output
{
"id": "b58f9d4e-f559-4f20-8a1e-c236e1f2ebc9",
"user": {
"id": "f4f2e0cd-c15e-4823-8434-3bf7afa05af2",
"username": "mnikolaidis"
},
"title": "Lorem ipsum.",
"body": "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed aliquet dictum
facilisis. Nullam et ligula tincidunt justo dictum consequat at vel justo. Vestibulum
blandit dapibus maximus. Curabitur tristique elit id facilisis ullamcorper. Ut erat risus,
laoreet vel nisi non, lacinia maximus ante. Aenean velit tortor, varius pretium varius
vitae, feugiat ac odio. Proin ut consequat neque."
}