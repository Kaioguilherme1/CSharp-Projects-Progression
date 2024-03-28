//author: Kaio Guilherme
//date: 2024-03-27
using System;
using System.Collections.Generic;

namespace Calculator
{
    class Calculator
    {   
        private List<String> history = new List<String>();
        
        private void AddToHistory(string operation, int num, double num1, double num2, double result)
        {
            this.history.Add($"{num}. | {num1} {operation} {num2} = {result}");
        }
        public static void Main(string[] args)
        {
            int operation, count = 0;
            double num1, num2, result;
            num1 = num2 = 0;
            Calculator calculator = new Calculator();
            
            do
            {
                count++;
                Console.Clear();
                Console.WriteLine("|==========================================|");
                Console.WriteLine("|   Welcome to the Calculator Application! |");
                Console.WriteLine("|==========================================|");
                Console.WriteLine("| 1. Addition                              |");
                Console.WriteLine("| 2. Subtraction                           |");
                Console.WriteLine("| 3. Multiplication                        |");
                Console.WriteLine("| 4. Division                              |");
                Console.WriteLine("| 5. History                               |");
                Console.WriteLine("| 0. Exit                                  |");
                Console.WriteLine("|==========================================|");
                Console.Write("Enter the operation you want to perform: >> ");
                operation = Convert.ToInt32(Console.ReadLine());
            
                if (operation != 0 && operation != 5)
                {
                    Console.Write("Enter the first number >>> ");
                    num1 = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Enter the second number >>> ");
                    num2 = Convert.ToDouble(Console.ReadLine());
                }

                switch (operation)
                {   
                    case 1:
                        result = num1 + num2;
                        Console.WriteLine($"The sum of {num1} and {num2} is {result}");
                        // Aqui você precisa criar uma instância da classe Calculator para chamar o método AddToHistory
                        calculator.AddToHistory("+",count, num1, num2, result);
                        Console.ReadLine();
                        break;
                    case 2:
                        result = num1 - num2;
                        Console.WriteLine($"The difference of {num1} and {num2} is {result}");
                        // Aqui você precisa criar uma instância da classe Calculator para chamar o método AddToHistory
                        calculator.AddToHistory("-",count , num1, num2, result);
                        Console.ReadLine();
                        break;
                    case 3:
                        result = num1 * num2;
                        Console.WriteLine($"The product of {num1} and {num2} is {result}");
                        // Aqui você precisa criar uma instância da classe Calculator para chamar o método AddToHistory
                        calculator.AddToHistory("*",count , num1, num2, result);
                        Console.ReadLine();
                        break;
                    case 4:
                        result = num1 / num2;
                        Console.WriteLine($"The division of {num1} and {num2} is {result}");
                        // Aqui você precisa criar uma instância da classe Calculator para chamar o método AddToHistory
                        calculator.AddToHistory("/",count, num1, num2, result);
                        Console.ReadLine();
                        break;
                    case 5:
                        count--;
                        Console.Clear();
                        Console.WriteLine("|=========================================|");
                        Console.WriteLine("|         History of operations           |");
                        Console.WriteLine("|=========================================|");
                        foreach (String operation_history in calculator.history)
                        {
                            Console.WriteLine(operation_history);
                        }

                        Console.ReadLine();
                        break;
                    case 0:
                        Console.WriteLine("Exiting the application...");
                        break;
                    default:
                        Console.WriteLine("Invalid operation. Please try again.");
                        Console.ReadLine();
                        break;
                }
            } while (operation != 0);
        }
    }
}
