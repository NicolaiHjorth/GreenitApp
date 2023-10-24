namespace Domain.Models;

public class Post
{
    public int Id { get; set; }
    public User Owner { get; }
    public string Title { get; }
    
    public string Content { get; }
    public String TimeStamp { get; }

    public Post(User owner, string title, string content, string timeStamp)
    {
        Owner = owner;
        Title = title;
        Content = content;
        TimeStamp = timeStamp;
    }
}