namespace Domain.Models;

public class Post
{
    public int Id { get; set; }
    public User Owner { get; set; }
    public int OwnerId { get; set; }
    public string Title { get; private set; }
    
    public string Content { get; private set; }
    public String TimeStamp { get; private set; }

    public Post(int ownerId, string title, string content, string timeStamp)
    {
        OwnerId = ownerId;
        Title = title;
        Content = content;
        TimeStamp = timeStamp;
    }

    private Post() { }
}