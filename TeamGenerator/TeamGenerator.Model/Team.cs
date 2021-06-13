using System;
using System.Collections.Generic;

namespace TeamGenerator.Model
{
    public class Team
    {
        public string Name { get; private set; }
        public Dictionary<string, Player> Players { get; private set; }

        public Team(string name)
        {
            Name = name;
            Players = new Dictionary<string, Player>();
        }

        public void AddPlayer(Player player)
        {
            try
            {
                Players.Add(player.Nick, player);
            }
            catch (ArgumentException argumentException)
            {
                //TODO log and iform
            }
        }

        public void RemovePlayer(Player player)
        {
            Players.Remove(player.Nick);
        }
    }
}
