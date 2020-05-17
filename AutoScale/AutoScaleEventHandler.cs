using System;
using System.Collections.Generic;
using EXILED;
using EXILED.Extensions;
using MEC;

namespace TinyMe
{
    public class AutoScaleEventHandler
    {
        HashSet<String> FirstJoinedPlayers = new HashSet<String>();
        public void RunWhenRoundStarts()
        {
            foreach (ReferenceHub Player in Player.GetHubs())
            {
                Map.Broadcast($"Everyone who joined has their playermodel scale set to {AutoScaleMeMain.ScaleValue}x!", 5);
                FirstJoinedPlayers.Add(Player.characterClassManager.UserId);
                Player.SetScale(AutoScaleMeMain.ScaleValue);
            }
        }

        public void RunWhenRoundEnds()
        {
            FirstJoinedPlayers.Clear();
        }

        public void RunWhenPlayerJoins(PlayerJoinEvent PlayerJoin)
        {
            if (FirstJoinedPlayers.Contains(PlayerJoin.Player.characterClassManager.UserId))
            {
                PlayerJoin.Player.Broadcast(5, $"Your playermodel scale was set to {AutoScaleMeMain.ScaleValue}x!", false);
                PlayerJoin.Player.SetScale(AutoScaleMeMain.ScaleValue);
            }
        }
    }
}
