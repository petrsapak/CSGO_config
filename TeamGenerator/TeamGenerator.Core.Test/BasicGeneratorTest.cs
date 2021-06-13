using NUnit.Framework;
using System;
using System.Collections.Generic;
using TeamGenerator.Core.Interfaces;
using TeamGenerator.Model;

namespace TeamGenerator.Core.Test
{
    class BasicGeneratorTest
    {
        [Test]
        public void GenerateTeams_ReturnsCorrectlyNamedEmptyTeams_WhenNoPlayersAreProvided()
        {
            IGenerate basicGenerator = new BasicGenerator(new BasicEvaluator(), new List<Player>(), new Random());
            (Team, Team) teams = basicGenerator.GenerateTeams();

            Assert.Multiple(() =>
            {
                Assert.That(teams.Item1.Name, Is.EqualTo("CT"));
                Assert.That(teams.Item2.Name, Is.EqualTo("T"));
                Assert.That(teams.Item1.Players.Count, Is.EqualTo(0));
                Assert.That(teams.Item2.Players.Count, Is.EqualTo(0));
            });
        }

        [Test]
        public void GenerateTeams_ReturnsBalancedTeams_WhenListOfBalancablePlayersIsProvided()
        {
            List<Player> availablePlayers = new List<Player>
            {
                new Player("1", Rank.Silver4),
                new Player("2", Rank.Silver2),
                new Player("3", Rank.Silver2),
                new Player("4", Rank.Silver1)
            };
            IGenerate basicGenerator = new BasicGenerator(new BasicEvaluator(), availablePlayers, new Random());
            (Team, Team) teams = basicGenerator.GenerateTeams();

            Assert.Multiple(() =>
            {
                Assert.That(teams.Item1.Players.Count, Is.GreaterThan(0));
                Assert.That(teams.Item2.Players.Count, Is.GreaterThan(0));
            });
        }

        [Test]
        [Ignore("Is not a real test")]
        public void GenerateTeams_RealWordScenario()
        {
            IEvaluate evaluator = new BasicEvaluator();
            List<Player> availablePlayers = new List<Player>
            {
                new Player("Ja", Rank.GoldNova3),
                new Player("Vasek", Rank.SilverEliteMaster),
                new Player("Ondra", Rank.SilverElite),
                new Player("Ivan", Rank.SilverElite),
                new Player("Jirka", Rank.SilverElite),
                new Player("Nela", Rank.Silver1),
                new Player("Vlada", Rank.Silver1),
                new Player("BotA", Rank.Silver1),
                new Player("BotB", Rank.Silver1),
                new Player("BotC", Rank.Silver1),
            };
            Random random = new Random();

            for (int i = 0; i < 100; i++)
            {
                IGenerate basicGenerator = new BasicGenerator(evaluator, availablePlayers, random);
                (Team, Team) teams = basicGenerator.GenerateTeams();

                int counterTerroristTeamEvaluation = evaluator.EvaluateTeam(teams.Item1);
                int terroristTeamEvaluation = evaluator.EvaluateTeam(teams.Item2);
                int sumOfEvaluations = counterTerroristTeamEvaluation + terroristTeamEvaluation;
                double evaluationPointToPercent = (double)100 / (double)sumOfEvaluations;
                int counterTerrorisChanceOfWinning = (int)Math.Floor(counterTerroristTeamEvaluation * evaluationPointToPercent);
                int terrorisChanceOfWinning = (int)Math.Floor(terroristTeamEvaluation * evaluationPointToPercent);

                Console.WriteLine($"Iteration #{i}");
                Console.WriteLine("-----------------------------");
                Console.WriteLine($"Counter-Terrorists - {counterTerrorisChanceOfWinning}%");

                foreach (Player player in teams.Item1.Players.Values)
                {
                    Console.WriteLine(player.Nick);
                }

                Console.WriteLine($"Terrorists - {terrorisChanceOfWinning}%");

                foreach (Player player in teams.Item2.Players.Values)
                {
                    Console.WriteLine(player.Nick);
                }

                Console.WriteLine();
            }
        }
    }
}
