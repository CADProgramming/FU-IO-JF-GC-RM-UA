﻿//5, 9, 3, 6
using System;
using System.IO;
using System.Threading;

namespace GroupProject
{
    class Program
    {
        // global variable intialization
        public static bool debug = false;
        public static string job = "IT Support Person", name = "", age = "", occu = "";
        public static string interviewChoice = "";
        static void Main(string[] args)
        {
            // variable intialization
            Random rand = new Random();            
            string path = "";
            string path2 = "";
            //debugging mode
            if (debug == false)
            {
                path = @"\ITSupportPerson.txt";
                path2 = @"\ITSupportPersonFollowUp.txt";
            }
            else
            {
                path = @"\ITSupportPersonDebug.txt";
                path2 = @"\ITSupportPersonFollowUp.txt";
            }
            //accessing questions from .txt file
            StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + path);
            string[] questions = sr.ReadLine().Split(','); //This will give us all our questions in an array
            StreamReader sr2 = new StreamReader(Directory.GetCurrentDirectory() + path2);
            string[] followQuestions = sr2.ReadLine().Split(','); //This will give us all our questions in an array
            string[] answers = new string[questions.Length];//Making a string for the answers values
            string[] originalText = new string[questions.Length];//making a string for the word answers
            string[] followAnswers = new string[questions.Length];
            string[] followOriginalText = new string[questions.Length];
            string[] followStorage = new string[questions.Length];
            //runs the introduction
            if (debug == false)
            {
                Intro();
            }
            //deciding if all questions have been asked
            bool repeat = false;
            //stores intial answers so they arent overwritten
            string[] storage = new string[questions.Length];

            questions[0] = questions[0].Insert(3, name + ", ");
            
            //loops probram
            do
            {
                Questions(questions, repeat, storage, answers, originalText, followQuestions, followAnswers, followOriginalText, followStorage);
                repeat = true;
            } while (true);
        } // Main Method

        static void Intro() // Does the introductory sequence
        {
            Random rand = new Random();
            do
            {
                Console.Clear();
                //code to choose interviewer
                Console.WriteLine("This interview is interactive to ensure you are most comfortable \n We have a number of interviewers for you to choose \n1 - Dr Rakessh \n2 - Annabelle \n3 - Alien");
                interviewChoice = Console.ReadLine();
            } while ((interviewChoice != "1") && (interviewChoice != "2") && (interviewChoice != "3"));
            string[] script = { "Hi, Thank you for coming in", $"I can see here you are applying for the IT Support Person position", "So lets get started" };
            //runs face method
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
                case "1":

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
                case "2":

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
                case "3":
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
        
        static void Questions(string[] questions, bool repeat, string[] storage, string[] answers, string[] originalText, string[] followQuestions, string[] followAnswers, string[] followOriginalText, string[] followStorage)
        {
            string[] fileText = File.ReadAllLines(Directory.GetCurrentDirectory().ToString() + @"\ResponseCheck.txt");
            string[] yes = fileText[0].Split(',');
            string[] maybe = fileText[2].Split(',');
            string[] no = fileText[1].Split(',');
            
            Random rand = new Random();
            string[] reply = new string[questions.Length];
            string[] followReply = new string[followQuestions.Length];
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
                        Identify(reply, yes, maybe, no, answers, count);
                    }
                }

                if (answers[count] == "yes")
                {
                    FollowUp(repeat, followQuestions, followStorage, followAnswers, followOriginalText, followReply, count);
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
        }

        static void FollowUp(bool repeat, string[] followQuestions, string[] followStorage, string[] followAnswers, string[] followOriginalText, string[] followReply, int count)
        {
            string[] fileText = File.ReadAllLines(Directory.GetCurrentDirectory().ToString() + @"\ResponseCheck.txt");
            string[] yes = fileText[0].Split(',');
            string[] maybe = fileText[2].Split(',');
            string[] no = fileText[1].Split(',');

            Random rand = new Random();

            Console.Clear();
            Face();
            Console.Write("                     ");
            foreach (char letter in followQuestions[count])
            {
                Console.Write(letter);
                Thread.Sleep(rand.Next(30, 100));
            }
            Console.WriteLine();
            Console.Write("                     ");
            followReply[count] = Console.ReadLine().ToLower();

            if (repeat == false)
            {
                followOriginalText[count] = followReply[count];
            }
            Identify(followReply, yes, maybe, no, followAnswers, count);

            if (repeat == true)
            {
                if ((followStorage[count] != followAnswers[count]) && (followAnswers[count] != "unknown"))
                {
                    Console.Clear();
                    Face();
                    Console.WriteLine($"You answered {followReply[count]}, but last time you answered {followOriginalText[count]}");
                    Console.WriteLine("What is your answer?");
                    followReply[count] = Console.ReadLine().ToLower().Trim();
                    followOriginalText[count] = followReply[count];
                }
            }

            if (debug == true)
            {
                Console.WriteLine($"Repeat: {repeat}");
                Console.WriteLine($"Answered: {followAnswers[count]}");
                Console.WriteLine($"Last Answer: {followStorage[count]}");
            }

            Thread.Sleep(1000);

            if (count == followQuestions.Length)
            {
                Array.Copy(followAnswers, followStorage, followReply.Length);
            }
        }

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
