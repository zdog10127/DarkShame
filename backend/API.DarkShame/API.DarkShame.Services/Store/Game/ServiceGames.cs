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
        private readonly IRepositoryAnalysis _repositoryAnalysis;
        private readonly IRepositoryLanguage _repositoryLanguage;
        private readonly IRepositoryResources _repositoryResources;
        private readonly IRepositorySpecifications _repositorySpecifications;

        public ServiceGames()
        {
            _repositoryGames = new RepositoryGame();
            _repositoryAnalysis = new RepositoryAnalysis();
            _repositoryLanguage = new RepositoryLanguage();
            _repositoryResources = new RepositoryResources();
            _repositorySpecifications = new RepositorySpecifications();
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

            returnDto = await UpdateGameAndItens(games);

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


        private async Task<ReturnDto> UpdateGameAndItens(Games games)
        {
            ReturnDto returnDto = new ReturnDto();

            try
            {
                var retGames = _repositoryGames.UpdateGame(games);

                if (retGames.Exception != null)
                {
                    returnDto.ThereError = true;
                    returnDto.CodeError = "500";
                    returnDto.TitleError = "Atualização do Jogo";
                    returnDto.MessageError = "Erro no processo de atualização dos dados";
                }

                if (games.Analysis != null)
                {
                    foreach (var item in games.Analysis)
                    {
                        var validate = new ServiceAnalysis();
                        returnDto = await validate.CreateAnalysis(item);
                        
                        if (returnDto.ThereError == true)
                        {
                            return await Task.FromResult(returnDto);
                        }
                    }
                }

                if (games.Languages != null)
                {
                    foreach (var item in games.Languages)
                    {
                        var validate = new ServiceLanguage();
                        returnDto = await validate.CreateLanguages(item);

                        if (returnDto.ThereError == true)
                        {
                            return await Task.FromResult(returnDto);
                        }
                    }
                }

                if (games.Resources != null)
                {
                    var validate = new ServiceResources();
                    returnDto = await validate.CreateResources(games.Resources);

                    if (returnDto.ThereError == true)
                    {
                        return await Task.FromResult(returnDto);
                    }
                }

                if (games.SpecificationsMinimum != null)
                {
                    var validate = new ServiceSpecifications();
                    returnDto = await validate.CreateSpecificationsMinimum(games.SpecificationsMinimum);

                    if (returnDto.ThereError == true)
                    {
                        return await Task.FromResult(returnDto);
                    }
                }

                if (games.SpecificationsMaximum != null)
                {
                    var validate = new ServiceSpecifications();
                    returnDto = await validate.CreateSpecificationsMaximum(games.SpecificationsMaximum);

                    if (returnDto.ThereError == true)
                    {
                        return await Task.FromResult(returnDto);
                    }
                }

                return await Task.FromResult(returnDto);
            }
            catch (Exception ex)
            {
                returnDto.ThereError = true;
                returnDto.CodeError = "500";
                returnDto.TitleError = "Exception - Games";
                returnDto.MessageError = $"{ex.Message}{Environment.NewLine}{ex.StackTrace}";
                return returnDto;
            }
        }
    }
}
