using Gamer_shop.Api.Data;
using Gamer_shop.Api.Dtos;
using Gamer_shop.Api.Entities;
using Gamer_shop.Api.Mapping;
using Microsoft.EntityFrameworkCore;
namespace Gamer_shop.Api.Endpoints;

public static class GamesEndpoints
{
    const string GetNameByIdEndpoint = "GetGameById";

    public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/games").WithParameterValidation();

        group.MapGet("/{id}", async (int id, GameStoreContext dbContext) =>
        {

            Game? game = await dbContext.Games.FindAsync(id);

            if (game is null)
            {
                return Results.NotFound();
            }

            return Results.Ok(game.ToGameDetailsDto());

        }).WithName(GetNameByIdEndpoint);

        group.MapGet("/", async (GameStoreContext dbContext) => 
            await dbContext.Games
            .Include(game => game.Genre)
            .Select(game => game.ToGameDto())
            .AsNoTracking()
            .ToListAsync());

        group.MapPost("/", async (CreateGameDto newGame, GameStoreContext dbContext) =>
        {

            var game = newGame.ToEntity();
            
            dbContext.Games.Add(game);
            await dbContext.SaveChangesAsync();

            var gameDto = game.ToGameDetailsDto();

            return Results.CreatedAtRoute(GetNameByIdEndpoint, new { id = game.Id }, gameDto);
        });


        // PUT /games
        group.MapPut("/{id}", async (int id, UpdateGameDto updatedGame, GameStoreContext dbContext) =>
        {
            var game = await dbContext.Games.FindAsync(id);

            if (game is null)
            {
                return Results.NotFound();
            }
            
            dbContext.Entry(game).CurrentValues.SetValues(updatedGame.ToEntity(id));
            await dbContext.SaveChangesAsync();

            return Results.NoContent();
        });

        group.MapDelete("/{id}", async (int id, GameStoreContext dbContext) =>
        {
            await dbContext.Games.Where(game => game.Id == id)
                .ExecuteDeleteAsync();

            return Results.NoContent();
        });

        return group;
    }
}