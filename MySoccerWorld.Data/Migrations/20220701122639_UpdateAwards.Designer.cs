﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MySoccerWorld.EF.Data;

namespace MySoccerWorld.Data.Migrations
{
    [DbContext(typeof(SoccerContext))]
    [Migration("20220701122639_UpdateAwards")]
    partial class UpdateAwards
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MySoccerWorld.Model.Entities.Asist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MatchId")
                        .HasColumnType("int");

                    b.Property<int>("PlayerTeamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MatchId");

                    b.HasIndex("PlayerTeamId");

                    b.ToTable("Asists");
                });

            modelBuilder.Entity("MySoccerWorld.Model.Entities.BestPlayer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PlayerTeamId")
                        .HasColumnType("int");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<int>("TournamentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlayerTeamId");

                    b.HasIndex("TournamentId");

                    b.ToTable("BestPlayers");
                });

            modelBuilder.Entity("MySoccerWorld.Model.Entities.Coach", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasAlternateKey("Name");

                    b.HasIndex("CountryId");

                    b.ToTable("Coaches");
                });

            modelBuilder.Entity("MySoccerWorld.Model.Entities.CoachTeam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CoachId")
                        .HasColumnType("int");

                    b.Property<int?>("SeasonId")
                        .HasColumnType("int");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CoachId");

                    b.HasIndex("SeasonId");

                    b.HasIndex("TeamId");

                    b.ToTable("CoachTeams");
                });

            modelBuilder.Entity("MySoccerWorld.Model.Entities.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Flag")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Region")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasAlternateKey("Name");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("MySoccerWorld.Model.Entities.Goal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MatchId")
                        .HasColumnType("int");

                    b.Property<int>("PlayerTeamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MatchId");

                    b.HasIndex("PlayerTeamId");

                    b.ToTable("Goals");
                });

            modelBuilder.Entity("MySoccerWorld.Model.Entities.League", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Logo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Region")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Leagues");
                });

            modelBuilder.Entity("MySoccerWorld.Model.Entities.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte?>("AwayEx")
                        .HasColumnType("tinyint");

                    b.Property<byte?>("AwayPen")
                        .HasColumnType("tinyint");

                    b.Property<byte?>("AwayScore")
                        .HasColumnType("tinyint");

                    b.Property<int>("AwayTeam")
                        .HasColumnType("int");

                    b.Property<double?>("Data")
                        .HasColumnType("float");

                    b.Property<string>("Group")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte?>("HomeEx")
                        .HasColumnType("tinyint");

                    b.Property<byte?>("HomePen")
                        .HasColumnType("tinyint");

                    b.Property<byte?>("HomeScore")
                        .HasColumnType("tinyint");

                    b.Property<int>("HomeTeam")
                        .HasColumnType("int");

                    b.Property<bool>("Neytral")
                        .HasColumnType("bit");

                    b.Property<string>("Round")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TournamentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AwayTeam");

                    b.HasIndex("HomeTeam");

                    b.HasIndex("TournamentId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("MySoccerWorld.Model.Entities.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasAlternateKey("Name");

                    b.HasIndex("CountryId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("MySoccerWorld.Model.Entities.PlayerTeam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.Property<int?>("SeasonId")
                        .HasColumnType("int");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.HasIndex("SeasonId");

                    b.HasIndex("TeamId");

                    b.ToTable("PlayerTeams");
                });

            modelBuilder.Entity("MySoccerWorld.Model.Entities.Rating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double?>("Points")
                        .HasColumnType("float");

                    b.Property<int?>("Position")
                        .HasColumnType("int");

                    b.Property<string>("Round")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeamId")
                        .HasColumnType("int");

                    b.Property<int>("TournamentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.HasIndex("TournamentId");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("MySoccerWorld.Model.Entities.Season", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Data")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Seasons");
                });

            modelBuilder.Entity("MySoccerWorld.Model.Entities.SeasonalAward", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AwardName")
                        .HasColumnType("int");

                    b.Property<int?>("BestCoachId")
                        .HasColumnType("int");

                    b.Property<int?>("CoachId")
                        .HasColumnType("int");

                    b.Property<int?>("PlayerTeamId")
                        .HasColumnType("int");

                    b.Property<int>("SeasonId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BestCoachId");

                    b.HasIndex("PlayerTeamId");

                    b.HasIndex("SeasonId");

                    b.ToTable("SeasonalAwards");
                });

            modelBuilder.Entity("MySoccerWorld.Model.Entities.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Flag")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasAlternateKey("Name");

                    b.ToTable("Teams");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Team");
                });

            modelBuilder.Entity("MySoccerWorld.Model.Entities.Tournament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BestPlayerFormation")
                        .HasColumnType("int");

                    b.Property<string>("Division")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("LeagueId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Place")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("SeasonId")
                        .HasColumnType("int");

                    b.Property<int?>("TournamentType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LeagueId");

                    b.HasIndex("SeasonId");

                    b.ToTable("Tournaments");
                });

            modelBuilder.Entity("MySoccerWorld.Model.Entities.TournamentAward", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AwardName")
                        .HasColumnType("int");

                    b.Property<int?>("CoachTeamId")
                        .HasColumnType("int");

                    b.Property<int?>("PlayerTeamId")
                        .HasColumnType("int");

                    b.Property<int>("TournamentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CoachTeamId");

                    b.HasIndex("PlayerTeamId");

                    b.HasIndex("TournamentId");

                    b.ToTable("TournamentAwards");
                });

            modelBuilder.Entity("TeamTournament", b =>
                {
                    b.Property<int>("TeamsId")
                        .HasColumnType("int");

                    b.Property<int>("TournamentsId")
                        .HasColumnType("int");

                    b.HasKey("TeamsId", "TournamentsId");

                    b.HasIndex("TournamentsId");

                    b.ToTable("TeamTournament");
                });

            modelBuilder.Entity("MySoccerWorld.Model.Entities.Club", b =>
                {
                    b.HasBaseType("MySoccerWorld.Model.Entities.Team");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.HasIndex("CountryId");

                    b.HasDiscriminator().HasValue("Club");
                });

            modelBuilder.Entity("MySoccerWorld.Model.Entities.National", b =>
                {
                    b.HasBaseType("MySoccerWorld.Model.Entities.Team");

                    b.Property<string>("Region")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("National");
                });

            modelBuilder.Entity("MySoccerWorld.Model.Entities.Asist", b =>
                {
                    b.HasOne("MySoccerWorld.Model.Entities.Match", "Match")
                        .WithMany("Asists")
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MySoccerWorld.Model.Entities.PlayerTeam", "PlayerTeam")
                        .WithMany("Asists")
                        .HasForeignKey("PlayerTeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Match");

                    b.Navigation("PlayerTeam");
                });

            modelBuilder.Entity("MySoccerWorld.Model.Entities.BestPlayer", b =>
                {
                    b.HasOne("MySoccerWorld.Model.Entities.PlayerTeam", "PlayerTeam")
                        .WithMany("BestPlayers")
                        .HasForeignKey("PlayerTeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MySoccerWorld.Model.Entities.Tournament", "Tournament")
                        .WithMany("BestPlayers")
                        .HasForeignKey("TournamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PlayerTeam");

                    b.Navigation("Tournament");
                });

            modelBuilder.Entity("MySoccerWorld.Model.Entities.Coach", b =>
                {
                    b.HasOne("MySoccerWorld.Model.Entities.Country", "Country")
                        .WithMany("Coaches")
                        .HasForeignKey("CountryId");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("MySoccerWorld.Model.Entities.CoachTeam", b =>
                {
                    b.HasOne("MySoccerWorld.Model.Entities.Coach", "Coach")
                        .WithMany("CoachTeams")
                        .HasForeignKey("CoachId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MySoccerWorld.Model.Entities.Season", "Season")
                        .WithMany()
                        .HasForeignKey("SeasonId");

                    b.HasOne("MySoccerWorld.Model.Entities.Team", "Team")
                        .WithMany("CoachTeams")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Coach");

                    b.Navigation("Season");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("MySoccerWorld.Model.Entities.Goal", b =>
                {
                    b.HasOne("MySoccerWorld.Model.Entities.Match", "Match")
                        .WithMany("Goals")
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MySoccerWorld.Model.Entities.PlayerTeam", "PlayerTeam")
                        .WithMany("Goals")
                        .HasForeignKey("PlayerTeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Match");

                    b.Navigation("PlayerTeam");
                });

            modelBuilder.Entity("MySoccerWorld.Model.Entities.Match", b =>
                {
                    b.HasOne("MySoccerWorld.Model.Entities.Team", "Away")
                        .WithMany("Aways")
                        .HasForeignKey("AwayTeam")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("MySoccerWorld.Model.Entities.Team", "Home")
                        .WithMany("Homes")
                        .HasForeignKey("HomeTeam")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("MySoccerWorld.Model.Entities.Tournament", "Tournament")
                        .WithMany("Matches")
                        .HasForeignKey("TournamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Away");

                    b.Navigation("Home");

                    b.Navigation("Tournament");
                });

            modelBuilder.Entity("MySoccerWorld.Model.Entities.Player", b =>
                {
                    b.HasOne("MySoccerWorld.Model.Entities.Country", "Country")
                        .WithMany("Players")
                        .HasForeignKey("CountryId");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("MySoccerWorld.Model.Entities.PlayerTeam", b =>
                {
                    b.HasOne("MySoccerWorld.Model.Entities.Player", "Player")
                        .WithMany("PlayerTeams")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MySoccerWorld.Model.Entities.Season", "Season")
                        .WithMany()
                        .HasForeignKey("SeasonId");

                    b.HasOne("MySoccerWorld.Model.Entities.Team", "Team")
                        .WithMany("PlayerTeams")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Player");

                    b.Navigation("Season");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("MySoccerWorld.Model.Entities.Rating", b =>
                {
                    b.HasOne("MySoccerWorld.Model.Entities.Team", "Team")
                        .WithMany("Ratings")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MySoccerWorld.Model.Entities.Tournament", "Tournament")
                        .WithMany("Ratings")
                        .HasForeignKey("TournamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");

                    b.Navigation("Tournament");
                });

            modelBuilder.Entity("MySoccerWorld.Model.Entities.SeasonalAward", b =>
                {
                    b.HasOne("MySoccerWorld.Model.Entities.CoachTeam", "BestCoach")
                        .WithMany("SeasonalAwards")
                        .HasForeignKey("BestCoachId");

                    b.HasOne("MySoccerWorld.Model.Entities.PlayerTeam", "PlayerTeam")
                        .WithMany("SeasonalAwards")
                        .HasForeignKey("PlayerTeamId");

                    b.HasOne("MySoccerWorld.Model.Entities.Season", "Season")
                        .WithMany()
                        .HasForeignKey("SeasonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BestCoach");

                    b.Navigation("PlayerTeam");

                    b.Navigation("Season");
                });

            modelBuilder.Entity("MySoccerWorld.Model.Entities.Tournament", b =>
                {
                    b.HasOne("MySoccerWorld.Model.Entities.League", "League")
                        .WithMany("Tournaments")
                        .HasForeignKey("LeagueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MySoccerWorld.Model.Entities.Season", "Season")
                        .WithMany("Tournaments")
                        .HasForeignKey("SeasonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("League");

                    b.Navigation("Season");
                });

            modelBuilder.Entity("MySoccerWorld.Model.Entities.TournamentAward", b =>
                {
                    b.HasOne("MySoccerWorld.Model.Entities.CoachTeam", "CoachTeam")
                        .WithMany("TournamentAwards")
                        .HasForeignKey("CoachTeamId");

                    b.HasOne("MySoccerWorld.Model.Entities.PlayerTeam", "PlayerTeam")
                        .WithMany("TournamentAwards")
                        .HasForeignKey("PlayerTeamId");

                    b.HasOne("MySoccerWorld.Model.Entities.Tournament", "Tournament")
                        .WithMany("TournamentAwards")
                        .HasForeignKey("TournamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CoachTeam");

                    b.Navigation("PlayerTeam");

                    b.Navigation("Tournament");
                });

            modelBuilder.Entity("TeamTournament", b =>
                {
                    b.HasOne("MySoccerWorld.Model.Entities.Team", null)
                        .WithMany()
                        .HasForeignKey("TeamsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MySoccerWorld.Model.Entities.Tournament", null)
                        .WithMany()
                        .HasForeignKey("TournamentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MySoccerWorld.Model.Entities.Club", b =>
                {
                    b.HasOne("MySoccerWorld.Model.Entities.Country", "Country")
                        .WithMany("Clubs")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("MySoccerWorld.Model.Entities.Coach", b =>
                {
                    b.Navigation("CoachTeams");
                });

            modelBuilder.Entity("MySoccerWorld.Model.Entities.CoachTeam", b =>
                {
                    b.Navigation("SeasonalAwards");

                    b.Navigation("TournamentAwards");
                });

            modelBuilder.Entity("MySoccerWorld.Model.Entities.Country", b =>
                {
                    b.Navigation("Clubs");

                    b.Navigation("Coaches");

                    b.Navigation("Players");
                });

            modelBuilder.Entity("MySoccerWorld.Model.Entities.League", b =>
                {
                    b.Navigation("Tournaments");
                });

            modelBuilder.Entity("MySoccerWorld.Model.Entities.Match", b =>
                {
                    b.Navigation("Asists");

                    b.Navigation("Goals");
                });

            modelBuilder.Entity("MySoccerWorld.Model.Entities.Player", b =>
                {
                    b.Navigation("PlayerTeams");
                });

            modelBuilder.Entity("MySoccerWorld.Model.Entities.PlayerTeam", b =>
                {
                    b.Navigation("Asists");

                    b.Navigation("BestPlayers");

                    b.Navigation("Goals");

                    b.Navigation("SeasonalAwards");

                    b.Navigation("TournamentAwards");
                });

            modelBuilder.Entity("MySoccerWorld.Model.Entities.Season", b =>
                {
                    b.Navigation("Tournaments");
                });

            modelBuilder.Entity("MySoccerWorld.Model.Entities.Team", b =>
                {
                    b.Navigation("Aways");

                    b.Navigation("CoachTeams");

                    b.Navigation("Homes");

                    b.Navigation("PlayerTeams");

                    b.Navigation("Ratings");
                });

            modelBuilder.Entity("MySoccerWorld.Model.Entities.Tournament", b =>
                {
                    b.Navigation("BestPlayers");

                    b.Navigation("Matches");

                    b.Navigation("Ratings");

                    b.Navigation("TournamentAwards");
                });
#pragma warning restore 612, 618
        }
    }
}
