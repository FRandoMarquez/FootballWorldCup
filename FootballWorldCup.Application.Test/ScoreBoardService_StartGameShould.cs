using FootballWorldCup.Application.Models;
using FootballWorldCup.Application.Services;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FootballWorldCup.Application.Test
{
    public class ScoreBoardService_StartGameShould
    {

        private ScoreBoardService _scoreBoardService;
        private ScoreBoard _scoreBoard;


        public ScoreBoardService_StartGameShould()
        {
            _scoreBoard = new ScoreBoard()
            {
                Games = new List<Game>()
            };

            _scoreBoardService = new ScoreBoardService(_scoreBoard);
        }


        [Theory]
        [InlineData(null, null)]
        [InlineData(null, "")]
        [InlineData("", null)]
        [InlineData("", "")]
        public void NotAddAGame_WhenGameTeamsAreNullOrEmpty(string HomeTeam, string AwayTeam)
        {
            _scoreBoardService.StartGame(HomeTeam, AwayTeam);

            Assert.True(!_scoreBoard.Games.Any(game => game.HomeTeam.Equals(HomeTeam) || game.AwayTeam.Equals(AwayTeam)));
        }

        [Theory]
        [InlineData("HomeTeam", "AwayTeamExists")]
        [InlineData("HomeTeamExists", "AwayTeam")]
        [InlineData("HomeTeamExists", "AwayTeamExists")]
        public void NotAddAGame_WhenInputTeamIsAlreadyPlayingAGame(string HomeTeam, string AwayTeam)
        {

            _scoreBoard.Games.Add(new Game
            {
                HomeTeam = "HomeTeamExists",
                AwayTeam = "AwayTeamExists"
            });

            _scoreBoardService.StartGame(HomeTeam, AwayTeam);

            Assert.Single(_scoreBoard.Games);
        }

        [Fact]
        public void AddANewGameToScoreBoard_WhenInputTeamsAreNOTPlayingAGame()
        {
            _scoreBoardService.StartGame("HomeTeam", "AwayTeam");

            Assert.Single(_scoreBoard.Games.Where(game => game.HomeTeam.Equals("HomeTeam") && game.AwayTeam.Equals("AwayTeam")));
        }

        [Fact]
        public void SetTheInitialGameScore0To0_WhenANewGameIsAdded()
        {
            _scoreBoardService.StartGame("HomeTeam", "AwayTeam");

            var game = _scoreBoard.Games.FirstOrDefault(game => game.HomeTeam.Equals("HomeTeam") && game.AwayTeam.Equals("AwayTeam"));

            Assert.True(game != null && game.HomeTeamScore == 0 && game.AwayTeamScore == 0);
        }



    }
}