using MySoccerWorld.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccerWorld.Services
{
    public interface IShedulleService
    {
        ICollection<Match> GenerateFor9Teams(Tournament turnir, List<Team> klubi, double startData);
        ICollection<Match> GenerateFor16Teams(Tournament turnir, List<Team> klubi, double startData);
        ICollection<Match> GenerateFor12Teams(Tournament turnir, List<Team> klubi, double startData);
        ICollection<Match> Shedulle32(Tournament turnir, List<Team> klubi, double startData);
        ICollection<Match> Shedulle16(Tournament turnir, List<Team> klubi, double startData);
        ICollection<Match> Shedulle8(Tournament turnir, List<Team> klubi, double startData);
        ICollection<Match> ShedulleEuro8(Tournament turnir, List<Team> klubi, double startData);
        ICollection<Match> QuartersDouble(Tournament turnir, List<Team> klubi, double startData);
        ICollection<Match> Quarters(Tournament turnir, List<Team> klubi, double startData);
        ICollection<Match> SemiDouble(Tournament turnir, List<Team> klubi, double startData);
        ICollection<Match> Final(Tournament turnir, List<Team> klubi, double startData);
        ICollection<Match> Semi(Tournament turnir, List<Team> klubi, double startData);
        ICollection<Match> Qualification(Tournament turnir, List<Team> klubi, string round, double startData, bool neytral);
        ICollection<Match> QualificationDouble(Tournament turnir, List<Team> klubi, string round, double startData, bool neytral);
        List<Match> GroupShedulle(Tournament turnir, List<Team> klubi, double startData, string Name);
        List<Match> EuroGroupShedulle(Tournament turnir, List<Team> klubi, double startData, string Name);
    }
}
