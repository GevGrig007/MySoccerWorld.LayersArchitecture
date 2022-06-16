using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MySoccerWorld.Interfaces;
using MySoccerWorld.Model;
using MySoccerWorld.Model.Entities;
using MySoccerWorld.Services;
using MySoccerWorld.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace MySoccerWorld.Controllers
{
    public class LeaguesController : Controller
    {
        private readonly ILogger<LeaguesController> _logger;
        private readonly ILeagueService _serv;
        private readonly IDataManager db;
        public LeaguesController(ILogger<LeaguesController> logger, ILeagueService service, IDataManager context)
        {
            _logger = logger;
            _serv = service;
            db = context;
        }
        public IActionResult Index()
        {
            var leagues = db.Leagues.GetAll();
            return View(leagues);
        }
        [HttpPost]
        public IActionResult Create(League league)
        {
            db.Leagues.Update(league);
            db.Save();
            return RedirectToAction("Index", "Leagues");
        }
        public IActionResult Edit(int id)
        {
            var league = db.Leagues.Get(id);
            return PartialView(league);
        }
        [HttpPost]
        public IActionResult Edit(League league)
        {
            db.Leagues.Update(league);
            db.Save();
            return RedirectToAction("Index", "Leagues");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var league = db.Leagues.Get(id);
            return PartialView(league);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(League league)
        {
            db.Leagues.Delete(league.Id);
            db.Save();
            return RedirectToAction("Index", "Leagues");
        }
        [HttpPost]
        public IActionResult CreateSeason(double dataseason)
        {
            Season season = new()
            {
                Data = dataseason
            };
            db.Seasons.Update(season);
            db.Save();
            return View();
        }
        public IActionResult Details(int id)
        {
            var matches = db.Leagues.Matches(id);
            var leagueView = new LeagueViewModel()
            {
                League = db.Leagues.Details(id),
                Tournaments = db.Leagues.Tournaments(id),
                Goals = db.Leagues.GoalScorers(id),
                Asists = db.Leagues.Asisters(id),
                Ratings = db.Leagues.Ratings(id),
                Matches = matches
            };
            if (matches.Count > 0) { var leagueStat = _serv.Stats(matches); leagueView.Stats = leagueStat; }
            return View(leagueView);
        }
    }
}
