using System;
using System.Collections.Generic;
using System.Text;

namespace WorkersApp
{
    public interface IWorkerable
    {
        double GetCalculatedSalary();
    }

    public abstract class Worker : Person, IWorkerable
    {
        public string Tz { get; set; }
        public abstract double GetCalculatedSalary();
    }
}
