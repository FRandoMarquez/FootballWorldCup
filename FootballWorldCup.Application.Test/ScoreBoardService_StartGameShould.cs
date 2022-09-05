using FootballWorldCup.Application.Models;
using FootballWorldCup.Application.Services;
using System.Collections.Generic;
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

            Assert.True(_scoreBoard.Games.Find(game => game.HomeTeam.Equals(HomeTeam) || game.AwayTeam.Equals(AwayTeam)) == null);
        }

    }
}