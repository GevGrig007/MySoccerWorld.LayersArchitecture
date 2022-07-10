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
        public async Task<IActionResult> Create(int id)
        {
            var tournament = await db.Tournaments.GetAsync(id);
            ViewBag.Players = new SelectList(db.BestPlayers.GetPlayersByTournament(id), "Id", "Name");
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
                db.BestPlayers.UpdateAsync(bestplayer);
            }
            db.Save();
            return RedirectToAction("Index", "Shedulles", new { id = TournamentId[1] });
        }
        public async Task<IActionResult> Edit(int id)
        {
            var bestPlayer = await db.BestPlayers.GetAsync(id);
            var bestplayers = db.BestPlayers.GetPlayerTeams().OrderBy(p => p.Player.Name);
            ViewData["PlayerTeamId"] = new SelectList(bestplayers.ToList(), "Id", "Player.Name");
            ViewData["TournamentId"] = new SelectList(db.Tournaments.GetAll().ToList(), "Id", "Name");
            return View(bestPlayer);
        }
        [HttpPost]
        public async Task<IActionResult> Edit([Bind("Id,TournamentId,Position,PlayerTeamId")] BestPlayer bestPlayer)
        {
            await db.BestPlayers.UpdateAsync(bestPlayer);
            db.Save();
            return RedirectToAction("Index", "Shedulles", new { id = bestPlayer.TournamentId });
        }

    }
}
