namespace Domain.DTOs;

public class SearchPostParametersDto
{
    public string? Username { get; }
    public int? UserId { get; }
    public string? TitleContains { get; }
    public string? ContentContains { get; }

    public SearchPostParametersDto(string? username, int? userId, string? titleContains, string? contentContains)
    {
        Username = username;
        UserId = userId;
        TitleContains = titleContains;
        ContentContains = contentContains;
    }
}