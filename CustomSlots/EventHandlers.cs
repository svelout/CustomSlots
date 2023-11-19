using CustomSlots.Enums;
using CustomSlots.Features;
using Exiled.Events.EventArgs.Server;

namespace CustomSlots
{
    internal sealed class EventHandlers
    {
        public void OnWaitingForPlayers()
        {
            ServerStatus.RoundStatus = RoundStatus.Lobby;
            if (ServerStatus.IsChanged)
            {
                Slots.ChangeToNew();
                Slots.ServerSlotsNewValue = -1;
            }
            if (!ServerStatus.IsChanged)
                Slots.ChangeToDefault();
        }
        public void OnRoundStarted()
        {
            ServerStatus.RoundStatus = RoundStatus.Started;
            if (ServerStatus.IsChanged) ServerStatus.IsChangingRound = true;
        }

        public void OnRoundRestarting()
        {
            ServerStatus.RoundStatus = RoundStatus.Ended;
            if (ServerStatus.IsChangingRound)
            {
                ServerStatus.IsChangingRound = false;
                ServerStatus.IsChanged = false;
            }
        }
    }
}
