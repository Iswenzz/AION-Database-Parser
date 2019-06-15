using System;

namespace Iswenzz.AION.DBParser.Buttons
{
    public class ButtonNpcGrade : ButtonNpc
    {
        public ButtonNpcGrade(string name, string url = "", bool stop = false) : base(name, url, stop)
        {
            Name = name;
            Url = url;
            Stop = stop;
        }
    }
}
