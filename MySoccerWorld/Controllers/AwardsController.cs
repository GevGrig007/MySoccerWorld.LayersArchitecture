using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using MySoccerWorld.Interfaces;
using MySoccerWorld.Model.Entities;
using MySoccerWorld.Model.Enums;
using MySoccerWorld.Services;
using System.Linq;

namespace MySoccerWorld.Controllers
{
    public class AwardsController : Controller
    {
        private readonly ILogger<AwardsController> _logger;
        private readonly IDataManager db;
        private readonly ITournamentService _serv;
        public AwardsController(ILogger<AwardsController> logger, IDataManager context, ITournamentService service)
        {
            _logger = logger;
            db = context;
            _serv = service;
        }
        public IActionResult Index(int? id)
        {
            Season season;
            if (id != null) { season = db.Seasons.Get(id); }
            else { season = db.Seasons.GetAll().OrderBy(s => s.Id).LastOrDefault(); }
            var awards = db.Awards.GetAwardsBySeason(season.Id);
            return View(awards);
        }
        public IActionResult Create()
        {
            ViewBag.Players = new SelectList(db.Players.GetAll().OrderBy(p => p.Name), "Id", "Name");
            ViewBag.Seasons = new SelectList(db.Seasons.GetAll().OrderBy(p => p.Id), "Id", "Data");
            return View();
        }
        public IActionResult CreateCoach()
        {
            ViewBag.Coaches = new SelectList(db.Coaches.GetAll().OrderBy(p => p.Name), "Id", "Name");
            ViewBag.Seasons = new SelectList(db.Seasons.GetAll().OrderBy(p => p.Id), "Id", "Data");
            return View();
        }
        public IActionResult CreateStarting()
        {
            ViewBag.Players = new SelectList(db.Players.GetAll().OrderBy(p => p.Name), "Id", "Name");
            ViewBag.Coaches = new SelectList(db.Coaches.GetAll().OrderBy(p => p.Name), "Id", "Name");
            ViewBag.Seasons = new SelectList(db.Seasons.GetAll().OrderBy(p => p.Id), "Id", "Data");
            return View();
        }
        [HttpPost]
        public IActionResult Create(int SeasonId, AwardType AwardName, int? PlayerId , int? CoachId)
        {
            if (PlayerId != null)
            {
                var seasonalAward = new SeasonalAward()
                {
                    AwardName = AwardName,
                    SeasonId = SeasonId,
                    PlayerTeamId = db.Awards.GetPlayerAward(PlayerId).Id
                };
                db.Awards.UpdateSeasonalAward(seasonalAward);
                db.Save();
            }
            if (CoachId != null)
            {
                var coach = db.Coaches.Get(CoachId);
                var seasonalAward = new SeasonalAward()
                {
                    AwardName = AwardName,
                    SeasonId = SeasonId,
                    CoachId = coach.Id
                };
                db.Awards.UpdateSeasonalAward(seasonalAward);
                db.Save();
            }
            return RedirectToAction("Index", new { id = SeasonId });
        }
    }
}
