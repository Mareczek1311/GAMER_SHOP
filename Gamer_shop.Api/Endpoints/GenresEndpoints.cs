
using Gamer_shop.Api.Data;
using Gamer_shop.Api.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Gamer_shop.Api.Endpoints;
public static class GenresEndpoints
{
    public static RouteGroupBuilder MapGenresEndpoints(this WebApplication app){
        var group = app.MapGroup("/genres").WithParameterValidation();

        group.MapGet("/", async (GameStoreContext dbContext) => 
            await dbContext.Genres
            .Select(genre => genre.ToGenreDto())
            .AsNoTracking()
            .ToListAsync());

        return group;
    }
}