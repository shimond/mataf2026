using System;
using System.Collections.Generic;
using System.Text;

namespace WorkersApp
{
    public class Freelancer : Worker
    {
        public double HourlyRate { get; set; }
        public int HoursWorked { get; set; }
        public override double GetCalculatedSalary()
        {
            return HourlyRate * HoursWorked;
        }
    }
}
