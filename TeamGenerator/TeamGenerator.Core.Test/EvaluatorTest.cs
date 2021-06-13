using NUnit.Framework;
using TeamGenerator.Core.Interfaces;
using TeamGenerator.Core.Tests;
using TeamGenerator.Model;

namespace TeamGenerator.Core.Test
{
    class EvaluatorTest
    {
        private readonly IEvaluate evaluator = new BasicEvaluator();

        [Test]
        public void EvaluateTeam_ReturnsSumOfindividualTeamMembersEvaluations()
        {
            Team team = EvaluatorTestHelper.GenerateRandomTeam();
            int sumOfIndividualEvaluations = EvaluatorTestHelper.GetSumOfIndividualEvaluations(team);

            Assert.That(evaluator.EvaluateTeam(team), Is.EqualTo(sumOfIndividualEvaluations));
        }
    }
}
