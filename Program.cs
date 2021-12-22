using System.Text;

namespace Principal
{
    class Program
    {
        static void Main(string[] args)
        {
            //controller interface
            IController tasks = new Controller();

            //path file for read
            string path = Environment.CurrentDirectory + "/donquijote.txt";


            if (File.Exists(Environment.CurrentDirectory + "/resultado.txt"))
            {
                File.WriteAllText(Environment.CurrentDirectory + "/resultado.txt",
                 String.Empty, Encoding.UTF8);
            }

            if (File.Exists(path))
            {
                //read file
                string txt = File.ReadAllText(path, Encoding.UTF8);

                //execute in parallel all tasks
                Parallel.Invoke(
                    () => tasks.task1(txt),
                    () => tasks.task2(txt),
                    () => tasks.task3(txt),
                    () => tasks.task4(txt));
            }

        }
    }
}