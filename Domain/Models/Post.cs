namespace Domain.Models;

public class Post
{
    public int Id { get; set; }
    public User Owner { get; }
    public string Title { get; }
    
    public string Content { get; }

    public Post(User owner, string title, string content)
    {
        Owner = owner;
        Title = title;
        Content = content;
    }
}