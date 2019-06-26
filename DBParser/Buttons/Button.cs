using System;

namespace Iswenzz.AION.DBParser.Buttons
{
    public partial class Button
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public bool Stop { get; set; }

        public Button(string name, string url = "", bool stop = false)
        {
            Name = name;
            Url = url;
            Stop = stop;
        }

        public virtual void Execute() { }
    }
}
