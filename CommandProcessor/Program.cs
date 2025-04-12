/*
 * File: Program.cs
 * Description:
 *   This file serves as the entry point for the Command Processor application,
 *   which implements a console-based command processing system for decimal values.
 *   It makes use of a shared context (ClassDecimalProcess) to store the number,
 *   and a stack to maintain command history for undo functionality.
 *
 *   The application supports these commands:
 *     - increment: Increases the shared number by one.
 *     - decrement: Decreases the shared number by one.
 *     - double: Doubles the shared number (with an undo operation that halves it).
 *     - randadd: Adds a random integer (between 1 and 9) to the shared number.
 *     - undo: Reverts the most recent command (if any exists in the history).
 *
 *   Commands are executed in an infinite loop, with user interaction via the console.
 */


using CommandProcessor.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CommandProcessor
{
    internal class Program
    {
        /// <summary>
        /// Application entry point.
        /// Initializes the shared decimal context and command history,
        /// then enters a loop to continuously accept and process user commands.
        /// </summary>
        static void Main(string[] args)
        {

            // Retrieve the singleton instance that holds the shared number.
            Classes.ClassDecimalProcess decimalProcess = Classes.ClassDecimalProcess.getInstance();

            // Set the initial shared number.
            Random rnd = new Random();
            decimalProcess.funcSharedNumber = rnd.Next(1, 10);

            // Create a stack to store command instances for enabling undo functionality.
            Stack<Classes.IDecimalProcess> historyCommand = new Stack<Classes.IDecimalProcess>();

            while (true)
            {
                Console.Write("Enter command (increment, decrement, double, randadd, undo): ");
                string input = Console.ReadLine()?.Trim().ToLower();
          
                Classes.IDecimalProcess command = null;
                switch (input)
                {
                    case "increment":
                        command = Classes.classIncrement.getInstance();
                        break;
                    case "decrement":
                        command = Classes.classDecrement.getInstance();
                        break;
                    case "double":
                        command = Classes.classDouble.getInstance();
                        break;
                    case "randadd":
                        command = new Classes.classRandomAdd();
                        break;
                    case "undo":
                        // If there are commands in history, perform the undo operation on the most recent one.
                        if (historyCommand.Count > 0)
                        {
                            Classes.IDecimalProcess lastCommand = historyCommand.Pop();
                            lastCommand.undo();
                            // Output the updated shared number after undoing the command.
                            Console.WriteLine(decimalProcess.funcSharedNumber);
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("Nothing to undo.");
                            continue;
                        }
                    default:
                        Console.WriteLine("Invalid command.");
                        continue;
                }
                // Execute the chosen command.
                command.exec();

                // Push the command onto the history stack for potential future undo.
                historyCommand.Push(command);

                // Output the updated shared number after executing the command.
                Console.WriteLine(decimalProcess.funcSharedNumber);
            }
        }
    }
}
