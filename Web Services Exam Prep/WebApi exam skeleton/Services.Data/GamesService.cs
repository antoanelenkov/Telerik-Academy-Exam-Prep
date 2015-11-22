using Services.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Data.Repositories;

namespace Services.Data
{
    public class GamesService : IGamesService
    {
        private IRepository<Game> games;

        public GamesService(IRepository<Game> games)
        {
            this.games = games;
        }

        public IQueryable<Game> GetGames(int page = 0)
        {
            throw new NotImplementedException();
        }
    }
}
