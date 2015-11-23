using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data;
using Data.Repositories;
using Model;
using Services.Data;
using Services.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Web.Models;

namespace Web.Controllers
{
    public class GamesController : ApiController
    {
        private IGamesService games;

        public GamesController(IGamesService games)
        {
            this.games = games;
        }

        [HttpGet]
        public IHttpActionResult Get(int page=1)
        {
            var games = this.games.GetGames();

            return Ok(this.games.GetGames().ProjectTo<ListedGameModel>().ToList());
        }

        [Authorize]
        public IHttpActionResult Post(CreateGameRequestModel model)
        {
            var newGame = this.games.CreateGame(model.Name);

            return this.Ok(newGame.Id);
        }

        //[HttpPost]
        //[Route("api/games/{id}/guess")]
        //public IHttpActionResult Guess(int id, BaseGameRequestModel model)
        //{
        //    var userId = this.User.Identity.GetUserId();
        //    if (!this.games.CanMakeGuess(id, userId))
        //    {
        //        return this.BadRequest("Either you are not part of the game or it is not your turn!");
        //    }

        //    var newGuess = this.guesses.MakeGuess(id, model.Number, userId);

        //    var guessResult = this.guesses
        //        .GetGuessDetails(newGuess.Id)
        //        .ProjectTo<GuessDetailsResponseModel>()
        //        .FirstOrDefault();

        //    return this.Ok(guessResult);
        //}
    }
}