using System;

namespace Iswenzz.AION.DBParser.Buttons
{
    public class ButtonNpc : Button
    {
        public ButtonNpc(string name, string url = "", bool stop = false) : base(name, url, stop) { }

        public override void Execute() => new NpcParser(Name, Url);
    }
}
