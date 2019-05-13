//Group Name - 5, 9, 3, 6
using System;
using System.IO;
using System.Threading;

namespace GroupProject
{
    class Program
    {
        //Global variable intialization
        public static bool debug = false;
        public static string job = "IT Support Person", name = "", age = "", occu = "";
        public static string interviewChoice = "1";

        static void Main(string[] args) //Runs the main method
        {
            //Variable intialization
            Random rand = new Random();            
            string path = "";
            string path2 = "";
            bool repeat = false;

            //Debugging mode
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

            //Accessing questions from .txt file
            StreamReader sr = new StreamReader(Directory.GetCurrentDirectory() + path);
            string[] questions = sr.ReadLine().Split(','); //This will give us all our questions in an array
            StreamReader sr2 = new StreamReader(Directory.GetCurrentDirectory() + path2);
            string[] followQuestions = sr2.ReadLine().Split(','); //This will give us all our follow up questions in an array

            string[] answers = new string[questions.Length]; //Making a string array for the answers values
            string[] originalText = new string[questions.Length]; //Making a string array for the word answers
            string[] storage = new string[questions.Length]; //Making a string array for all of the word values
            string[] followAnswers = new string[questions.Length]; //Making a string array for the follow up answer values
            string[] followOriginalText = new string[questions.Length]; //Making a string array for the follow up word answers
            string[] followStorage = new string[questions.Length]; //Making a string array for the follow up word values

            //Runs the introduction if not debugging
            if (debug == false)
            {
                Intro();
            }

            //Inserts information from the introduction into questions
            questions[0] = questions[0].Insert(3, name + ", ");
            
            //Loops program infinitely
            do
            {
                Questions(questions, repeat, storage, answers, originalText, followQuestions, followAnswers, followOriginalText, followStorage);
                repeat = true;

            } while (true);
        }

        static void Intro() //Does the introductory sequence
        {
            Random rand = new Random();

            do
            {
                //Tells the user what they have entered is invalid
                if ((interviewChoice != "1") && (interviewChoice != "2") && (interviewChoice != "3"))
                {
                    Console.Write("\nInvalid Input - Please Enter 1, 2, or 3\n");
                }

                //Code to choose interviewer
                Console.Write("\nAI Interviewer\n\nThis interview is interactive to ensure you are most comfortable \nWe have a number of interviewers for you to choose from:\n\n1 - Dr Rakessh \n2 - Annabelle \n3 - Alien\n\nYour Choice: ");
                interviewChoice = Console.ReadLine();
                Console.Clear();

            } while ((interviewChoice != "1") && (interviewChoice != "2") && (interviewChoice != "3"));

            //Disscussion statement
            string[] script = { "Hi, Thank you for coming in", $"I can see here you are applying for the IT Support Person position", "So lets get started" };

            //Outputs a face
            Face();
            Console.Write("                             "); //Padding

            //Repeats for all the words in the script
            foreach (string sentence in script)
            {
                //Repeats for all the letters in each sentence
                foreach (char letter in sentence)
                {
                    //Writes out a letter in the sentence
                    Console.Write(letter);

                    //When not debugging
                    if (debug == false)
                    {
                        Thread.Sleep(rand.Next(30, 150)); //Changes the speed that letters appear to make it seem like a old school game
                    }
                }

                Thread.Sleep(1500); //Pauses program
                Console.Clear(); //Clears console
                Face(); //Outputs a face
                Console.Write("                     "); //Padding
            }

            //Gets user's name
            Console.Clear();
            Face();
            Console.Write("                     ");
            Console.WriteLine("What is your name?");
            Console.Write("                     ");
            name = Console.ReadLine();

            //Gets user's age
            Console.Clear();
            Face();
            Console.Write("                     ");
            Console.WriteLine("What is your age?");
            Console.Write("                     ");
            age = Console.ReadLine();

            //Gets user's occupation
            Console.Clear();
            Face();
            Console.Write("                     ");
            Console.WriteLine("What is your occupation?");
            Console.Write("                     ");
            occu = Console.ReadLine();

            Console.Clear();
        }
        
