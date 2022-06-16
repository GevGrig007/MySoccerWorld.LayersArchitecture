using Microsoft.EntityFrameworkCore;
using MySoccerWorld.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccerWorld.EF.Data
{
    public class SoccerContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<PlayerTeam> PlayerTeams { get; set; }
        public DbSet<CoachTeam> CoachTeams { get; set; }
        public DbSet<BestPlayer> BestPlayers { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<Asist> Asists { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<National> Nationals { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<TournamentAward> TournamentAwards { get; set; }
        public DbSet<SeasonalAward> SeasonalAwards { get; set; }
        public SoccerContext(DbContextOptions<SoccerContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MatchConfig());
            modelBuilder.Entity<Player>().HasAlternateKey(x => x.Name);
            modelBuilder.Entity<Team>().HasAlternateKey(x => x.Name);
            modelBuilder.Entity<Coach>().HasAlternateKey(x => x.Name);
            modelBuilder.Entity<Country>().HasAlternateKey(x => x.Name);
        }
    }
}
