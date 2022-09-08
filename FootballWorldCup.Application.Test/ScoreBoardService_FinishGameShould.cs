using FootballWorldCup.Application.Models;
using FootballWorldCup.Application.Services;
using System.Collections.Generic;
using Xunit;

namespace FootballWorldCup.Application.Test
{
    public class ScoreBoardService_FinishGameShould
    {

        private ScoreBoardService _scoreBoardService;
        private ScoreBoard _scoreBoard;


        public ScoreBoardService_FinishGameShould()
        {
            _scoreBoard = new ScoreBoard()
            {
                Games = new List<Game>()
            };

            _scoreBoardService = new ScoreBoardService(_scoreBoard);
        }

        [Fact]
        public void NotRemoveAGame_WhenScoreBoardIsNull()
        {
            _scoreBoard = null;
            _scoreBoardService = new ScoreBoardService(null);
            _scoreBoardService.FinishGame("HomeTeam", "AwayTeam");

            Assert.Null(_scoreBoard);
        }


        [Theory]
        [InlineData(null, null)]
        [InlineData(null, "")]
        [InlineData("", null)]
        [InlineData("", "")]
        public void NotRemoveAGame_WhenGameTeamsAreNullOrEmpty(string HomeTeam, string AwayTeam)
        {
            _scoreBoard.Games.Add(new Game
            {
                HomeTeam = "HomeTeam",
                AwayTeam = "AwayTeam"
            });

            _scoreBoardService.FinishGame(HomeTeam, AwayTeam);

            Assert.Single(_scoreBoard.Games, game => game.HomeTeam.Equals("HomeTeam") && game.AwayTeam.Equals("AwayTeam"));
        }

        [Fact]
        public void NotRemoveAGame_WhenScoreBoardIsEmpty()
        {
            _scoreBoardService.FinishGame("HomeTeam", "AwayTeam");

            Assert.Empty(_scoreBoard.Games);
        }


        [Theory]
        [InlineData("HomeTeam", "AwayTeam")]
        [InlineData("HomeTeamExists", "AwayTeam")]
        [InlineData("HomeTeam", "AwayTeamExists")]
        public void NotRemoveAGame_WhenItDoesNotExistInScoreBoard(string HomeTeam, string AwayTeam)
        {
            _scoreBoard.Games.Add(new Game
            {
                HomeTeam = "HomeTeamExists",
                AwayTeam = "AwayTeamExists"
            });

            _scoreBoardService.FinishGame(HomeTeam, AwayTeam);

            Assert.Single(_scoreBoard.Games, game => game.HomeTeam.Equals("HomeTeamExists") && game.AwayTeam.Equals("AwayTeamExists"));
        }

        [Fact]
        public void RemoveAGame_WhenItExistsInScoreBoard()
        {
            _scoreBoard.Games.Add(new Game
            {
                HomeTeam = "HomeTeam",
                AwayTeam = "AwayTeam"
            });

            _scoreBoardService.FinishGame("HomeTeam", "AwayTeam");

            Assert.Empty(_scoreBoard.Games);
        }

    }
}