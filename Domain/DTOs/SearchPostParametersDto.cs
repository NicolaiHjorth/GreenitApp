namespace Domain.DTOs;

public class SearchPostParametersDto
{
    public string? Username { get; }
    public int? UserId { get; }
    public string? Content { get; }
    public string? TitleContains { get; }

    public SearchPostParametersDto(string? username, int? userId, string? content, string? titleContains)
    {
        Username = username;
        UserId = userId;
        Content = content;
        TitleContains = titleContains;
    }
}