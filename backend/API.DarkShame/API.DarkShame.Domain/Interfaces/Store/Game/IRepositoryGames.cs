using API.DarkShame.Domain.Dto.Request.Store.Game;
using API.DarkShame.Domain.Entities.Store.Game;

namespace API.DarkShame.Domain.Interfaces.Store.Game
{
    public interface IRepositoryGames
    {
        Task<List<Games>> GetGames();
        Task<Games> GetGamesById(string idGame);
        Task CreateGame(GamesRequestDto gamesRequestDto);
        Task UpdateGame(Games games);
        Task DeleteGame(string idGame);
    }
}
