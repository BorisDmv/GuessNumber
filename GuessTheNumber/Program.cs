using System;
using System.Collections.Generic;
using System.Linq;

namespace GuessTheNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            //Random three digit-number
            int Min = 0;
            int Min2 = 1;
            int Max = 9;
            int[] randomNumber = new int[3];
            List<int> aux = new List<int>();

            //User
            int userNumber = 0;
            bool win = false;
            int life = 5;
            bool lose = false;


            Random randNum = new Random();
            for (int i = 0; i <randomNumber.Length ; i++)
            {   
                if (i == 0)
                {
                    randomNumber[i] = randNum.Next(Min2, Max);
                }
                else
                {
                    randomNumber[i] = randNum.Next(Min, Max);
                }
                aux.Add(randomNumber[i]);
                Console.Write(randomNumber[i]);
            }
            Console.WriteLine();

            Console.WriteLine("Random number was generated successfully");

            //User Input
            while (life >= 0 && lose == false && win == false) {

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
                                //Console.WriteLine("User number is " + userNumber);
                                int firstNum = userNumber / 100;
                                int secondNum = userNumber / 10;
                                secondNum = secondNum % 10;
                                int thirdNum = userNumber % 10;
                                //Console.WriteLine(firstNum);
                                //Console.WriteLine(secondNum % 10);
                                //Console.WriteLine(thirdNum);

                                var firstItem = aux.ElementAt(0);
                                var secondItem = aux.ElementAt(1);
                                var thirdItem = aux.ElementAt(2);

                                bool numberGuessed = aux.Any(item => item == firstNum || item == secondNum || item == thirdNum);
                               // Console.WriteLine(firstNumFromRandom);

                                if (firstNum == firstItem && secondNum == secondItem && thirdNum == thirdItem)
                                {
                                    win = true;
                                    Console.WriteLine("You guessed the number!");
                                }
                                else if (firstNum == firstItem && secondNum == secondItem || firstNum == firstItem && thirdNum == thirdItem || secondNum == secondItem && thirdNum == thirdItem)
                                {
                                    life--;
                                    Console.WriteLine("Life left: " + life);
                                    Console.WriteLine("You guessed two numbers and there position");
                                }
                                else if (firstNum == firstItem || secondNum == secondItem || thirdNum == thirdItem)
                                {
                                    life--;
                                    Console.WriteLine("Life left: " + life);
                                    Console.WriteLine("You guessed one numbers and position");
                                }
                                else if (numberGuessed == true)
                                {
                                    life--;
                                    Console.WriteLine("Life left: " + life);
                                    Console.WriteLine("You guessed one number but not the position");
                                }
                                else
                                {
                                    life--;
                                    Console.WriteLine("Life left: " + life);
                                    Console.WriteLine("No matches");
                                }
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
                else if(win == true)
                {
                    Console.WriteLine();
                    Console.WriteLine("You win!");
                }
            }        
        }
    }
}