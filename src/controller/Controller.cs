using System.Collections.Generic;
using System.Diagnostics;

namespace Principal
{
    class Controller : IController
    {
        //randon number declaration
        private readonly Random _random;
        private string _nameFile;
        private object _control;

        public Controller()
        {
            _random = new Random();
            _nameFile = "resultado.txt";
            _control = new Object();
        }

        //first task
        public void task1(string texto)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            string[] temp;
            int count = texto.Split('n').Length - 1;

            temp =
            new String[]
            { $"El Numero de Veces que aparace la letra 'n' son: {count} \n" };

            Console.WriteLine("El Numero de Veces que aparace la letra 'n' son: {0} \n", count);


            writeInFile(temp);

            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            Console.WriteLine("el tiempo de la tarea 1 es: {0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
        }

        //second task
        public void task2(string texto)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            List<String> sentences = new List<String>();
            String[] tempMsg;
            int start = 0;
            int position;

            do
            {
                position = texto.IndexOf('.', start);
                if (position >= 0)
                {
                    String tempSen = texto.Substring(start, position - start + 2);
                    Boolean isSentence = tempSen.Last() == ' ';
                    if (isSentence && tempSen.Length > 15)
                    {
                        sentences.Add(tempSen.Trim());
                    }
                    start = position + 1;
                }
            } while (position > 0);

            tempMsg =
            new String[]
            {$"El numero de oraciones con mas de 15 caracteres son: {sentences.Count()} \n"};

            Console.WriteLine($"El numero de oraciones con mas de 15 caracteres son: {sentences.Count()} \n");

            writeInFile(tempMsg);

            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            Console.WriteLine("el tiempo de la tarea 2 es: {0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
        }

        //third task
        public void task3(string texto)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            List<String> sentences = new List<String>();
            String[] tempMsg;
            int start = 0;
            int position;

            do
            {
                position = texto.IndexOf('.', start);
                if (position >= 0)
                {
                    String tempSen = texto.Substring(start, position - start + 2);
                    Boolean isSentence = tempSen.Last() == ' ';
                    if (!isSentence)
                    {
                        sentences.Add(tempSen.Trim());
                    }
                    start = position + 1;
                }
            } while (position > 0);

            tempMsg =
            new String[]
            {$"El numero de parrafos  son: {sentences.Count()} \n"};

            Console.WriteLine($"El numero de parrafos son: {sentences.Count()} \n");

            writeInFile(tempMsg);

            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            Console.WriteLine("el tiempo de la tarea 3 es: {0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
        }

        //four task
        public void task4(string texto)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();


            String[] tempMsg;
            texto = texto.Trim().Replace('n'.ToString(), String.Empty)
            .Replace('N'.ToString(), String.Empty);
            texto = new String((from c in texto
                                where char.IsLetter(c) || char.IsNumber(c)
                                select c
            ).ToArray());


            tempMsg =
           new String[]
           {$"El numero de caracteres alfanumericos son: {texto.Count()} \n"};

            Console.WriteLine($"El numero de caracteres alfanumericos son: {texto.Count()} \n");
            writeInFile(tempMsg);

            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            Console.WriteLine("el tiempo de la tarea 4 es: {0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
        }

        //function to write or create file "resultado.txt"
        public void writeInFile(string[] messages)
        {
            string path = Environment.CurrentDirectory + "/" + _nameFile;

            lock (_control)
            {
                if (!File.Exists(path))
                {
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        Thread.Sleep(100);
                        foreach (var item in messages)
                        {
                            sw.WriteLine(item);
                        }
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(path))
                    {
                        Thread.Sleep(100);
                        foreach (var item in messages)
                        {
                            sw.WriteLine(item);
                        }
                    }
                }
            }


        }


    }
}