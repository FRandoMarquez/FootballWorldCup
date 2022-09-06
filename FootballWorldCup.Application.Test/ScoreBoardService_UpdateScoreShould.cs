using FootballWorldCup.Application.Models;
using FootballWorldCup.Application.Services;
using System.Collections.Generic;
using Xunit;

namespace FootballWorldCup.Application.Test
{
    public class ScoreBoardService_UpdateGameShould
    {

        private ScoreBoardService _scoreBoardService;
        private ScoreBoard _scoreBoard;


        public ScoreBoardService_UpdateGameShould()
        {
            _scoreBoard = new ScoreBoard()
            {
                Games = new List<Game>()
            };

            _scoreBoardService = new ScoreBoardService(_scoreBoard);
        }


        [Fact]
        public void NotUpdateAGameScore_WhenGameInputIsNull()
        {

            var currentGame = new Game
            {
                HomeTeam = "HomeTeam",
                AwayTeam = "AwayTeam"
            };

            _scoreBoard.Games.Add(currentGame);

            _scoreBoardService.UpdateScore(null);

            Assert.True(currentGame.HomeTeamScore == 0 && currentGame.AwayTeamScore == 0);
        }


        [Theory]
        [InlineData(null, null)]
        [InlineData(null, "")]
        [InlineData("", null)]
        [InlineData("", "")]
        public void NotUpdateAGameScore_WhenGameTeamsAreNullOrEmpty(string HomeTeam, string AwayTeam)
        {

            var currentGame = new Game
            {
                HomeTeam = "HomeTeam",
                AwayTeam = "AwayTeam"
            };

            _scoreBoard.Games.Add(currentGame);

            var gameToUpdate = new Game
            {
                HomeTeam = HomeTeam,
                AwayTeam = AwayTeam,
                HomeTeamScore = 1,
                AwayTeamScore = 2
            };

            _scoreBoardService.UpdateScore(gameToUpdate);

            Assert.True(currentGame.HomeTeamScore == 0 && currentGame.AwayTeamScore == 0);
        }


        [Theory]
        [InlineData("HomeTeam", "AwayTeam")]
        [InlineData("HomeTeamExists", "AwayTeam")]
        [InlineData("HomeTeam", "AwayTeamExists")]
        public void NotUpdateAGameScore_WhenGameDoesNotExistInScoreBoard(string HomeTeam, string AwayTeam)
        {

            var currentGame = new Game
            {
                HomeTeam = "HomeTeamExists",
                AwayTeam = "AwayTeamExists"
            };

            _scoreBoard.Games.Add(currentGame);

            var gameToUpdate = new Game
            {
                HomeTeam = HomeTeam,
                AwayTeam = AwayTeam,
                HomeTeamScore = 1,
                AwayTeamScore = 2
            };

            _scoreBoardService.UpdateScore(gameToUpdate);

            Assert.True(currentGame.HomeTeamScore == 0 && currentGame.AwayTeamScore == 0);
        }


        [Theory]
        [InlineData(0, 0)]
        [InlineData(0, 30)]
        [InlineData(30, 0)]
        public void NotUpdateAGameScore_WhenInputScoresAreLowerThanCurrent(int HomeTeamScore, int AwayTeamScore)
        {

            var currentGame = new Game
            {
                HomeTeam = "HomeTeam",
                AwayTeam = "AwayTeam",
                HomeTeamScore = 1,
                AwayTeamScore = 2
            };

            _scoreBoard.Games.Add(currentGame);

            var gameToUpdate = new Game
            {
                HomeTeam = "HomeTeam",
                AwayTeam = "AwayTeam",
                HomeTeamScore = HomeTeamScore,
                AwayTeamScore = AwayTeamScore
            };

            _scoreBoardService.UpdateScore(gameToUpdate);

            Assert.True(currentGame.HomeTeamScore == 1 && currentGame.AwayTeamScore == 2);
        }


        [Theory]
        [InlineData(1, 3)]
        [InlineData(5, 5)]
        [InlineData(2, 1)]
        public void UpdateAGameScore_WhenInputScoresAreGreaterThanCurrent(int HomeTeamScore, int AwayTeamScore)
        {

            var currentGame = new Game
            {
                HomeTeam = "HomeTeam",
                AwayTeam = "AwayTeam",
                HomeTeamScore = 1,
                AwayTeamScore = 1
            };

            _scoreBoard.Games.Add(currentGame);

            var gameToUpdate = new Game
            {
                HomeTeam = "HomeTeam",
                AwayTeam = "AwayTeam",
                HomeTeamScore = HomeTeamScore,
                AwayTeamScore = AwayTeamScore
            };

            _scoreBoardService.UpdateScore(gameToUpdate);

            Assert.True(currentGame.HomeTeamScore == HomeTeamScore && currentGame.AwayTeamScore == AwayTeamScore);
        }




    }
}