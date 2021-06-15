﻿using System;
using System.Collections.Generic;
using System.Linq;
using TeamGenerator.Core.Interfaces;
using TeamGenerator.Model;

namespace TeamGenerator.Core
{
    internal class BasicGenerator : IGenerate
    {
        private readonly List<Player> availablePlayerPool;
        private List<Player> availablePlayerPoolBackup;
        private readonly IEvaluate evaluator;
        private readonly Random random;

        private Team teamCounterTerroristBuffer;
        private Team teamTerroristBuffer;

        public BasicGenerator(IEvaluate evaluator, IEnumerable<Player> availablePlayers, Random random)
        {
            this.availablePlayerPool = availablePlayers.ToList();
            this.availablePlayerPoolBackup = availablePlayers.ToList();
            this.evaluator = evaluator;
            this.random = random;

            teamTerroristBuffer = new Team("T");
            teamCounterTerroristBuffer = new Team("CT");
        }

        public (Team, Team) GenerateTeams()
        {
            try
            {
                Player initialRandomCoutnerTerroristPlayer = GetRandomPlayerFromPool();
                MovePlayerFromPoolToBuffer(initialRandomCoutnerTerroristPlayer);

                Player initialRandomTerroristPlayer = GetRandomPlayerFromPool();
                MovePlayerFromPoolToBuffer(initialRandomTerroristPlayer);

                while(availablePlayerPool.Count > 0)
                {
                    AddNextPlayer();
                }
            }
            catch (ArgumentOutOfRangeException exception)
            {
                //TODO log
            }

            Team teamCounterTerrorist = (Team)teamCounterTerroristBuffer.Clone();
            Team teamTerrorist = (Team)teamTerroristBuffer.Clone();

            CleanBuffers();
            RefreshAvailablePlayerPool();

            return (teamCounterTerrorist, teamTerrorist);

        }

        private void RefreshAvailablePlayerPool()
        {
            foreach (Player player in availablePlayerPoolBackup)
            {
                availablePlayerPool.Add(player);
            }
        }

        private void CleanBuffers()
        {
            teamTerroristBuffer = new Team("T");
            teamCounterTerroristBuffer = new Team("CT");
        }

        private void MovePlayerFromPoolToBuffer(Player player)
        {
            availablePlayerPool.Remove(player);
            teamCounterTerroristBuffer.AddPlayer(player);
        }

        private void AddNextPlayer()
        {
            int teamCounterTerroristEvaluation = evaluator.EvaluateTeam(teamCounterTerroristBuffer);
            int teamTerroristEvaluation = evaluator.EvaluateTeam(teamTerroristBuffer);
            int evaluationDifference = teamCounterTerroristEvaluation - teamTerroristEvaluation;

            if (evaluationDifference == 0)
            {
                Player randomPlayer = GetRandomPlayerFromPool();
                teamTerroristBuffer.AddPlayer(randomPlayer);
                availablePlayerPool.Remove(randomPlayer);
            }
            else if (evaluationDifference > 0)
            {
                Player bestComplementPlayer = GetBestComplementPlayerFromPool(evaluationDifference);
                teamTerroristBuffer.AddPlayer(bestComplementPlayer);
                availablePlayerPool.Remove(bestComplementPlayer);
            }
            else
            {
                Player bestComplementPlayer = GetBestComplementPlayerFromPool(evaluationDifference);
                teamCounterTerroristBuffer.AddPlayer(bestComplementPlayer);
                availablePlayerPool.Remove(bestComplementPlayer);
            }
        }

        private Player GetRandomPlayerFromPool()
        {
            Player randomPlayer = availablePlayerPool[random.Next(availablePlayerPool.Count)];
            return randomPlayer;
        }

        private Player GetBestComplementPlayerFromPool(int evaluationDifference)
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
