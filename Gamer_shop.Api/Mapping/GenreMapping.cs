using Gamer_shop.Api.Dtos;
using Gamer_shop.Api.Entities;

namespace Gamer_shop.Api.Mapping;
public static class GenreMapping
{
    public static GenreDto ToGenreDto(this Genre genre)
    {
        return new GenreDto(genre.Id, genre.Name);
    }
}