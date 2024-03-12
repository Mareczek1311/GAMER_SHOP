using Gamer_shop.Api.Dtos;
using Gamer_shop.Api.Entities;

namespace Gamer_shop.Api.Mapping;
public static class GameMapping
{
    public static Game ToEntity(this CreateGameDto newGame)
    {
        return new Game()
        {
            Name = newGame.Name,
            GenreId = newGame.GenreId,
            Price = newGame.Price,
            ReleaseDate = newGame.ReleaseDate,
            ImageURL = newGame.ImageURL
        };
    }

    public static Game ToEntity(this UpdateGameDto newGame, int id)
    {
        return new Game()
        {
            Id = id,
            Name = newGame.Name,
            GenreId = newGame.GenreId,
            Price = newGame.Price,
            ReleaseDate = newGame.ReleaseDate,
            ImageURL = newGame.ImageURL
        };
    }

    public static GameDto ToGameDto(this Game game)
    {
        return new GameDto(
            game.Id,
            game.Name,
            game.Genre!.Name,
            game.Price,
            game.ReleaseDate,
            game.ImageURL
        );
    }
    public static GameDetailsDto ToGameDetailsDto(this Game game)
    {
        return new GameDetailsDto(
            game.Id,
            game.Name,
            game.GenreId,
            game.Price,
            game.ReleaseDate,
            game.ImageURL
        );
    }


}