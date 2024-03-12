using System.ComponentModel.DataAnnotations;

namespace Gamer_shop.Api.Dtos;

public record class CreateGameDto(
    [Required][StringLength(50)] string Name,
    int GenreId,
    [Range(1,100)] decimal Price,
    DateTime ReleaseDate,
    string ImageURL
);