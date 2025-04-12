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


            // Create a stack to store command instances for enabling undo functionality.
            Stack<Classes.IDecimalProcess> commandHistory = new Stack<Classes.IDecimalProcess>();
            {

                // Set the initial shared number.
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Enter your initial nuber : ");

                Console.ForegroundColor = ConsoleColor.White;
                decimalProcess.funcSharedNumber = Convert.ToInt32(Console.ReadLine());
            }
            string menu = "enter your command or its number:" + Environment.NewLine +
                          "1- increment" + Environment.NewLine +
                          "2- decrement" + Environment.NewLine +
                          "3- double" + Environment.NewLine +
                          "4- randadd" + Environment.NewLine +
                          "5- undo";


            Classes.IDecimalProcess command = null;

            string input = "";

            while (true)
            {
                {
                    //Console
                    Console.ForegroundColor = ConsoleColor.Blue;

                    Console.WriteLine(menu);

                    input = Console.ReadLine()?.Trim().ToLower();

                    Console.ForegroundColor = ConsoleColor.White;
                }


                if (input == "1" || input == "increment")
                {
                    command = Classes.classIncrement.getInstance();
                }
                else if (input == "2" || input == "decrement")
                {
                    command = Classes.classDecrement.getInstance();
                }
                else if (input == "3" || input == "double")
                {
                    command = Classes.classDouble.getInstance();
                }
                else if (input == "4" || input == "random")
                {
                    command = new Classes.classRandomAdd();
                }
                else if (input == "5" || input == "undo")
                {
                    // If there are commands in history, perform the undo operation on the most recent one.
                    if (commandHistory.Count > 0)
                    {
                        Classes.IDecimalProcess lastCommand = commandHistory.Pop();
                        lastCommand.undo();
                        // Output the updated shared number after undoing the command.
                        Console.WriteLine(decimalProcess.funcSharedNumber);
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("No commands to undo.");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid command.");
                    continue;
                }
                // Execute the chosen command.
                command.exec();

                // Push the command onto the history stack for potential future undo.
                commandHistory.Push(command);

                // Output the updated shared number after executing the command.
                Console.WriteLine(decimalProcess.funcSharedNumber);
            }
        }
    }
}
