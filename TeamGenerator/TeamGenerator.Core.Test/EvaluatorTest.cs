using NUnit.Framework;
using TeamGenerator.Core.Interfaces;
using TeamGenerator.Core.Tests;
using TeamGenerator.Model;

namespace TeamGenerator.Core.Test
{
    class EvaluatorTest
    {
        private IEvaluate evaluator = new Evaluator();

        [Test]
        [TestCase(Rank.Silver1, 1)]
        [TestCase(Rank.Silver2, 3)]
        [TestCase(Rank.Silver3, 5)]
        [TestCase(Rank.Silver4, 7)]
        [TestCase(Rank.SilverElite, 9)]
        [TestCase(Rank.SilverEliteMaster, 11)]
        [TestCase(Rank.GoldNova1, 14)]
        [TestCase(Rank.GoldNova2, 17)]
        [TestCase(Rank.GoldNova3, 20)]
        [TestCase(Rank.GoldNovaMaster, 23)]
        [TestCase(Rank.MasterGuardian1, 27)]
        [TestCase(Rank.MasterGuardian2, 31)]
        [TestCase(Rank.MasterGuardianElite, 35)]
        [TestCase(Rank.DistinguishedMasterGuardian, 39)]
        [TestCase(Rank.LegendaryEagle, 44)]
        [TestCase(Rank.LegendaryEagleMaster, 49)]
        [TestCase(Rank.SupremeMasterFirstClass, 54)]
        [TestCase(Rank.GlobalElite, 64)]
        public void EvaluatePlayer_ReturnsValueFromEnum(Rank rank, int expectedValue) 
        {
            Player player = new Player("", rank);

            Assert.That(evaluator.EvaluatePlayer(player), Is.EqualTo(expectedValue));
        }

        [Test]
        public void EvaluateTeam_ReturnsSumOfindividualTeamMembersEvaluations()
        {
            Team team = EvaluatorTestHelper.GenerateRandomTeam();
            int sumOfIndividualEvaluations = EvaluatorTestHelper.GetSumOfIndividualEvaluations(team);

            Assert.That(evaluator.EvaluateTeam(team), Is.EqualTo(sumOfIndividualEvaluations));
        }
    }
}
