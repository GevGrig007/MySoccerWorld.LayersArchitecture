using MySoccerWorld.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccerWorld.Services
{
    public interface IRatingService
    {
        List<Rating> TeamRatingsRegular(Tournament tournament);
        List<Rating> TeamRatingEuroCup(Tournament tournament);
    }
}
