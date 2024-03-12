namespace Gamer_shop.Api.Dtos;
public record class GameDetailsDto(
     int Id,
     string Name,
     int GenreId,
     Decimal Price,
     DateTime ReleaseDate,
     string ImageURL
);
