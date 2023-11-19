using CustomSlots.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomSlots.Features
{
    internal static class ServerStatus
    {
        internal static RoundStatus RoundStatus { get; set; } = RoundStatus.None;

        public static bool IsChangingRound = false;
        public static bool IsChanged = false;

    }
}
