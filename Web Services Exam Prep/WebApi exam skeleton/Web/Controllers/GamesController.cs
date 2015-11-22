using Services.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Web.Controllers
{
    public class GamesController : ApiController
    {
        private IGamesService games;

        public GamesController(IGamesService games)
        {
            this.games = games;
        }

        public IHttpActionResult Get(int page=1)
        {
            return null;
        }
    }
}