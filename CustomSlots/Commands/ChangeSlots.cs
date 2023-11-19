using CommandSystem;
using CustomSlots.Enums;
using CustomSlots.Features;
using Exiled.API.Features;
using Exiled.Permissions.Extensions;
using System;

namespace CustomSlots.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class ChangeSlots : ICommand, IUsageProvider
    {
        public string Command { get; } = "changeslots";

        public string[] Aliases { get; } = new[] { "cs" };

        public string Description { get; } = "Меняет количество слотов сервера на один раунд";

        public string[] Usage { get; } = new[] { "Количество слотов которые будут в следующем раунде" };

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission(Plugin.Instance.Config.AccsesToCommandPermission))
            {
                response = "У вас недостаточно прав для использования данной команды";
                return false;
            }
            if (Slots.ServerSlotsNewValue > -1 || ServerStatus.IsChanged)
            {
                response = "Вы уже установили временное количество слотов на следующий раунд!\nПожалуйста дождитесь его окончания";
                return false;
            }
            switch (ServerStatus.RoundStatus)
            {
                case RoundStatus.None:
                    response = "На данный момент команда недоступна";
                    return false;
                case RoundStatus.Lobby:
                    response = $"В этом раунде максимальное количество слотов сервера будут изменены с {Server.MaxPlayerCount} на {arguments.At(0)}";
                    ServerStatus.IsChanged = true;
                    Slots.ServerSlotsNewValue = Convert.ToInt32(arguments.At(0));
                    Slots.ChangeToNew();
                    return true;
                default:
                    response = $"В следующем раунде максимальное количество слотов сервера будут изменены с {Server.MaxPlayerCount} на {arguments.At(0)}";
                    Slots.ServerSlotsNewValue = Convert.ToInt32(arguments.At(0));
                    ServerStatus.IsChanged = true;
                    return true;
            }
        }
    }
}