        static void Questions(string[] questions, bool repeat, string[] storage, string[] answers, string[] originalText, string[] followQuestions, string[] followAnswers, string[] followOriginalText, string[] followStorage) //Main program - asks all of the interview questions
        {
            //Response check array initialization
            string[] fileText = File.ReadAllLines(Directory.GetCurrentDirectory().ToString() + @"\ResponseCheck.txt"); //Gets all known responses

            //Splits responses into yes maybe or no
            string[] yes = fileText[0].Split(',');
            string[] maybe = fileText[2].Split(',');
            string[] no = fileText[1].Split(',');
            
            //Other variables and arrays
            Random rand = new Random();
            int count = 0;

            string[] reply = new string[questions.Length];
            string[] followReply = new string[followQuestions.Length];

            //Outputs the face to the console
            Face();

            //Repeats for each main question in the list of questions
            foreach (string question in questions)
            {
                //Outputs the face to the console
                Console.Clear();
                Face();
                Console.Write("                     "); //Padding

                //Repeats for each character in the question sentence
                foreach (char letter in question)
                {
                    //Outputs the letter
                    Console.Write(letter);
                    Thread.Sleep(rand.Next(30, 100));
                }

                //Padding
                Console.WriteLine();
                Console.Write("                     ");

                //Recieves and formats answer
                reply[count] = Console.ReadLine().ToLower();

                //If the code hasn't been through once, store original reply text
                if (repeat == false)
                {
                    originalText[count] = reply[count];
                }

                //Check the overall meaning of the reply
                Identify(reply, yes, maybe, no, answers, count);

                //If the code is repeating
                if (repeat == true)
                {
                    //If the code detects a conflict where the previous answer does not match the current answer
                    if ((storage[count] != answers[count]) && (answers[count] != "unknown"))
                    {
                        //Outputs the face
                        Console.Clear();
                        Face();

                        //Tell the user what the conflict was and get store final answer
                        Console.WriteLine($"You answered {reply[count]}, but last time you answered {originalText[count]}");
                        Console.WriteLine("What is your answer?");

                        reply[count] = Console.ReadLine().ToLower().Trim();
                        originalText[count] = reply[count];

                        //Indentify the overall meaning of the final reply
                        Identify(reply, yes, maybe, no, answers, count);
                    }
                }

                //If the answer means yes go to follow up question
                if (answers[count] == "yes")
                {
                    FollowUp(repeat, followQuestions, followStorage, followAnswers, followOriginalText, followReply, count);
                }

                //If debugging output debug info
                if (debug == true)
                {
                    Console.WriteLine($"Repeat: {repeat}");
                    Console.WriteLine($"Answered: {answers[count]}");
                    Console.WriteLine($"Last Answer: {storage[count]}");
                }

                //Question count
                count++;

                //If the end of the questions is reached
                if (count == questions.Length)
                {
                    //Store all of the first rounds answers
                    Array.Copy(answers, storage, reply.Length);
                    count = 0; //Reset question number
                }
            }
        }

