using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MySoccerWorld.Interfaces;
using MySoccerWorld.Model.Entities;
using MySoccerWorld.Model.Enums;
using MySoccerWorld.Services;
using System.Linq;
using System.Threading.Tasks;

namespace MySoccerWorld.Controllers
{
    public class RatingsController : Controller
    {
        private readonly ILogger<RatingsController> _logger;
        private readonly IDataManager db;
        private readonly IRatingService _serv;
        public RatingsController(ILogger<RatingsController> logger, IDataManager context, IRatingService service)
        {
            _logger = logger;
            db = context;
            _serv = service;
        }
        public async Task<IActionResult> Index()
        {
            var clubs = await db.Clubs.Rating();
            return View(clubs);
        }
        public IActionResult NationalRanking()
        {
            var nationals = db.Nationals.Rating();
            return View(nationals);
        }
        public IActionResult RatingsCreate()
        {
            var tournaments = db.Tournaments.GetAll();
            return View(tournaments);
        }
        public IActionResult CalculateRating(int id)
        {
            var tournament = db.Ratings.TournamentRating(id);
            if (tournament.TournamentType == TournamentType.Regular || tournament.TournamentType == TournamentType.RegularScandinav)
            {
                var ratingView = _serv.TeamRatingsRegular(tournament);
                return View(ratingView);
            }
            else
            {
                var ratingView = _serv.TeamRatingEuroCup(tournament);
                return View(ratingView);
            }
        }
        [HttpPost, ActionName("CalculateRating")]
        public IActionResult CalculateRatingCreate(int id)
        {
            var tournament = db.Ratings.TournamentRating(id);
            if (tournament.TournamentType == TournamentType.Regular || tournament.TournamentType == TournamentType.RegularScandinav)
            {
                var ratingView = _serv.TeamRatingsRegular(tournament);
                if (tournament.Ratings.Count == 0)
                {
                    db.Ratings.AddRange(ratingView);
                    db.Save();
                }
            }
            else
            {
                var ratingView = _serv.TeamRatingEuroCup(tournament);
                if (tournament.Ratings.Count() == 0)
                {
                    db.Ratings.AddRange(ratingView);
                    db.Save();
                }
                else
                {
                    foreach (var r in tournament.Ratings)
                    {
                        var c = db.Ratings.Get(r.Id);
                        c.Points = ratingView.FirstOrDefault(t => t.Team == r.Team).Points;
                        c.Position = ratingView.FirstOrDefault(t => t.Team == r.Team).Position;
                        c.Round = ratingView.FirstOrDefault(t => t.Team == r.Team).Round;
                        db.Ratings.Update(c);
                    }
                    db.Save();
                }
            }
            return RedirectToAction("RatingsCreate");
        }
        public IActionResult TopScorers()
        {
            var players = db.Ratings.TopScorers();
            return View(players);
        }
        public IActionResult SeasonalScorer(int? id)
        {
            Season season;
            if (id != null) { season =  db.Seasons.Get(id); }
            else { season =  db.Seasons.GetAll().OrderBy(s => s.Id).LastOrDefault(); }
            var players = db.Ratings.SeasonalScorers(season.Id);
            ViewBag.Seasons = db.Seasons.GetAll().OrderByDescending(s => s.Data).ToList();
            return View(players);
        }
    }
}
