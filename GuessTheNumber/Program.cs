using System;

namespace GuessTheNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            //Random three digit-number
            int Min = 0;
            int Max = 9;
            int[] randomNumber = new int[3];

            //User
            int userNumber = 233;
            int life = 5;
            bool lose = false;


            Random randNum = new Random();
            for (int i = 0; i <randomNumber.Length ; i++)
            {

                randomNumber[i] = randNum.Next(Min, Max);
                Console.Write(randomNumber[i]);
            }
            Console.WriteLine();

            Console.WriteLine("Random number was generated successfully");

            //User Input
            while (life >= 0 && lose == false) {

                if (life > 0)
                {
                    do
                    {
                        Console.Write("Enter 3 digit number: ");

                        try
                        {
                            userNumber = Int32.Parse(Console.ReadLine());



                            if (userNumber < 100 || userNumber > 999)
                            {
                                Console.WriteLine("Please enter only 3 digit numbers!");
                                Console.WriteLine();
                            }
                            else
                            {
                                life--;
                                Console.WriteLine("Life left: " + life);
                                Console.WriteLine("User number is " + userNumber);
                            }
                        }
                        catch (Exception)
                        {
                            Console.WriteLine();
                            Console.WriteLine("This was not a number");
                            Console.WriteLine();
                        }
                    }
                    while (userNumber < 100 || userNumber > 999);
                }
                else if (life == 0)
                {
                    lose = true;
                    Console.WriteLine();
                    Console.WriteLine("You Lose!");
                }
            }

            
        }
    }
}
