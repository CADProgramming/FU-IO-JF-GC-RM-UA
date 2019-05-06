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
            string job = "IT Support Person", name = "", age = "", occu = "";
            StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + @"\ITSupportPerson.txt");
            string[] questions = sr.ReadLine().Split(','); //This will give us all our questions in an array
            string[] answers = new string[questions.Length];
            Intro(job, name, age, occu);

            do
            {
                Questions(sr);
            } while (true);
        }

        static void Intro(string job, string name, string age, string occu) // Does the introductory sequence
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
            
            Console.Clear();
            Face();
            Console.Write("                     "); // Gets Name
            Console.WriteLine("What is your name?");
            Console.Write("                     ");
            name = Console.ReadLine();

            Console.Clear();
            Face();
            Console.Write("                     "); // Gets Age
            Console.WriteLine("What is your age?");
            Console.Write("                     ");
            age = Console.ReadLine();

            Console.Clear();
            Face();
            Console.Write("                     "); // Gets Occupation
            Console.WriteLine("What is your occupation?");
            Console.Write("                     ");
            occu = Console.ReadLine();
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

        static void Questions(StreamReader sr)
        {
            Random rand = new Random();
            string reply;
            string[] yes = { "yes", "sure", "okay", "definitely" };//Confirming answers
            string[] maybe = { "maybe" };
            string[] no = { "no", "never", "nope", "can't" };//Denying answers            foreach (string sentence in questions)
            string sentence = "test";

            foreach (char letter in sentence)
            {
                Console.Write(letter);
                Thread.Sleep(rand.Next(30, 150));
            }
            Console.Write("\n                     ");

            reply = Console.ReadLine().ToLower(); // Stores reply to than be called to that questions own method

            if (Array.BinarySearch(yes, reply) >= 0)//Exists in array
            {
                Confirmation();//Passes in question number for appropriate follow up questions
            }
            else if (Array.BinarySearch(no, reply) >= 0)
            {
                Denial();//Passes in question number for appropriate follow up questions
            }
            else if (Array.BinarySearch(maybe, reply) >= 0)
            {
                Maybe();//Passes in question number for appropriate follow up questions
            }
            else
            {
                Unknown();//Passes in question number for appropriate generic responses
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
