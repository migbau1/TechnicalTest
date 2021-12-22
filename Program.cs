using System.Text;

namespace Principal
{
    class Program
    {
        static void Main(string[] args)
        {
            //Inject interface of controller
            IController tasks = new Controller();

            //path file for read
            string path = Environment.CurrentDirectory + "/donquijote.txt";

            //if file exist, clean the content
            if (File.Exists(Environment.CurrentDirectory + "/resultado.txt"))
            {
                File.WriteAllText(Environment.CurrentDirectory + "/resultado.txt",
                 String.Empty, Encoding.UTF8);
            }

            //Run all task in parallel with class System.Threading.Tasks.Parallel
            if (File.Exists(path))
            {
                //read file
                string txt = File.ReadAllText(path, Encoding.UTF8);

                //execute in parallel all tasks
                Parallel.Invoke(
                    () => tasks.LetterCounterN(txt),
                    () => tasks.sentencesCounter(txt),
                    () => tasks.paragraphCounter(txt),
                    () => tasks.alphanumericCounter(txt));
            }

        }
    }
}