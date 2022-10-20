using API.DarkShame.Domain.Dto.Request.Store.Game;
using API.DarkShame.Domain.Entities;
using API.DarkShame.Domain.Entities.Store.Game;
using API.DarkShame.Domain.Interfaces;
using API.DarkShame.Domain.Interfaces.Store.Game;
using API.DarkShame.Infra.Contexts;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DarkShame.Infra.Repository.Store.Game
{
    public class RepositoryGame : IRepositoryGames
    {
        private readonly IContext _context;

        public RepositoryGame()
        {
            _context = new Context();
        }

        public async Task<List<Games>> GetGames()
        {
            var games = await _context.Games.FindAsync(_ => true);
            return games.ToList();
        }

        public async Task<Games> GetGamesById(string idGame)
        {
            var gameId = await _context.Games.Find(x => x.Id == idGame).FirstOrDefaultAsync();
            return gameId;
        }

        public async Task CreateGame(GamesRequestDto gamesRequestDto)
        {
            await _context.GamesDto.InsertOneAsync(gamesRequestDto);
        }

        public async Task UpdateGame(Games games)
        {
            var analysis = _context.Analysis.FindAsync(_ => true);
            var allAnalysis = analysis.Result.ToList();

            var filter = Builders<Games>.Filter.Eq(x => x.Id, games.Id);
            var update = Builders<Games>.Update.Set(x => x.NameGame, games.NameGame)
                                               .Set(x => x.Price, games.Price)
                                               .Set(x => x.Genres, games.Genres)
                                               .Set(x => x.Summary, games.Summary)
                                               .Set(x => x.Developer, games.Developer)
                                               .Set(x => x.Distributor, games.Distributor)
                                               .Set(x => x.Available, games.Available)
                                               .Set(x => x.PreSale, games.PreSale)
                                               .Set(x => x.Promotion, games.Promotion)
                                               .Set(x => x.Discount, games.Discount)
                                               .Set(x => x.ProfileUrl, games.ProfileUrl)
                                               .Set(x => x.Images, games.Images)
                                               .Set(x => x.AllAnalysis, allAnalysis.Count())
                                               .Set(x => x.Analysis, games.Analysis)
                                               .Set(x => x.Resources, games.Resources)
                                               .Set(x => x.Languages, games.Languages)
                                               .Set(x => x.ParentalRating, games.ParentalRating);

            await _context.Games.UpdateOneAsync(filter, update);
        }

        public async Task DeleteGame(string idGame)
        {
            await _context.Games.DeleteOneAsync(x => x.Id == idGame);
        }
    }
}
