using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MySoccerWorld.Interfaces;
using MySoccerWorld.Model.Entities;
using MySoccerWorld.Models;
using MySoccerWorld.Services;
using MySoccerWorld.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace MySoccerWorld.Controllers
{
    public class ClubsController : Controller
    {
        private readonly ILogger<ClubsController> _logger;
        private readonly IClubService _serv;
        private readonly IDataManager db;
        public ClubsController(ILogger<ClubsController> logger, IClubService serv, IDataManager context)
        {
            _logger = logger;
            _serv = serv;
            db = context;
        }
        public async Task<IActionResult> Index(ClubsSort sortType = ClubsSort.ClubId)
        {
            IQueryable<Club> clubs = db.Clubs.ClubSort();
            ViewData["NameSort"] = sortType == ClubsSort.NameAsc ? ClubsSort.NameDesc : ClubsSort.NameAsc;
            ViewData["CountrySort"] = sortType == ClubsSort.CountryAsc ? ClubsSort.CountryDesc : ClubsSort.CountryAsc;
            clubs = sortType switch
            {
                ClubsSort.CountryAsc => clubs.OrderBy(c => c.Country.Name),
                ClubsSort.CountryDesc => clubs.OrderByDescending(c => c.Country.Name),
                ClubsSort.NameDesc => clubs.OrderByDescending(c => c.Name),
                ClubsSort.NameAsc => clubs.OrderBy(c => c.Name),
                _ => clubs.OrderBy(c => c.Id),
            };
            return View(await clubs.AsNoTracking().ToListAsync());
        }
        public async Task<IActionResult> Details(int id)
        {
            var matches = db.Matches.GetByTeam(id);
            var club = await db.Clubs.Get(id);
            var clubView = new ClubViewModel()
            {
                Team = await db.Clubs.Details(id),
                Matches = matches.ToList(),
                Players = await db.Clubs.Players(id),
                Stats =  _serv.Stats(club, matches.ToList()),
                Ratings =  club.Ratings.OrderBy(t => t.Tournament.LeagueId)
            };
            return View(clubView);
        }
        public IActionResult CreateClub()
        {
            ViewBag.Country = new SelectList(db.Clubs.Countries(), "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult CreateClub([Bind("Name,Country,Flag")] Club club)
        {
            if (ModelState.IsValid)
            {
                db.Clubs.Update(club);
                db.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(club);
        }
    }
}
