//5, 9, 3, 6
using System;
using System.IO;
using System.Threading;

namespace GroupProject
{
    class Program
    {
        public static bool debug = true;
        public static int interviewChoice = 0;
        static void Main(string[] args)
        {
            Random rand = new Random();
            string job = "IT Support Person", name = "", age = "", occu = "";
            string path = "";
            if (debug == false)
            {
                path = @"\ITSupportPerson.txt";
            }
            else
            {
                path = @"\ITSupportPersonDebug.txt";
            }
            StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + path);
            string[] questions = sr.ReadLine().Split(','); //This will give us all our questions in an array
            string[] answers = new string[questions.Length];
            string[] originalText = new string[questions.Length];
            if (debug == false)
            {
                Intro(job, name, age, occu);
            }

            //questions[5] = questions[5].Insert(15, name);

            bool repeat = false;
            string[] storage = new string[questions.Length];

            do
            {
                Questions(questions, repeat, storage, answers, originalText);
                repeat = true;
            } while (true);
        } // Main Method

        static void Intro(string job, string name, string age, string occu) // Does the introductory sequence
        {
            Random rand = new Random();
            Console.WriteLine("This interview is interactive to ensure you are most comfortable \n We have a number of interviewers for you to choose \n1 - Dr Rakessh \n2 - Annabelle \n3 - Alien");
            interviewChoice = Convert.ToInt32(Console.ReadLine());
            string[] script = { "Hi, Thank you for coming in", $"I can see here you are applying for the IT Support Person position", "So lets get started" };
            Face();
            Console.Write("                             ");
            foreach (string sentence in script)
            {
                foreach (char letter in sentence)
                {
                    Console.Write(letter);
                    if (debug == false)
                    {
                        Thread.Sleep(rand.Next(30, 150)); //Changes the speed that letters appear to make it seem like a old school game
                    }
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

            Console.Clear();
        }

        static void Face() //Face method to easily be called to print face on console
        {
            Console.Clear();
            switch (interviewChoice)
            {
                case 1:

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
                    break;
                case 2:

                    Console.WriteLine(@"                                    .&&&&&&&&&&&&&&.");
                    Console.WriteLine(@"                                 .&&&&&&&&&&&&&&&&&&&&.");
                    Console.WriteLine(@"                               .&&&&&&&&&&&&&&&&&&&&&&&&.");
                    Console.WriteLine(@"                              &&&&&&&&&&&&&&&&&&&&&&&&&&&&");
                    Console.WriteLine(@"                             &&&&&&&& &:&&:&&:&&:&&&&&&&&&&");
                    Console.WriteLine(@"                            &&&&&&&&:&'&''&&''&&' &:&&&&&&&&");
                    Console.WriteLine(@"                           .&&&&&& '((((((     ))))))' &&&&&&.");
                    Console.WriteLine(@"                           &&&&&& '(/````\     /````\)' &&&&&&");
                    Console.WriteLine(@"                           &&&&:' `\ (_) ) \ ( (_) /` ':&&&&");
                    Console.WriteLine(@"                           && ( :. ''''''   \ `````` .: ) &&");
                    Console.WriteLine(@"                           &&\ \:::.      ,__)     .:::/ /&&");
                    Console.WriteLine(@"                           '&&\ `:::               :::` /&&'");
                    Console.WriteLine(@"                            &&&`/\:`     .-.-.     `:/\`&&&");
                    Console.WriteLine(@"                           .&&&(  )    .'._,_.'.    (  ) &&&.");
                    Console.WriteLine(@"                           &&&&&&&&\    \` ` `/    /&&&&&&&&");
                    Console.WriteLine(@"                           &&&&&&&& &\   `---`    /&&&&&&&&&");
                    Console.WriteLine(@"                           &&&&&&&&&&`-._______.-'&&&&&&&&&&");
                    Console.WriteLine(@"                          &&&&&&&&&&&             &&&&&&&&&&&");
                    Console.WriteLine(@"                         &&&&&&&&&&'                '&&&&&&&&&");
                    Console.WriteLine("###############################################################################################");
                    break;
                case 3:
                    Console.WriteLine(@"                                          ______");
                    Console.WriteLine(@"                                         /_.  ._\");
                    Console.WriteLine(@"                                        (( \\// ))");
                    Console.WriteLine(@"                                         \\ \/ //");
                    Console.WriteLine(@"                                          \\/\//");
                    Console.WriteLine(@"                                     \\\  ( '' )  ///");
                    Console.WriteLine(@"                                      )))  \__/  (((");
                    Console.WriteLine(@"                                     (((.'__||__'.)))");
                    Console.WriteLine(@"                                      \\  )    (  //");
                    Console.WriteLine(@"                                       \\/.'  '.\//");
                    Console.WriteLine(@"                                        \/ |,,| \/");
                    Console.WriteLine(@"                                           |  |");
                    Console.WriteLine(@"                                           |  |");
                    Console.WriteLine(@"                                           //\\");
                    Console.WriteLine(@"                                          //  \\");
                    Console.WriteLine(@"                                         ||    ||");
                    Console.WriteLine(@"                                         ||    ||");
                    Console.WriteLine(@"                                         ||    ||");
                    Console.WriteLine(@"                                      ___))    ((___");
                    Console.WriteLine(@"                                     (____)    (____)");
                    Console.WriteLine("###############################################################################################");
                    break;
            }
        }
        
        static void Questions(string[] questions, bool repeat, string[] storage, string[] answers, string[] originalText)
        {
            string[] fileText = File.ReadAllLines(Directory.GetCurrentDirectory().ToString() + @"\ResponseCheck.txt");
            string[] yes = fileText[0].Split(',');
            string[] maybe = fileText[2].Split(',');
            string[] no = fileText[1].Split(',');
            
            Random rand = new Random();
            string[] reply = new string[questions.Length];
            Face();
            int count = 0;

            foreach (string question in questions)
            {
                Console.Clear();
                Face();
                Console.Write("                     ");
                foreach (char letter in question)
                {
                    Console.Write(letter);
                    Thread.Sleep(rand.Next(30, 100));
                }
                Console.WriteLine();
                Console.Write("                     ");
                reply[count] = Console.ReadLine().ToLower();

                if (repeat == false)
                {
                    originalText[count] = reply[count];
                }
                Identify(reply, yes, maybe, no, answers, count);

                if (repeat == true)
                {
                    if ((storage[count] != answers[count]) && (answers[count] != "unknown"))
                    {
                        Console.Clear();
                        Face();
                        Console.WriteLine($"You answered {reply[count]}, but last time you answered {originalText[count]}");
                        Console.WriteLine("What is your answer?");
                        reply[count] = Console.ReadLine().ToLower().Trim();
                        originalText[count] = reply[count];
                    }
                }

                if (debug == true)
                {
                    Console.WriteLine($"Repeat: {repeat}");
                    Console.WriteLine($"Answered: {answers[count]}");
                    Console.WriteLine($"Last Answer: {storage[count]}");
                }

                Thread.Sleep(2000);

                count++;
                if (count == questions.Length)
                {
                    Array.Copy(answers, storage, reply.Length);
                    count = 0;
                }
            }
        } // Asks questions

        static void Identify(string[] reply, string[] yes, string[] maybe, string[] no, string[] answers, int count)
        {
            bool unknown = false;
            int[] meaningArray = new int[reply.Length];
            int goodCount = 0;
            int badCount = 0;
            int neutralCount = 0;
            int meaning = 1;
            string[] replyAsWords = reply[count].Split(' ');
            bool usedNo = false;

            foreach (string word in replyAsWords)
            {
                if (word == "no")
                {
                    usedNo = true;
                }
                foreach (string check in yes)
                {
                    if (word == check)
                    {
                        goodCount++;
                    }
                }
                foreach (string check in no)
                {
                    if (word == check)
                    {
                        badCount++;
                    }
                }
                foreach (string check in maybe)
                {
                    if (word == check)
                    {
                        neutralCount++;
                    }
                }
            }

            for (int i = 0; i < badCount; i++)
            {
                meaning *= -1;
            }

            if (neutralCount > 0)
            {
                meaning = 0;
            }

            if ((usedNo == true) && (badCount == 0))
            {
                badCount = 1;
                meaning = -1;
            }

            if ((goodCount == 0) && (badCount == 0) && (neutralCount == 0))
            {
                unknown = true;
            }

            if (unknown == false)
            {
                if (meaning == 1)
                {
                    answers[count] = "yes";
                }

                if (meaning == -1)
                {
                    answers[count] = "no";
                }

                if (meaning == 0)
                {
                    answers[count] = "maybe";
                }
            }
            else
            {
                answers[count] = "unknown";
            }
        } // Identifies key words
    }
}
