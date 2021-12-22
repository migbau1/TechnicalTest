using System.Collections.Generic;
using System.Diagnostics;

namespace Principal
{
    class Controller : IController
    {
        private string _nameFile;
        private object _control;

        public Controller()
        {
            _nameFile = "resultado.txt";
            _control = new Object();
        }

        //Letter Counter N
        public void LetterCounterN(string texto)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            int count = texto.Split('n').Length - 1;

            Console.WriteLine("El Numero de Veces que aparace la letra 'n' son: {0} \n", count);

            writeInFile($"El Numero de Veces que aparace la letra 'n' son: {count} \n");

            stopWatch.Stop();

            TimeSpan ts = stopWatch.Elapsed;

            string time = String.Format("el tiempo de la tarea 1 es: {0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);

            Console.WriteLine(time);
            writeInFile(time);

        }

        //sentences Counter
        public void sentencesCounter(string texto)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            List<String> sentences = new List<String>();
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

            Console.WriteLine(
                $"El numero de oraciones con mas de 15 caracteres son: {sentences.Count()} \n");

            writeInFile($"El numero de oraciones con mas de 15 caracteres son: {sentences.Count()} \n");

            stopWatch.Stop();

            TimeSpan ts = stopWatch.Elapsed;

            string time = String.Format("el tiempo de la tarea 2 es: {0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);

            Console.WriteLine(time);
            writeInFile(time);
        }

        //paragraph Counter
        public void paragraphCounter(string texto)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            List<String> sentences = new List<String>();
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

            Console.WriteLine($"El numero de parrafos son: {sentences.Count()} \n");
            writeInFile($"El numero de parrafos  son: {sentences.Count()} \n");

            stopWatch.Stop();

            TimeSpan ts = stopWatch.Elapsed;

            string time = String.Format("el tiempo de la tarea 3 es: {0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);

            Console.WriteLine(time);
            writeInFile(time);
        }

        //alphanumeric Counter
        public void alphanumericCounter(string texto)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            texto = texto.Trim().Replace('n'.ToString(), String.Empty)
            .Replace('N'.ToString(), String.Empty);
            texto = new String((from c in texto
                                where char.IsLetter(c) || char.IsNumber(c)
                                select c
            ).ToArray());


            Console.WriteLine($"El numero de caracteres alfanumericos son: {texto.Count()} \n");
            writeInFile($"El numero de caracteres alfanumericos son: {texto.Count()} \n");

            stopWatch.Stop();

            TimeSpan ts = stopWatch.Elapsed;

            string time = String.Format("el tiempo de la tarea 4 es: {0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);

            Console.WriteLine(time);
            writeInFile(time);

        }

        //function to write or create file "resultado.txt"
        public void writeInFile(string message)
        {
            string path = Environment.CurrentDirectory + "/" + _nameFile;


            lock (_control)
            {
                if (!File.Exists(path))
                {
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        Thread.Sleep(100);
                        sw.WriteLine(message);
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(path))
                    {
                        Thread.Sleep(100);
                        sw.WriteLine(message);
                    }
                }
            }


        }


    }
}