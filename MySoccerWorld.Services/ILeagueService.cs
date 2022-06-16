using MySoccerWorld.Model;
using MySoccerWorld.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccerWorld.Services
{
    public interface ILeagueService
    {
        LeagueStats Stats(List<Match> matches);
    }
}
