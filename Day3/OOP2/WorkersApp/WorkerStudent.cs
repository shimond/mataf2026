using System;
using System.Collections.Generic;
using System.Text;

namespace WorkersApp
{
    public class WorkerStudent : Student, IWorkerable
    {
        public double PricePerDay { get; set; }
        public double Days { get; set; }

        public double GetCalculatedSalary()
        {
            return PricePerDay * Days;
        }
    }
}
