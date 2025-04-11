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
        static void Main(string[] args)
        {
            Classes.ClassDecimalProcess cls = Classes.ClassDecimalProcess.getInstance();
            cls.funcSharedNumber = 5;

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
                        if (historyCommand.Count > 0)
                        {
                            Classes.IDecimalProcess lastCommand = historyCommand.Pop();
                            lastCommand.undo();
                            Console.WriteLine(cls.funcSharedNumber);
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
                command.exec();
                historyCommand.Push(command);
                Console.WriteLine(cls.funcSharedNumber);
            }
        }
    }
}
