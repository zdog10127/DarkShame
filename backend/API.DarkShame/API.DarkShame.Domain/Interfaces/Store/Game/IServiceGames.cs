using API.DarkShame.Domain.Dto.Request.Store.Game;
using API.DarkShame.Domain.Dto.Response;
using API.DarkShame.Domain.Entities.Store.Game;

namespace API.DarkShame.Domain.Interfaces.Store.Game
{
    public interface IServiceGames
    {
        Task<List<Games>> GetGames();
        Task<Games> GetGamesById(string idGame);
        Task<ReturnDto> CreateGame(GamesRequestDto gamesRequestDto);
        Task<ReturnDto> UpdateGame(Games games);
        Task<ReturnDto> DeleteGame(string idGame);
    }
}
