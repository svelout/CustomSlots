using Exiled.API.Interfaces;
using System.ComponentModel;

namespace CustomSlots
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;

        [Description("Разрешение на использование команды")]
        public string AccsesToCommandPermission { get; set; } = "KrisPrs";

        [Description("Стандартное количество слотов на вашем сервере")]
        public int DefaultCountSlots { get; set; } = 20;
    }
}
