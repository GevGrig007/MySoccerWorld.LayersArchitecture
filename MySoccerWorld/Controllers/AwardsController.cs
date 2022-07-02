using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using MySoccerWorld.Interfaces;
using MySoccerWorld.Model.Entities;
using MySoccerWorld.Model.Enums;
using MySoccerWorld.Services;
using MySoccerWorld.ViewModels;
using System.Linq;
using System.Threading.Tasks;

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
            else { season = db.Seasons.GetAll().OrderBy(s => s.Id).FirstOrDefault(); }
            var awards = db.Awards.GetAwardsBySeason(season.Id);
            ViewBag.Seasons = db.Seasons.GetAll();
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
        public IActionResult Create(int SeasonId, SeasonalAwardType AwardName, int? PlayerId , int? CoachId)
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
                var seasonalAward = new SeasonalAward()
                {
                    AwardName = AwardName,
                    SeasonId = SeasonId,
                    CoachTeamId = db.Awards.GetCoachAward(CoachId).Id
                };
                db.Awards.UpdateSeasonalAward(seasonalAward);
                db.Save();
            }
            return RedirectToAction("Index", new { id = SeasonId });
        }
        public IActionResult Medals()
        {
            var clubs = db.Ratings.ClubMedals();
            var nationals = db.Ratings.NationalMedals();
            var countries = db.Ratings.CountriesMedal();
            var view = new MedalsViewModel()
            {
                Clubs = clubs,
                Nationals = nationals,
                Countries = countries
            };
            return View(view);
        }
    }
}
