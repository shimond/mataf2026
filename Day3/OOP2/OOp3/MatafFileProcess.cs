using System;
using System.Collections.Generic;
using System.Text;

namespace OOp3
{
    public class MatafFileProcess
    {
        public void Start()
        {
            BaseMatafFileReader reader = GetCurrentMatafReader();
            MatafRecord[] records = reader.GetFromFile("mataf.csv");

            foreach (var record in records)
            {

                Console.WriteLine($"CustomerId: {record.CustomerId}, EmployeeId: {record.EmployeeId}, Role: {record.Role}, Amount: {record.Amount}, Bonus: {record.Bonus}");
            }
        }

        private BaseMatafFileReader GetCurrentMatafReader()
        {
            return new MockMatafFileReader();
        }
    }
}
