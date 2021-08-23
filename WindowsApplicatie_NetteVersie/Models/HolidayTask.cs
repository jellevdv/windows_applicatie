using System;

namespace WindowsApplicatie_NetteVersie.Models
{
    public class HolidayTask
    {
        public string Description { get; set; }
        public Boolean Checked { get; set; }

        public HolidayTask(string d, Boolean c)
        {
            Description = d;
            Checked = c;
        }

    }
}
