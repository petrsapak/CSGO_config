using System;
using System.Collections.Generic;
using System.Linq;
using TeamGenerator.Core.Interfaces;
using TeamGenerator.Model;

namespace TeamGenerator.Core
{
    internal class BasicGenerator : IGenerate
    {
        private readonly List<Player> availablePlayerPool;
        private readonly IEvaluate evaluator;
        private readonly Random random;

        private readonly Team teamCounterTerroristBuffer;
        private readonly Team teamTerroristBuffer;

        public BasicGenerator(IEvaluate evaluator, IEnumerable<Player> availablePlayers, Random random)
        {
            this.availablePlayerPool = availablePlayers.ToList();
            this.evaluator = evaluator;
            this.random = random;

            teamTerroristBuffer = new Team("T");
            teamCounterTerroristBuffer = new Team("CT");
        }

        public (Team, Team) GenerateTeams()
        {
            try
            {
                Player initialRandomCoutnerTerroristPlayer = GetRandomPlayerFromBuffer();
                availablePlayerPool.Remove(initialRandomCoutnerTerroristPlayer);
                teamCounterTerroristBuffer.AddPlayer(initialRandomCoutnerTerroristPlayer);

                Player initialRandomTerroristPlayer = GetRandomPlayerFromBuffer();
                availablePlayerPool.Remove(initialRandomTerroristPlayer);
                teamTerroristBuffer.AddPlayer(initialRandomTerroristPlayer);

                while(availablePlayerPool.Count > 0)
                {
                    AddNextPlayer();
                }
            }
            catch (ArgumentOutOfRangeException exception)
            {
                //TODO log
            }

            return (teamCounterTerroristBuffer, teamTerroristBuffer);
        }

        private void AddNextPlayer()
        {
            int teamCounterTerroristEvaluation = evaluator.EvaluateTeam(teamCounterTerroristBuffer);
            int teamTerroristEvaluation = evaluator.EvaluateTeam(teamTerroristBuffer);
            int evaluationDifference = teamCounterTerroristEvaluation - teamTerroristEvaluation;

            if (evaluationDifference == 0)
            {
                Player randomPlayer = GetRandomPlayerFromBuffer();
                teamTerroristBuffer.AddPlayer(randomPlayer);
                availablePlayerPool.Remove(randomPlayer);
            }
            else if (evaluationDifference > 0)
            {
                Player bestComplementPlayer = GetBestComplementPlayerFromBuffer(evaluationDifference);
                teamTerroristBuffer.AddPlayer(bestComplementPlayer);
                availablePlayerPool.Remove(bestComplementPlayer);
            }
            else
            {
                Player bestComplementPlayer = GetBestComplementPlayerFromBuffer(evaluationDifference);
                teamCounterTerroristBuffer.AddPlayer(bestComplementPlayer);
                availablePlayerPool.Remove(bestComplementPlayer);
            }
        }

        private Player GetRandomPlayerFromBuffer()
        {
            Player randomPlayer = availablePlayerPool[random.Next(availablePlayerPool.Count)];
            return randomPlayer;
        }

        private Player GetBestComplementPlayerFromBuffer(int evaluationDifference)
        {
            Player bestComplementPlayer = null;

            foreach (Player player in availablePlayerPool)
            {
                if (bestComplementPlayer == null)
                {
                    bestComplementPlayer = player;
                }
                else
                {
                    int bestComplementPlayerDifferenceAbs =  Math.Abs(evaluator.EvaluatePlayer(bestComplementPlayer) - evaluationDifference);
                    int currentPlayerDifferenceAbs = Math.Abs(evaluator.EvaluatePlayer(player) - evaluationDifference);
                    if (currentPlayerDifferenceAbs < bestComplementPlayerDifferenceAbs)
                    {
                        bestComplementPlayer = player;
                    }
                }
            }

            return bestComplementPlayer;
        }
    }
}
