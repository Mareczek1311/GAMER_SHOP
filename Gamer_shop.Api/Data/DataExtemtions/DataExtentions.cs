using Microsoft.EntityFrameworkCore;

namespace Gamer_shop.Api.Data;
public static class DataExtentions
{
    public static async Task MigrateDbAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<GameStoreContext>();
        await context.Database.MigrateAsync();
    }
}