        static void FollowUp(bool repeat, string[] followQuestions, string[] followStorage, string[] followAnswers, string[] followOriginalText, string[] followReply, int count) //Asks follow up questions
        {
            //Response check array initialization
            string[] fileText = File.ReadAllLines(Directory.GetCurrentDirectory().ToString() + @"\ResponseCheck.txt");

            //Splits responses into yes maybe or no
            string[] yes = fileText[0].Split(',');
            string[] maybe = fileText[2].Split(',');
            string[] no = fileText[1].Split(',');

            //Other variables and arrays
            Random rand = new Random();

            //Outputs face
            Console.Clear();
            Face();
            Console.Write("                     "); //Padding

            //Repeat for each letter in the question sentence
            foreach (char letter in followQuestions[count])
            {
                //Output each letter
                Console.Write(letter);
                Thread.Sleep(rand.Next(30, 100));
            }

            //Padding
            Console.WriteLine();
            Console.Write("                     ");

            //Get user's reply, format it and store it
            followReply[count] = Console.ReadLine().ToLower();

            //If the code has not repeated
            if (repeat == false)
            {
                //Store follow up reply
                followOriginalText[count] = followReply[count];
            }

            //Check overall meaning of the reply
            Identify(followReply, yes, maybe, no, followAnswers, count);

            //If the code is repeating
            if (repeat == true)
            {
                //If there is a conflict with a past answer
                if ((followStorage[count] != followAnswers[count]) && (followAnswers[count] != "unknown"))
                {
                    //Output face
                    Console.Clear();
                    Face();

                    //Tell the user about the conflict, then format and store a final response
                    Console.WriteLine($"You answered {followReply[count]}, but last time you answered {followOriginalText[count]}");
                    Console.WriteLine("What is your answer?");

                    followReply[count] = Console.ReadLine().ToLower().Trim();
                    followOriginalText[count] = followReply[count];
                }
            }

            //If debugging display additional debug info
            if (debug == true)
            {
                Console.WriteLine($"Repeat: {repeat}");
                Console.WriteLine($"Answered: {followAnswers[count]}");
                Console.WriteLine($"Last Answer: {followStorage[count]}");
            }

            //If the program is about to repeat
            if (count == followQuestions.Length)
            {
                //Store all follow up answers
                Array.Copy(followAnswers, followStorage, followReply.Length);
            }
        }

        static void Identify(string[] reply, string[] yes, string[] maybe, string[] no, string[] answers, int count) //Identifies the overall meaning of a sentence based on the words used
        {
            //Variable initialization
            bool unknown = false;
            bool usedNo = false;

            int goodCount = 0;
            int badCount = 0;
            int neutralCount = 0;
            int meaning = 1;

            //Array initialization
            int[] meaningArray = new int[reply.Length];
            string[] replyAsWords = reply[count].Split(' ');
            
            //Repeat for each word in the reply
            foreach (string word in replyAsWords)
            {
                //Exception for when 'No' is used
                if (word == "no")
                {
                    usedNo = true;
                }

                //Repeat for all of the positive words
                foreach (string check in yes)
                {
                    //If the word is positive
                    if (word == check)
                    {
                        //Increase the positive words count
                        goodCount++;
                    }
                }
                //Repeat for all of the negative words
                foreach (string check in no)
                {
                    //If the word is negative
                    if (word == check)
                    {
                        //Increase the negative words count
                        badCount++;
                    }
                }
                //Repeat for all of the maybe words
                foreach (string check in maybe)
                {
                    //If the word is maybe
                    if (word == check)
                    {
                        //Increase the maybe words count
                        neutralCount++;
                    }
                }
            }

            //Every time a negative word is in the word, reverse it's meaning
            for (int i = 0; i < badCount; i++)
            {
                meaning *= -1;
            }
            //As soon as one maybe word is found, make the meaning maybe
            if (neutralCount > 0)
            {
                meaning = 0;
            }
            //Special case for if 'No' is used
            if ((usedNo == true) && (badCount == 0))
            {
                badCount = 1;
                meaning = -1;
            }
            //If no identification words are found make the meaning unknown
            if ((goodCount == 0) && (badCount == 0) && (neutralCount == 0))
            {
                unknown = true;
            }
            //If the meaning is not unknown
            if (unknown == false)
            {
                //If the meaning is positive store 'yes'
                if (meaning == 1)
                {
                    answers[count] = "yes";
                }
                //If the meaning is negative store 'no'
                if (meaning == -1)
                {
                    answers[count] = "no";
                }
                //If the meaning is maybe store 'maybe'
                if (meaning == 0)
                {
                    answers[count] = "maybe";
                }
            }
            else
            {
                //Store 'unknown'
                answers[count] = "unknown";
            }
        }

        static void Face() //Face method - outputs a face to the console
        {
            Console.Clear();
            
            //Outputs the user's chosen interviewer
            switch (interviewChoice)
            {
                //Dr Rakessh
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

                //Annabelle
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

                //Alien
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
    }
}
