using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MySoccerWorld.Interfaces;
using MySoccerWorld.Model.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace MySoccerWorld.Controllers
{
    public class BestPlayersController : Controller
    {
        private readonly ILogger<BestPlayersController> _logger;
        private readonly IDataManager db;
        public BestPlayersController(ILogger<BestPlayersController> logger, IDataManager context)
        {
            _logger = logger;
            db = context;
        }
        public IActionResult Create(int id)
        {
            var tournament = db.Tournaments.Get(id);
            ViewBag.Players = new SelectList(db.BestPlayers.GetPlayers(), "Id", "Name");
            ViewData["TournamentId"] = tournament.Id;
            return View();
        }
        [HttpPost]
        public IActionResult Create(int[] TournamentId, int[] Position, int[] PlayerTeamId)
        {
            for (int i = 0; i < TournamentId.Length; i++)
            {
                var player = db.BestPlayers.GetClubsPlayer(PlayerTeamId[i]);
                var playerTeam = player.PlayerTeams.Where(p => p.Season != null).LastOrDefault();
                var bestplayer = new BestPlayer()
                {
                    TournamentId = TournamentId[i],
                    PlayerTeamId = playerTeam.Id,
                    Position = Position[i]
                };
                db.BestPlayers.Update(bestplayer);
            }
            db.Save();
            return RedirectToAction("Index", "Shedulles", new { id = TournamentId[1] });
        }
        public IActionResult Edit(int id)
        {
            var bestPlayer = db.BestPlayers.GetAsync(id);
            ViewData["PlayerTeamId"] = new SelectList(db.BestPlayers.GetPlayers(), "Id", "Player.Name");
            ViewData["TournamentId"] = new SelectList(db.Tournaments.GetAll(), "Id", "Name");
            return View(bestPlayer);
        }
        [HttpPost]
        public IActionResult Edit([Bind("Id,TournamentId,Position,PlayerTeamId")] BestPlayer bestPlayer)
        {
            db.BestPlayers.Update(bestPlayer);
            db.Save();
            return RedirectToAction("Index", "Shedulles", new { id = bestPlayer.TournamentId });
        }

    }
}
