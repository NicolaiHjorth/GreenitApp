namespace Domain.DTOs;

public class PostCreationDto
{
    public int OwnerId { get; }
    public string Title { get; }
    
    public string Content { get; }
    
    public string TimeStamp { get; }
    

    public PostCreationDto(int ownerId, string title, string content, string timeStamp)
    {
        OwnerId = ownerId;
        Title = title;
        Content = content;
        TimeStamp = timeStamp;
    }

}