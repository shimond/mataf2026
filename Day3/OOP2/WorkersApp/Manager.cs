using System;
using System.Collections.Generic;
using System.Text;

namespace WorkersApp
{
    public class Manager : SalariedEmployee
    {
        public double Bonus { get; set; }

        public override double GetCalculatedSalary()
        {
            //return MonthlySalary + Bonus;
            return base.GetCalculatedSalary() + Bonus;
        }
    }
}
