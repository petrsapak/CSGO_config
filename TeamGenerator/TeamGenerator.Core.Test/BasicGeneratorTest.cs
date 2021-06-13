using NUnit.Framework;
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
            IGenerate basicGenerator = new BasicGenerator(new BasicEvaluator(), new List<Player>());
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
            IGenerate basicGenerator = new BasicGenerator(new BasicEvaluator(), availablePlayers);
            (Team, Team) teams = basicGenerator.GenerateTeams();

            Assert.Multiple(() =>
            {
                Assert.That(teams.Item1.Players.Count, Is.GreaterThan(0));
                Assert.That(teams.Item2.Players.Count, Is.GreaterThan(0));
            });
        }
    }
}
