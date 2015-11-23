using Data.Repositories;
using Model;
using System.Linq;

namespace Services.Data.Contracts
{
    public interface IGamesService
    {
        IQueryable<Game> GetGames(int page = 0);

        Game CreateGame(string name);
    }
}
