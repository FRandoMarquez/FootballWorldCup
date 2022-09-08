using FootballWorldCup.Application.Models;
using FootballWorldCup.Application.Services;

var _scoreBoard = new ScoreBoard()
{
    Games = new List<Game>() { }
};

var _scoreBoardService = new ScoreBoardService(_scoreBoard);

_scoreBoardService.StartGame("Argentina", "Australia");
_scoreBoardService.StartGame("Spain", "Brazil");
_scoreBoardService.StartGame("Mexico", "Canada");
_scoreBoardService.StartGame("Germany", "France");


Console.WriteLine("Welcome to Football World Cup!" + Environment.NewLine
    + "Current Games in Score Board: " + Environment.NewLine);

Console.WriteLine(_scoreBoard);

_scoreBoardService.UpdateScore(new Game()
{
    HomeTeam = "Argentina",
    HomeTeamScore = 3,
    AwayTeam = "Australia",
    AwayTeamScore = 1
});

Console.WriteLine("Updating Scores..." + Environment.NewLine);

var summary = _scoreBoardService.GetScoreBoardSummary();

Console.WriteLine(summary);


_scoreBoardService.UpdateScore(new Game()
{
    HomeTeam = "Mexico",
    HomeTeamScore = 0,
    AwayTeam = "Canada",
    AwayTeamScore = 5
});

Console.WriteLine("Updating Scores..." + Environment.NewLine);

summary = _scoreBoardService.GetScoreBoardSummary();

Console.WriteLine(summary);


_scoreBoardService.UpdateScore(new Game()
{
    HomeTeam = "Spain",
    HomeTeamScore = 2,
    AwayTeam = "Brazil",
    AwayTeamScore = 3
});

Console.WriteLine("Updating Scores..." + Environment.NewLine);

summary = _scoreBoardService.GetScoreBoardSummary();

Console.WriteLine(summary);


Console.WriteLine("Finish a Game..." + Environment.NewLine);

_scoreBoardService.FinishGame("Argentina", "Australia");

summary = _scoreBoardService.GetScoreBoardSummary();

Console.WriteLine(summary);


