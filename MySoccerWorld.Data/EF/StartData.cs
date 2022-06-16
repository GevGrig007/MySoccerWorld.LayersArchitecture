using MySoccerWorld.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccerWorld.EF.Data
{
    public class StartData
    {
        public static void Initialize(SoccerContext context)
        {
            if (!context.Leagues.Any())
            {
                context.Leagues.AddRange(
                    new League { Name = "GB Premier League", Region = "GreatBritain", Type = "Regional", Logo = "/images/LeaguesLogo/Gb.png" },
                    new League { Name = "Championat SNG", Region = "SNG", Type = "Regional", Logo = "/images/LeaguesLogo/Sng.png" },
                    new League { Name = "SuperLiga Alpys", Region = "Alpys", Type = "Regional", Logo = "/images/LeaguesLogo/Alpys.png" },
                    new League { Name = "Balkans Superliga", Region = "Balkans", Type = "Regional", Logo = "/images/LeaguesLogo/Balkans.png" },
                    new League { Name = "Seria A", Region = "Italy", Type = "Regional", Logo = "/images/LeaguesLogo/SeriaA.png" },
                    new League { Name = "La Liga Pyreneeys", Region = "Pyreneeys", Type = "Regional", Logo = "/images/LeaguesLogo/Pireneys.png" },
                    new League { Name = "Ligue 1", Region = "France", Type = "Regional", Logo = "/images/LeaguesLogo/Ligue12.png" },
                    new League { Name = "BeNeLux", Region = "Benelux", Type = "Regional", Logo = "/images/LeaguesLogo/Benelux.png" },
                    new League { Name = "Scandinavs Serien", Region = "Scandinavs", Type = "Regional", Logo = "/images/LeaguesLogo/Scandinav.png" },
                    new League { Name = "CentralLiga", Region = "CentralEurope", Type = "Regional", Logo = "/images/LeaguesLogo/Central.png" },
                    new League { Name = "League Champions", Type = "EuroCup", Logo = "/images/LeaguesLogo/Lch.png" },
                    new League { Name = "EuroLeague", Type = "EuroCup", Logo = "/images/LeaguesLogo/euroliga.png" },
                    new League { Name = "Conferentions Cup", Type = "EuroCup", Logo = "/images/LeaguesLogo/conferention.png" },
                    new League { Name = "Cup of Cups", Type = "EuroCup", Logo = "/images/LeaguesLogo/cupcups.jpg" },
                    new League { Name = "SuperCup PES", Type = "EuroCup", Logo = "/images/LeaguesLogo/supercup.jpg" },
                    new League { Name = "World Cup", Type = "National", Logo = "/images/LeaguesLogo/worldcup.png" },
                    new League { Name = "UEFA EURO CUP", Type = "National", Logo = "/images/LeaguesLogo/eurocup.png" },
                    new League { Name = "Cup of AFRICAN Nations", Type = "National", Logo = "/images/LeaguesLogo/africacup.png" },
                    new League { Name = "Copa de AMERICA", Type = "National", Logo = "/images/LeaguesLogo/copaamerica.png" }
                );
                context.SaveChanges();
            }
        }
    }
}
