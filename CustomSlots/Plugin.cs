using CustomSlots.Enums;
using Exiled.API.Features;
using Server = Exiled.Events.Handlers.Server;

namespace CustomSlots
{
    public class Plugin : Plugin<Config>
    {
        public override string Author => "SveloutDevelops";

        public override string Name => "CustomSlots";

        public override string Prefix => "custom_slots";

        public static Plugin Instance;
        private EventHandlers eh;

        public override void OnEnabled()
        {
            Instance = this;
            eh = new();
            Slots.ServerSlotsDefaultValue = Config.DefaultCountSlots;
            Server.WaitingForPlayers += eh.OnWaitingForPlayers;
            Server.RoundStarted += eh.OnRoundStarted;
            Server.RestartingRound += eh.OnRoundRestarting;

            base.OnEnabled();
        }
        public override void OnDisabled()
        {
            Slots.ServerSlotsDefaultValue = -1;
            Server.WaitingForPlayers -= eh.OnWaitingForPlayers;
            Server.RoundStarted -= eh.OnRoundStarted;
            Server.RestartingRound -= eh.OnRoundRestarting;
            eh = null;
            Instance = null;

            base.OnDisabled();
        }
    }
}
