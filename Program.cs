using System;
using System.IO;

/// <summary>
/// Utility class that provides helper methods for input handling.
/// </summary>
class Utility
{
    /// <typeparam name="T">The type of the input value.</typeparam>
    /// <param name="Parser">The parser function that converts the input string to the desired type.</param>
    /// <param name="Prompt">The prompt to display to the user.</param>
    /// <param name="ErrorPrompt">The prompt to display when the input is invalid.</param>
    /// <returns>The parsed input value.</returns>
    /// <summary>
    /// Gets input from the user and parses it to the desired type.
    /// </summary>
    public static T GetInput<T>(Func<string, T> Parser, string Prompt, string ErrorPrompt = "Please enter a valid input!")
    {
        if (!Prompt.EndsWith(": "))
        {
            Prompt += ": ";
        }

        while (true)
        {
            Console.Write(Prompt);
            string Line = Console.ReadLine();

            if (Line is not null)
            {
                if (Line.Length > 0)
                {
                    T Value;
                    try
                    {
                        Value = Parser(Line);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine(ErrorPrompt);
                        continue;
                    }

                    return Value;
                }
                else
                {
                    Console.WriteLine(ErrorPrompt);
                };
            }
            else
            {
                Console.WriteLine(ErrorPrompt);
            };
        }

    }
}

class Program
{
    // 1. Write a Console Application Program to calculate the area of a rectangle.Prompt the user to enter the length and width. Display the calculated area. (use a separate function calculate the area
    static void Question1()
    {

        double Length = Utility.GetInput(double.Parse, "Enter the length of the rectangle");
        double Height = Utility.GetInput(double.Parse, "Enter the height of the rectangle");

        double Area = Length * Height;

        Console.WriteLine("The area of the rectangle is {0}", Area);
    }

    //    2. Write a Console Application program to check if the given 10 number inputs are even or odd. Prompt the user to enter the numbers, and display whether it's even or odd.
    static void Question2()

    {
        bool isEven(int Number)
        {
            return Number % 2 == 0;
        }

        Func<int, bool> isOdd = (int Number) => !isEven(Number);
        // isOdd = lambda Number: not isEven(Number)

        for (int i = 0; i < 10; i++)
        {
            int Number = Utility.GetInput(int.Parse, "Enter a number");

            if (isEven(Number))
            {
                Console.WriteLine("Number {0} is even.", Number);
            }
            else
            {
                Console.WriteLine("Number {0} is odd.", Number);
            };
        }

    }

    // 3. Write a Console Application program to calculate the sum of all numbers from 1 to a given positive integer.Prompt the user to enter a positive integer and display the sum.If the user inputs a negative value it should display “ERROR”.
    static void Question3()
    {
        int Number = Utility.GetInput(int.Parse, "Enter a positive integer");

        if (Number < 0)
        {
            Console.WriteLine("ERROR");
        }
        else
        {
            int Sum = 0;
            for (int i = 1; i <= Number; i++)
            {
                Sum += i;
            }

            Console.WriteLine("The sum of all numbers from 1 to {0} is {1}", Number, Sum);
        }
    }

    // 4. Write a Console Application program to print the first N terms of the Fibonacci series. Prompt the user to enter the value of N. (Use recursion)
    static void Question4()
    {
        int N = Utility.GetInput(int.Parse, "Enter the value of N");

        int Fibonacci(int N)
        {
            if (N == 0)
            {
                return 0;
            }
            else if (N == 1)
            {
                return 1;
            }
            else
            {
                return Fibonacci(N - 1) + Fibonacci(N - 2);
            }
        }

        for (int i = 0; i < N; i++)
        {
            Console.Write(Fibonacci(i) + " ");
        }
    }

    // 5. Write a Console Application program to display the multiplication table of a given number. Prompt the user to enter a number and display its multiplication table. (Use loops).
    static void Question5()
    {
        int Number = Utility.GetInput(int.Parse, "Enter a number");

        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine("{0} x {1} = {2}", Number, i, Number * i);
        }
    }

    // 6. Create a C# console application that prompts the user to input a student's name and their exam marks. Based on the provided marks, determine, and display the corresponding grade for the student. The grading scale is as follows:
    // • If the marks are between 75 and 100 (inclusive), assign Grade A.
    // • For marks between 60 and 74 (inclusive), assign Grade B.
    // • For marks between 50 and 59 (inclusive), assign Grade C.
    // • For marks between 40 and 49 (inclusive), assign Grade D.
    // • If the marks are below 40, the student has failed.
    // • Display the student's name along with their assigned grade at the end of the program.
    // • Validate the user input so that when the user inputs a value higher than 100 and less than 0 it displays an error message.
    static void Question6()
    {
        string Name = Utility.GetInput(((string x) => x), "Enter the student's name");
        int Marks = Utility.GetInput(int.Parse, "Enter the student's marks");

        if (Marks < 0 || Marks > 100)
        {
            Console.WriteLine("ERROR: Marks should be between 0 and 100");
        }
        else if (Marks >= 75)
        {
            Console.WriteLine("{0} has scored Grade A", Name);
        }
        else if (Marks >= 60)
        {
            Console.WriteLine("{0} has scored Grade B", Name);
        }
        else if (Marks >= 50)
        {
            Console.WriteLine("{0} has scored Grade C", Name);
        }
        else if (Marks >= 40)
        {
            Console.WriteLine("{0} has scored Grade D", Name);
        }
        else
        {
            Console.WriteLine("{0} has failed", Name);
        }

    }

    // 7. Write a Console Application program to simulate a basic ATM machine. Allow the user to check balance, deposit money, and withdraw money. Display appropriate messages based on user actions. (Create separate functions for individual operations.)
    static void Question7()
    {
        double Balance = 0;

        void CheckBalance()
        {
            Console.WriteLine("Your balance is {0}", Balance);
        }

        void Deposit()
        {
            double Amount = Utility.GetInput(double.Parse, "Enter the amount to deposit");
            Balance += Amount;
            Console.WriteLine("Deposited {0}. Your new balance is {1}", Amount, Balance);
        }

        void Withdraw()
        {
            double Amount = Utility.GetInput(double.Parse, "Enter the amount to withdraw");
            if (Amount > Balance)
            {
                Console.WriteLine("Insufficient balance");
            }
            else
            {
                Balance -= Amount;
                Console.WriteLine("Withdrawn {0}. Your new balance is {1}", Amount, Balance);
            }
        }

        while (true)
        {
            Console.WriteLine("1. Check Balance");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Withdraw");
            Console.WriteLine("4. Exit");

            int Choice = Utility.GetInput(int.Parse, "Enter your choice");

            if (Choice == 1)
            {
                CheckBalance();
            }
            else if (Choice == 2)
            {
                Deposit();
            }
            else if (Choice == 3)
            {
                Withdraw();
            }
            else if (Choice == 4)
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice");
            }
        }

    }

    static void Main(string[] args)
    {
        // Question1();
        // Question2();
        // Question3();
        // Question4();
        // Question5();
        // Question6();
        Question7();
    }
}