using FootballWorldCup.Application.Models;
using FootballWorldCup.Application.Services;
using System.Collections.Generic;
using Xunit;

namespace FootballWorldCup.Application.Test
{
    public class ScoreBoardService_GetScoreBoardSummaryShould
    {

        [Fact]
        public void ReturnsScoreBoardWithEmptyListOfGames_WhenScoreBoardIsNull()
        {

            var scoreBoardService = new ScoreBoardService(null);

            var scoreBoard = scoreBoardService.GetScoreBoardSummary();

            Assert.Empty(scoreBoard.Games);
        }


        [Fact]
        public void ReturnsScoreBoardWithEmptyListOfGames_WhenGameListIsNull()
        {
            var scoreBoard = new ScoreBoard();
            var scoreBoardService = new ScoreBoardService(scoreBoard);

            var scoreBoardResult = scoreBoardService.GetScoreBoardSummary();

            Assert.Empty(scoreBoardResult.Games);
        }


        [Fact]
        public void ReturnsAllGames_WhenScoreboardContainsGames()
        {
            var scoreBoard = new ScoreBoard()
            {
                Games = new List<Game>()
                {
                    new Game()
                    {
                        HomeTeam = "Argentina",
                        HomeTeamScore = 3,
                        AwayTeam = "Australia",
                        AwayTeamScore = 1
                    },
                    new Game()
                    {
                        HomeTeam = "Mexico",
                        HomeTeamScore = 0,
                        AwayTeam = "Canada",
                        AwayTeamScore = 5
                    },
                }
            };
            var scoreBoardService = new ScoreBoardService(scoreBoard);

            var scoreBoardResult = scoreBoardService.GetScoreBoardSummary();

            Assert.Equal(scoreBoard.Games.Count, scoreBoardResult.Games.Count);
        }


        [Fact]
        public void ReturnsGamesOrderedByTotalScore_WhenScoreboardContainsGamesOnlyWithDifferentScore()
        {

            var firstGame = new Game()
            {
                HomeTeam = "Argentina",
                HomeTeamScore = 3,
                AwayTeam = "Australia",
                AwayTeamScore = 1
            };
            var secondGame = new Game()
            {
                HomeTeam = "España",
                HomeTeamScore = 1,
                AwayTeam = "Brasil",
                AwayTeamScore = 1
            };
            var thirdGame = new Game()
            {
                HomeTeam = "Mexico",
                HomeTeamScore = 0,
                AwayTeam = "Canada",
                AwayTeamScore = 5
            };

            var initScoreBoard = new ScoreBoard()
            {
                Games = new List<Game>()
            };

            initScoreBoard.Games.Add(firstGame);
            initScoreBoard.Games.Add(secondGame);
            initScoreBoard.Games.Add(thirdGame);

            var scoreBoardService = new ScoreBoardService(initScoreBoard);

            var scoreBoardOrdered = new ScoreBoard()
            {
                Games = new List<Game>()
            };

            scoreBoardOrdered.Games.Add(thirdGame);
            scoreBoardOrdered.Games.Add(firstGame);
            scoreBoardOrdered.Games.Add(secondGame);

            var scoreBoardResult = scoreBoardService.GetScoreBoardSummary();

            Assert.True(scoreBoardResult.Games[0].Equals(scoreBoardOrdered.Games[0]) &&
                        scoreBoardResult.Games[1].Equals(scoreBoardOrdered.Games[1]) &&
                        scoreBoardResult.Games[2].Equals(scoreBoardOrdered.Games[2]));
        }

        [Fact]
        public void ReturnsGamesOrderedByMostRecently_WhenScoreboardContainsOnlyGamesWithSameScores()
        {

            var firstGame = new Game()
            {
                HomeTeam = "Argentina",
                HomeTeamScore = 1,
                AwayTeam = "Australia",
                AwayTeamScore = 3
            };
            var secondGame = new Game()
            {
                HomeTeam = "España",
                HomeTeamScore = 2,
                AwayTeam = "Brasil",
                AwayTeamScore = 2
            };
            var thirdGame = new Game()
            {
                HomeTeam = "Mexico",
                HomeTeamScore = 4,
                AwayTeam = "Canada",
                AwayTeamScore = 0
            };

            var initScoreBoard = new ScoreBoard()
            {
                Games = new List<Game>()
            };

            initScoreBoard.Games.Add(firstGame);
            initScoreBoard.Games.Add(secondGame);
            initScoreBoard.Games.Add(thirdGame);


            var scoreBoardService = new ScoreBoardService(initScoreBoard);
            var scoreBoardResult = scoreBoardService.GetScoreBoardSummary();

            var scoreBoardOrdered = new ScoreBoard()
            {
                Games = new List<Game>()
            };

            scoreBoardOrdered.Games.Add(thirdGame);
            scoreBoardOrdered.Games.Add(secondGame);
            scoreBoardOrdered.Games.Add(firstGame);


            Assert.True(scoreBoardResult.Games[0].Equals(scoreBoardOrdered.Games[0]) &&
                        scoreBoardResult.Games[1].Equals(scoreBoardOrdered.Games[1]) &&
                        scoreBoardResult.Games[2].Equals(scoreBoardOrdered.Games[2]));
        }


        [Fact]
        public void ReturnsGamesOrderedByTotalScoreAndMostRecently_WhenScoreboardContainsGamesWithSameAndDifferentScores()
        {

            var firstGame = new Game()
            {
                HomeTeam = "Argentina",
                HomeTeamScore = 1,
                AwayTeam = "Australia",
                AwayTeamScore = 3
            };
            var secondGame = new Game()
            {
                HomeTeam = "España",
                HomeTeamScore = 5,
                AwayTeam = "Brasil",
                AwayTeamScore = 2
            };
            var thirdGame = new Game()
            {
                HomeTeam = "Mexico",
                HomeTeamScore = 4,
                AwayTeam = "Canada",
                AwayTeamScore = 0
            };

            var initScoreBoard = new ScoreBoard()
            {
                Games = new List<Game>()
            };

            initScoreBoard.Games.Add(firstGame);
            initScoreBoard.Games.Add(secondGame);
            initScoreBoard.Games.Add(thirdGame);


            var scoreBoardService = new ScoreBoardService(initScoreBoard);
            var scoreBoardResult = scoreBoardService.GetScoreBoardSummary();

            var scoreBoardOrdered = new ScoreBoard()
            {
                Games = new List<Game>()
            };

            scoreBoardOrdered.Games.Add(secondGame);
            scoreBoardOrdered.Games.Add(thirdGame);
            scoreBoardOrdered.Games.Add(firstGame);


            Assert.True(scoreBoardResult.Games[0].Equals(scoreBoardOrdered.Games[0]) &&
                        scoreBoardResult.Games[1].Equals(scoreBoardOrdered.Games[1]) &&
                        scoreBoardResult.Games[2].Equals(scoreBoardOrdered.Games[2]));
        }


    }
}