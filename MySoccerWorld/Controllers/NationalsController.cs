using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MySoccerWorld.Interfaces;
using MySoccerWorld.Model.Entities;
using MySoccerWorld.Models;
using MySoccerWorld.Services;
using MySoccerWorld.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MySoccerWorld.Controllers
{
    public class NationalsController : Controller
    {
        private readonly ILogger<NationalsController> _logger;
        private readonly IDataManager db;
        private readonly IClubService _serv;
        public NationalsController(ILogger<NationalsController> logger, IDataManager context, IClubService service)
        {
            _logger = logger;
            db = context;
            _serv = service;
        }
        public async Task<IActionResult> Index(ClubsSort sortType = ClubsSort.ClubId)
        {
            IQueryable<National> nationals = db.Nationals.GetAll();
            ViewData["NameSort"] = sortType == ClubsSort.NameAsc ? ClubsSort.NameDesc : ClubsSort.NameAsc;
            ViewData["CountrySort"] = sortType == ClubsSort.CountryAsc ? ClubsSort.CountryDesc : ClubsSort.CountryAsc;
            nationals = sortType switch
            {
                ClubsSort.CountryAsc => nationals.OrderBy(c => c.Region),
                ClubsSort.CountryDesc => nationals.OrderByDescending(c => c.Region),
                ClubsSort.NameDesc => nationals.OrderByDescending(c => c.Name),
                ClubsSort.NameAsc => nationals.OrderBy(c => c.Name),
                _ => nationals.OrderBy(c => c.Id),
            };
            return View(await nationals.ToListAsync());
        }
        public IActionResult Details(int id)
        {
            var national = db.Nationals.Details(id);
            var matches = db.Matches.GetByTeam(id);
            var stats = _serv.Stats(national, matches.ToList());
            var clubView = new NationalViewModel()
            {
                Team = db.Nationals.Details(id),
                Matches = matches.ToList(),
                Players = db.Players.NationalPlayers(id),
                Stats = _serv.Stats(national, matches.ToList()),
                Ratings = national.Ratings.OrderBy(t => t.Tournament.LeagueId)
            };
            return View(clubView);
        }
        public IActionResult CreatePlayer(int id)
        {
            National national = db.Nationals.Get(id);
            ViewBag.Players = db.Players.GetForNational(id);
            return View(national);
        }

        [HttpPost]
        public IActionResult CreatePlayer(National national, int[] selectedPlayers)
        {
            Team newNational = db.Teams.Details(national.Id);
            newNational.Name = national.Name;
            if (selectedPlayers != null)
            {
                foreach (var c in db.Players.GetAll().Where(c => selectedPlayers.Contains(c.Id)))
                {
                    if (c.PlayerTeams.Any(c => c.Team == newNational)) { }
                    else
                    {
                        PlayerTeam playerTeams = new() { PlayerId = c.Id, TeamId = national.Id };
                        db.PlayerTeams.Update(playerTeams);
                    }
                }
            }
            db.Save();
            return RedirectToAction("Details", new { id = newNational.Id });
        }
        public IActionResult CreateNational()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateNational([Bind("Name,Flag,Region")] National national)
        {
            if (ModelState.IsValid)
            {
                db.Nationals.Update(national);
                db.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(national);
        }
        public IActionResult Edit(int id)
        {
            var national = db.Nationals.Get(id);
            return View(national);
        }
        [HttpPost]
        public IActionResult Edit([Bind("Id,Name,Flag,Region")] National national)
        {
            if (ModelState.IsValid)
            {
                db.Nationals.Update(national);
                db.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(national);
        }
        //public IActionResult Delete(int id)
        //{
        //    var national =  db.Nationals.Get(id);
        //    return View(national);
        //}
        //[HttpPost, ActionName("Delete")]
        //public IActionResult DeleteConfirmed(int id)
        //{
        //    db.Nationals.Delete(id);
        //    db.Save();
        //    return RedirectToAction("Index");
        //}
    }
}
