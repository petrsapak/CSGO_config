using TeamGenerator.Core.Interfaces;
using TeamGenerator.Model;

namespace TeamGenerator.Core
{
    internal class BasicEvaluator : IEvaluate
    {
        public int EvaluatePlayer(Player player)
        {
            return (int)player.Rank;
        }

        public int EvaluateTeam(Team team)
        {
            int rankCounter = 0;

            foreach (Player player in team.Players.Values)
            {
                rankCounter += (int)player.Rank;
            }

            return rankCounter;
        }
    }
}
