using MySoccerWorld.Model.Entities;
using System.Collections.Generic;

namespace MySoccerWorld.ViewModels
{
    public class MedalsViewModel
    {
        public List<Club> Clubs { get; set; }
        public List<National> Nationals { get; set; }
        public List<Country> Countries { get; set; }
    }
}
