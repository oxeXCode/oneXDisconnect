namespace oneXDisconnect.Models.View
{

    public class Rootobject
    {
        public Rootobject()
        {
            rule = new()
            {
                chkIn = true,
                chkOut = true
            };
            hookType = new()
            {
                holderTimer = 5
            };
            device = new() 
            {
                keyboard = null,
                mouse = null,
                controller = null
            };
            settings = new()
            {
                pollingFrequency = 5
            };
        }

        public Rule rule { get; set; }
        public Hooktype hookType { get; set; }
        public Device device { get; set; }
        public Settings settings { get; set; }
    }

    public class Settings
    {
        public int pollingFrequency { get; set; }
    }

    public class Rule
    {
        public string path { get; set; }
        public bool chkIn { get; set; }
        public bool chkOut { get; set; }
    }

    public class Hooktype
    {
        public int type { get; set; }
        public int holderTimer { get; set; }
    }

    public class Device
    {
        public int type { get; set; }
        public int? keyboard { get; set; }
        public int? mouse { get; set; }
        public int? controller { get; set; }
    }

}
