using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MySoccerWorld.Interfaces;
using MySoccerWorld.Model.Entities;
using MySoccerWorld.Model.Enums;
using MySoccerWorld.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace MySoccerWorld.Controllers
{
    public class MatchesController : Controller
    {
        private readonly ILogger<LeaguesController> _logger;
        private readonly IDataManager db;
        public MatchesController (ILogger<LeaguesController> logger, IDataManager context)
        {
            _logger = logger;
            db = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Edit(int id)
        {
            var match = db.Matches.Get(id);
            ViewData["AwayTeam"] = new SelectList(db.Teams.GetAll(), "Id", "Name");
            ViewData["HomeTeam"] = new SelectList(db.Teams.GetAll(), "Id", "Name");
            ViewData["TournamentId"] = new SelectList(db.Tournaments.GetAll(), "Id", "Name");
            return View(match);
        }
        [HttpPost]
        public IActionResult Edit([Bind("Id,Round,Group,Neytral,Data,HomeTeam,AwayTeam,HomeScore,AwayScore,HomeEx,AwayEx,HomePen,AwayPen,TournamentId")] Match match)
        {
            db.Matches.Update(match);
            db.Save();
            return RedirectToAction("Matches", "Tournaments", new { id = match.TournamentId });
        }
        public IActionResult Delete(int id)
        {
            var match = db.Matches.Details(id);
            return View(match);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var match = db.Matches.Get(id);
            db.Matches.Delete(match.Id);
            db.Save();
            return RedirectToAction("Matches", "Tournaments", new { id = match.TournamentId });
        }
        public IActionResult EditScore(int id)
        {
            var match = db.Matches.Details(id);
            if (match.Tournament.League.Type == "National")
            {
                var matchView = new MatchViewModel()
                {
                    Match = match,
                    HomePlayers = db.Players.NationalPlayers(match.HomeTeam),
                    AwayPlayers = db.Players.NationalPlayers(match.AwayTeam)
                };
                return View(matchView);
            }
            else
            {
                var matchView = new MatchViewModel()
                {
                    Match = match,
                    HomePlayers = db.Players.ClubPlayers(match.HomeTeam),
                    AwayPlayers = db.Players.ClubPlayers(match.AwayTeam)
                };
                return View(matchView);
            }
        }
        [HttpPost]
        public IActionResult EditScore(Match match)
        {
            db.Matches.Update(match);
            db.Save();
            return RedirectToAction("Details", "Tournaments", new { id = match.TournamentId });
        }
        public IActionResult ExtraScore(int id)
        {
            var match = db.Matches.Details(id);
            return View(match);
        }
        [HttpPost]
        public IActionResult ExtraScore(Match match)
        {
            db.Matches.Update(match);
            db.Save();
            return RedirectToAction("Details", "Tournaments", new { id = match.TournamentId });
        }
        [HttpPost]
        public async Task<IActionResult> GoalsAdd([Bind("MatchId,PlayerTeamId")] Goal goal)
        {
            await db.Matches.AddGoalAsync(goal);
            db.Save();
            return RedirectToAction("EditScore", "Matches", new { id = goal.MatchId });
        }
        [HttpPost]
        public IActionResult AsistAdd([Bind("MatchId,PlayerTeamId")] Asist asist)
        {
            db.Matches.AddAsist(asist);
            db.Save();
            return RedirectToAction("EditScore", "Matches", new { id = asist.MatchId });
        }
    }
}
