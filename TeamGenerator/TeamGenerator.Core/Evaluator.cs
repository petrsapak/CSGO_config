using TeamGenerator.Core.Interfaces;
using TeamGenerator.Model;

namespace TeamGenerator.Core
{
    internal class Evaluator : IEvaluate
    {
        public int EvaluatePlayer(Player player)
        {
            return (int)player.Rank;
        }

        public int EvaluateTeam(Team team)
        {
            throw new System.NotImplementedException();
        }
    }
}
