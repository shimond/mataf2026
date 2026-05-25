using System.Net.Quic;

namespace Before
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Enter len to filter");
            //int filterLength = int.Parse(Console.ReadLine());
            //string[] names = { "Shimon", "MOshe" };
            //var result = names.Where(delegate(string name) { return name.Length == filterLength; }).ToList();
            //var result2 = names.Where(name => name.Length == filterLength).ToList();
            //string [] result3 = names.Where(CallbackByLengthIs3).ToArray();

            //Action a = new Action(TestAction);
            //Action a = new Action(TestAction);
            //Action a = TestAction;
            //Action a1 = () => { };

            List<Action> actions = new List<Action>();
            string[] dirs = { "c:\\test", "c:\\matafFiles", "c:\\MatafRes" };
            for (int i = 0; i < dirs.Length; i++)
            {
                var currentFolder = dirs[i];
                actions.Add(() =>
                {
                    Console.WriteLine("Start Process : " + currentFolder);
                    Task.Delay(4000).Wait();
                    Console.WriteLine("End Process : " + currentFolder);
                });
            }

            for (int indexInArray = 0; indexInArray < dirs.Length; indexInArray++)
            {
                var currentAction = actions[indexInArray];
                currentAction();
            }
        }

        static void TestEti()
        {
            Console.WriteLine("WOW");
        }










        static void TestShimon() { }

        static void TestAction()
        {
            Console.WriteLine("ACTION!");
        }

        static bool CallbackByLengthIs3(string name)
        {
            if (name.Length == 3) return true;

            return false;
        }

    }
}
