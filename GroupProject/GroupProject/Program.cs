//5, 9, 3, 6
using System;
using System.IO;
using System.Threading;

namespace GroupProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            string job = "IT Support Person";
            StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + @"\ITSupportPerson.txt");
            string[] questions = sr.ReadLine().Split(','); //This will give us all our questions in an array
            Intro(job);

            do
            {
                Questions(questions);
            } while (true);
        }

        static void Intro(string job) // Does the introductory sequence
        {
            Random rand = new Random();
            string[] script = { "Hi, Thank you for coming in", $"I can see here you are applying for the IT Support Person position", "So lets get started" };
            Face();
            Console.Write("                             ");
            foreach (string sentence in script)
            {
                foreach (char letter in sentence)
                {
                    Console.Write(letter);
                    Thread.Sleep(rand.Next(30, 150)); //Changes the speed that letters appear to make it seem like a old school game
                }
                Thread.Sleep(1500);
                Console.Clear();
                Face();
                Console.Write("                     ");
            }
        }

        static void Face() //Face method to easily be called to print face on console
        {
            Console.WriteLine("                                XXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            Console.WriteLine("                              XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            Console.WriteLine("                             XXXXXXXXXXXXXXXXXX         XXXXXXXX");
            Console.WriteLine("                            XXXXXXXXXXXXXXXX              XXXXXXX");
            Console.WriteLine("                            XXXXXXXXXXXXX                   XXXXX");
            Console.WriteLine("                             XXX     _________ _________     XXX");
            Console.WriteLine("                              XX    I  _xxxxx I xxxxx_  I    XX  ");
            Console.WriteLine("                             ( X----I         I         I----X ) ");
            Console.WriteLine("                            ( +I    I      00 I 00      I    I+ )");
            Console.WriteLine("                             ( I    I    __0  I  0__    I    I )");
            Console.WriteLine(@"                              (I    I______ /   \_______I    I)");
            Console.WriteLine("                               I           ( ___ )           I");
            Console.WriteLine("                               I    _  :::::::::::::::  _    i");
            Console.WriteLine(@"                                \    \___ ::::::::: ___/    /");
            Console.WriteLine(@"                                \_      \_________/      _/");
            Console.WriteLine(@"                                   \        \___,        /");
            Console.WriteLine(@"                                     \                 /");
            Console.WriteLine(@"                                      |\             /|");
            Console.WriteLine(@"                                      |  \_________/  |");
            Console.WriteLine("###############################################################################################");
        }

        static void Questions(string[] questions)
        {
            Random rand = new Random();
            string[] reply;
            string[] fileText = File.ReadAllLines(Directory.GetCurrentDirectory().ToString() + @"\ResponseCheck.txt");
            string[] yes = fileText[0].Split(',');
            string[] maybe = fileText[1].Split(',');
            string[] no = fileText[2].Split(',');

            int positiveWords = 0;
            int negativeWords = 0;
            int maybeWords = 0;

            bool unknown = false;

            foreach (string question in questions)
            {
                foreach (char letter in question)
                {
                    Console.Write(letter);
                    Thread.Sleep(rand.Next(30, 150));
                }
            }

            Console.Write("\n                     ");

            reply = Console.ReadLine().ToLower().Trim().Split(' ');

            foreach (string word in reply)
            {
                foreach (string check in yes)
                {
                    if (word == check)
                    {
                        positiveWords++;
                    }
                }
                foreach (string check in no)
                {
                    if (word == check)
                    {
                        negativeWords++;
                    }
                }
                foreach (string check in maybe)
                {
                    if (word == check)
                    {
                        maybeWords++;
                    }
                }
            }

            if ((positiveWords == 0) && (negativeWords == 0) && (maybeWords == 0))
            {
                unknown = true;
            }

            if (positiveWords > 0)
            {
                Console.WriteLine("POSITIVE");
            }

            if (negativeWords > 0)
            {
                Console.WriteLine("NEGATIVE");
            }

            if (maybeWords > 0)
            {
                Console.WriteLine("MAYBE");
            }

            Console.Clear();
            Face();
        }

        static void Confirmation()
        {

        }

        static void Denial()
        {

        }

        static void Maybe()
        {

        }

        static void Unknown()
        {

        }
    }
}
