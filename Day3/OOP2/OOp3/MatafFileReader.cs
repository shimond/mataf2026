using System;
using System.Collections.Generic;
using System.Text;

namespace OOp3
{
    public abstract class BaseMatafFileReader
    {
        public abstract MatafRecord[] GetFromFile(string fileName);
    }

    public class MockMataf2FileReader : BaseMatafFileReader
    {
        public override MatafRecord[] GetFromFile(string fileName)
        {
            return new MatafRecord[]
            {
                new MatafRecord { CustomerId = 4, EmployeeId = 101, Role = "Developer", Amount = 1000, Bonus = 100 },
                new MatafRecord { CustomerId = 5, EmployeeId = 102, Role = "Developer", Amount = 800, Bonus = 80 },
                new MatafRecord { CustomerId = 6, EmployeeId = 103, Role = "Developer", Amount = 600, Bonus = 60 }
            };
        }
    }


    public class MockMatafFileReader : BaseMatafFileReader
    {
        public override MatafRecord[] GetFromFile(string fileName)
        {
            return new MatafRecord[]
            {
                new MatafRecord { CustomerId = 1, EmployeeId = 101, Role = "Manager", Amount = 1000, Bonus = 100 },
                new MatafRecord { CustomerId = 2, EmployeeId = 102, Role = "Developer", Amount = 800, Bonus = 80 },
                new MatafRecord { CustomerId = 3, EmployeeId = 103, Role = "Tester", Amount = 600, Bonus = 60 }
            };
        }
    }
}
