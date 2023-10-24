using Domain.DTOs;
using Domain.Models;
using HttpClients.Implementations;

namespace HttpClients.ClientInterfaces;

public interface IPostService
{
    Task CreateAsync(PostCreationDto dto);

    Task<ICollection<Post>> GetAsync(
        string? username,
        string? titleContains,
        string? contentContains
        );
    
    Task<PostBasicDto> GetByIdAsync(int id);
    
    Task UpdateAsync(PostUpdateDto dto);
}