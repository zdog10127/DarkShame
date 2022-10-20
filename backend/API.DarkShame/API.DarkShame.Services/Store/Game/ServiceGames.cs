using API.DarkShame.Domain.Dto.Request.Store.Game;
using API.DarkShame.Domain.Dto.Request.Users;
using API.DarkShame.Domain.Dto.Response;
using API.DarkShame.Domain.Entities.Store.Game;
using API.DarkShame.Domain.Interfaces.Store.Game;
using API.DarkShame.Infra.Repository.Store.Game;

namespace API.DarkShame.Services.Store.Game
{
    public class ServiceGames : IServiceGames
    {
        private readonly IRepositoryGames _repositoryGames;

        public ServiceGames()
        {
            _repositoryGames = new RepositoryGame();
        }

        public async Task<List<Games>> GetGames()
        {
            var games = await _repositoryGames.GetGames();
            return games;
        }

        public async Task<Games> GetGamesById(string idGame)
        {
            var gameId = await _repositoryGames.GetGamesById(idGame);
            return gameId;
        }

        public async Task<ReturnDto> CreateGame(GamesRequestDto gamesRequestDto)
        {
            ReturnDto returnDto = new ReturnDto();

            var ret = _repositoryGames.CreateGame(gamesRequestDto);

            if (ret.Exception != null)
            {
                returnDto.ThereError = true;
                returnDto.CodeError = "400";
                returnDto.TitleError = "Gravar o Jogo";
                returnDto.MessageError = "Erro no processo de gravar o Jogo";
            }

            return await Task.FromResult(returnDto);
        }

        public async Task<ReturnDto> UpdateGame(Games games)
        {
            ReturnDto returnDto = new ReturnDto();

            var ret = _repositoryGames.UpdateGame(games);

            if (ret.Exception != null)
            {
                returnDto.ThereError = true;
                returnDto.CodeError = "400";
                returnDto.TitleError = "Atualizar o Jogo";
                returnDto.MessageError = "Erro no processo de atualizar o Jogo";
            }

            return await Task.FromResult(returnDto);
        }

        public async Task<ReturnDto> DeleteGame(string idGame)
        {
            ReturnDto returnDto = new ReturnDto();

            var ret = _repositoryGames.DeleteGame(idGame);

            if (ret.Exception != null)
            {
                returnDto.ThereError = true;
                returnDto.CodeError = "400";
                returnDto.TitleError = "Deletar o Jogo";
                returnDto.MessageError = "Erro no processo de deletar o Jogo";
            }

            return await Task.FromResult(returnDto);
        }
    }
}
