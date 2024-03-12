namespace Gamer_shop.Api.Dtos;
public record class GameDto(
     int Id,
     string Name,
     string Genre,
     Decimal Price,
     DateTime ReleaseDate,
     string ImageURL
);
