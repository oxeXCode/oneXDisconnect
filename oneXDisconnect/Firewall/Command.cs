using oneXDisconnect.Models.Enums;
using System.Diagnostics;

namespace oneXDisconnect.Firewall
{
    public class Command
    {
        private readonly Dictionary<FirewallActionEnum, ProcessStartInfo> firewallActionMap = new()
        {
            { FirewallActionEnum.Add, new() },
            { FirewallActionEnum.Delete, new() },
            { FirewallActionEnum.SetAllow, new() },
            { FirewallActionEnum.SetBlock, new() }
        };

        private string? name;
        public string? Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        private string? path;
        public string? Path
        {
            get => path;
            set => SetProperty(ref path, value);
        }

        private bool input;
        public bool Input
        {
            get => input;
            set => SetProperty(ref input, value);
        }

        private bool output;
        public bool Output
        {
            get => output;
            set => SetProperty(ref output, value);
        }

        public bool isAllow = true;

        private void SetProperty<T>(ref T field, T value)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return;

            field = value;
            Update();
        }

        public Command(string name, string path, bool input, bool output)
        {
            Name = name;
            Path = path;
            Input = input;
            Output = output;
        }

        private void Update()
        {
            if (string.IsNullOrEmpty(name) ||
                string.IsNullOrEmpty(path)) return;

            var commandsAdd = new List<string>();
            var commandsAllow = new List<string>();
            var commandsBlock = new List<string>();

            string commandDel = $"netsh advfirewall firewall delete rule name=\"{name}\"";

            if (input)
            {
                commandsAdd.Add($"netsh advfirewall firewall add rule name=\"{name}\" dir=in action=allow program=\"{path}\"");
                commandsAllow.Add($"netsh advfirewall firewall set rule name=\"{name}\" dir=in new action=allow");
                commandsBlock.Add($"netsh advfirewall firewall set rule name=\"{name}\" dir=in new action=block");
            }

            if (output)
            {
                commandsAdd.Add($"netsh advfirewall firewall add rule name=\"{name}\" dir=out action=allow program=\"{path}\"");
                commandsAllow.Add($"netsh advfirewall firewall set rule name=\"{name}\" dir=out new action=allow");
                commandsBlock.Add($"netsh advfirewall firewall set rule name=\"{name}\" dir=out new action=block");
            }

            firewallActionMap[FirewallActionEnum.Delete] = CreateProcessStartInfo(commandDel);
            firewallActionMap[FirewallActionEnum.Add] = CreateProcessStartInfo(string.Join(" & ", commandsAdd));
            firewallActionMap[FirewallActionEnum.SetAllow] = CreateProcessStartInfo(string.Join(" & ", commandsAllow));
            firewallActionMap[FirewallActionEnum.SetBlock] = CreateProcessStartInfo(string.Join(" & ", commandsBlock));
        }

        private ProcessStartInfo CreateProcessStartInfo(string arguments) =>
            new()
            {
                UseShellExecute = false,
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = "cmd.exe",
                Arguments = $"/C {arguments}"
            };

        public async Task ExecuteCommandAsync(FirewallActionEnum action)
        {
            if (firewallActionMap.TryGetValue(action, out var command))
            {
                if (action == FirewallActionEnum.SetBlock)
                    isAllow = false;
                else
                    isAllow = true;

                using var process = new Process();
                process.StartInfo = command;
                await Task.Run(process.Start);
            }
        }
    }
}
