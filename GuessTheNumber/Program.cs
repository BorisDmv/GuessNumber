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
            int life = 15;
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

                                int firstNum = userNumber / 100;
                                int secondNum = userNumber / 10;
                                secondNum = secondNum % 10;
                                int thirdNum = userNumber % 10;


                                var firstItem = aux.ElementAt(0);
                                var secondItem = aux.ElementAt(1);
                                var thirdItem = aux.ElementAt(2);

                                bool firstGuessedNoPos = aux.IndexOf(firstNum) != -1;
                                bool secondGuessedNoPos = aux.IndexOf(secondNum) != -1;
                                bool thirdGuessedNoPos = aux.IndexOf(thirdNum) != -1;


                                if (firstNum == firstItem && secondNum == secondItem && thirdNum == thirdItem)
                                {
                                    win = true;
                                    Console.WriteLine("You guessed the number!");
                                }
                                else if (firstNum == firstItem && secondNum == secondItem || firstNum == firstItem && thirdNum == thirdItem || secondNum == secondItem && thirdNum == thirdItem)
                                {
                                    Console.WriteLine("You guessed two numbers and their position");
                                }
                                else if (firstNum == firstItem || secondNum == secondItem || thirdNum == thirdItem)
                                {
                                    Console.WriteLine("You guessed one number and position");

                                    //Checking other two if they are included
                                    if (firstNum != firstItem || secondNum != secondItem || thirdNum != thirdItem)
                                    {
                                        Console.WriteLine("You guessed one number and position and the other two maybe are included");
                                    }
                                }
                                else if (firstGuessedNoPos == true && secondGuessedNoPos == true && thirdGuessedNoPos == true)
                                {
                                    Console.WriteLine("You guessed all numbers but not the positions");
                                }
                                else if(firstGuessedNoPos == true && secondGuessedNoPos == true || firstGuessedNoPos == true && thirdGuessedNoPos == true || secondGuessedNoPos == true && thirdGuessedNoPos == true)
                                {
                                    Console.WriteLine("You guessed two numbers but not the positions");
                                }
                                else if (firstGuessedNoPos == true || secondGuessedNoPos == true || thirdGuessedNoPos == true)
                                {
                                    Console.WriteLine("You guessed one number but not the position");
                                }
                                else
                                {
                                    Console.WriteLine("No matches");
                                }

                                life--;
                                Console.WriteLine("Life: " + life);
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
                    foreach(int auxs in aux)
                        Console.Write(auxs);
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