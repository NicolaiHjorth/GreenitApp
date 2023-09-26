namespace Domain.DTOs;

public class PostBasicDto
{
    public int Id { get; }
    public string OwnerName { get; }
    public string Title { get; }
    public string Content { get; }

    public PostBasicDto(int id, string ownerName, string title, string content)
    {
        Id = id;
        OwnerName = ownerName;
        Title = title;
        Content = content;
    }
}