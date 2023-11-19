using Exiled.API.Features;

namespace CustomSlots
{
    internal static class Slots
    {
        public static int ServerSlotsDefaultValue { get; set; }

        public static int ServerSlotsNewValue { get; set; } = -1;

        public static int ServerSlots
        {
            get
            {
                return Server.MaxPlayerCount;
            }
            private set
            {
                Server.MaxPlayerCount = value;
            }
        }
        public static void ChangeToNew() 
        {
            ServerSlots = ServerSlotsNewValue;
            ServerSlotsNewValue = -1;
        }

        public static void ChangeToDefault() => ServerSlots = ServerSlotsDefaultValue;
    }
}
