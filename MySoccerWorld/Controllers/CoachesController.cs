using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MySoccerWorld.Interfaces;
using MySoccerWorld.Model.Entities;
using MySoccerWorld.Models;
using MySoccerWorld.Services;
using System.Linq;
using System.Threading.Tasks;

namespace MySoccerWorld.Controllers
{
    public class CoachesController : Controller
    {
        private readonly ILogger<CoachesController> _logger;
        private readonly IClubService _serv;
        private readonly IDataManager db;
        public CoachesController(ILogger<CoachesController> logger, IClubService serv, IDataManager context)
        {
            _logger = logger;
            _serv = serv;
            db = context;
        }
        public async Task<IActionResult> Index(PlayersSort sortType = PlayersSort.PlayerId)
        {
            IQueryable<Coach> coaches = db.Coaches.Sort();
            ViewData["NameSort"] = sortType == PlayersSort.NameAsc ? PlayersSort.NameDesc : PlayersSort.NameAsc;
            coaches = sortType switch
            {
                PlayersSort.NameAsc => coaches.OrderBy(p => p.Name),
                PlayersSort.NameDesc => coaches.OrderByDescending(p => p.Name),
                _ => coaches.OrderBy(p => p.Id)
            };
            return View(await coaches.AsNoTracking().ToListAsync());
        }
        public IActionResult Create()
        {
            ViewData["CountryId"] = new SelectList(db.Clubs.Countries().OrderBy(c => c.Name), "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create([Bind("Id,Name,CountryId")] Coach coach)
        {
            if (ModelState.IsValid)
            {
                db.Coaches.Update(coach);
                db.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(coach);
        }
        public IActionResult Edit(int id)
        {
            var coach = db.Coaches.Get(id);
            ViewData["CountryId"] = new SelectList(db.Clubs.Countries().OrderBy(c => c.Name), "Id", "Name", coach.CountryId);
            return View(coach);
        }
        [HttpPost]
        public IActionResult Edit(int id, [Bind("Id,Name,CountryId")] Coach coach)
        {
            db.Coaches.Update(coach);
            db.Save();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            var coach = db.Coaches.Get(id);
            return View(coach);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            db.Coaches.Delete(id);
            db.Save();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult AddCoachTeams(int id)
        {
            var coach = db.Coaches.Get(id);
            ViewData["CoachId"] = coach;
            ViewData["SeasonId"] = new SelectList(db.Seasons.GetAll().OrderByDescending(s => s.Data), "Id", "Data");
            ViewData["TeamId"] = new SelectList(db.Teams.GetAll(), "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult AddCoachTeams([Bind("CoachId,TeamId,SeasonId")] CoachTeam coachTeam)
        {
            db.Coaches.UpdateCoachTeams(coachTeam);
            db.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
