using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MySoccerWorld.Interfaces;
using MySoccerWorld.Model.Entities;
using MySoccerWorld.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MySoccerWorld.Controllers
{
    public class PlayersController : Controller
    {
        private readonly ILogger<PlayersController> _logger;
        private readonly IDataManager db;
        public PlayersController(ILogger<PlayersController> logger, IDataManager context)
        {
            _logger = logger;
            db = context;
        }
        public async Task<IActionResult> Index(PlayersSort sortType = PlayersSort.PlayerId)
        {
            IQueryable<Player> players = db.Players.Sort();
            ViewData["NameSort"] = sortType == PlayersSort.NameAsc ? PlayersSort.NameDesc : PlayersSort.NameAsc;
            players = sortType switch
            {
                PlayersSort.NameAsc => players.OrderBy(p => p.Name),
                PlayersSort.NameDesc => players.OrderByDescending(p => p.Name),
                _ => players.OrderBy(p => p.Id)
            };
            return View(await players.AsNoTracking().ToListAsync());
        }
        public IActionResult Details(int id)
        {
            var player =  db.Players.Details(id);
            return View(player);
        }
        public IActionResult Create()
        {
            ViewData["CountryId"] = new SelectList(db.Clubs.Countries().OrderBy(c => c.Name), "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult Create([Bind("Id,Name,CountryId")] Player player)
        {
            if (ModelState.IsValid)
            {
                db.Players.Update(player);
                db.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(player);
        }
        public IActionResult Edit(int id)
        {
            var player = db.Players.Get(id);
            ViewData["CountryId"] = new SelectList(db.Clubs.Countries().OrderBy(c => c.Name), "Id", "Name", player.CountryId);
            return View(player);
        }
        [HttpPost]
        public IActionResult Edit(int id, [Bind("Id,Name,CountryId")] Player player)
        {
            db.Players.Update(player);
            db.Save();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            var player = db.Players.Get(id);
            return View(player);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            db.Players.Delete(id);
            db.Save();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult PlayerTeams()
        {
            ViewData["PlayerId"] = new SelectList(db.Players.GetAll().OrderBy(p => p.Name), "Id", "Name");
            ViewData["SeasonId"] = new SelectList(db.Seasons.GetAll(), "Id", "Data");
            ViewData["TeamId"] = new SelectList(db.Teams.GetAll(), "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult PlayerTeams([Bind("Id,PlayerId,TeamId,SeasonId")] PlayerTeam playerTeam)
        {
            db.PlayerTeams.Update(playerTeam);
            db.Save();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult AddPlayerTeams(int id)
        {
            var player = db.Players.Get(id);
            ViewData["PlayerId"] = player;
            ViewData["SeasonId"] = new SelectList(db.Seasons.GetAll().OrderByDescending(s => s.Data), "Id", "Data");
            ViewData["TeamId"] = new SelectList(db.Teams.GetAll().OrderBy(s=>s.Id), "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult AddPlayerTeams([Bind("PlayerId,TeamId,SeasonId")] PlayerTeam playerTeam)
        {
            db.PlayerTeams.Update(playerTeam);
            db.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
