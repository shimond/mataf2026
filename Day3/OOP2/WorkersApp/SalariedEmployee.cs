using System;
using System.Collections.Generic;
using System.Text;

namespace WorkersApp
{
    public class SalariedEmployee : Worker
    {
        public double MonthlySalary { get; set; }

        public override double GetCalculatedSalary()
        {
            return MonthlySalary;
        }
    }
}
