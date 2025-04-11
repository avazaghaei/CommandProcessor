/*
 * File: ClassDecimalProcess.cs
 * Description:
 *   This file contains the implementation of decimal-based command processing for a PLC-related solution.
 *   It demonstrates two primary design concepts:
 *     - A singleton context class, ClassDecimalProcess, that holds a shared numeric value used by all commands.
 *     - A set of command classes that implement the IDecimalProcess interface with exec() and undo() methods, 
 *       enabling each command to alter and then potentially revert the shared value.
 *
 *   The file includes:
 *     - ClassDecimalProcess: A singleton class that stores the shared number (both input and output values).
 *     - IDecimalProcess: An interface defining the contract for command execution (exec()) and undo functionality (undo()).
 *     - classIncrement: Increases the shared number by 1.
 *     - classDecrement: Decreases the shared number by 1.
 *     - classDouble: Doubles the shared number (and undoes by halving, assuming even values).
 *     - classRandomAdd: Adds a random integer (between 1 and 9) to the shared number and undoes the addition.
 *
 * Assumptions:
 *   - A singleton pattern is used for both the shared context (ClassDecimalProcess) and for three command classes to avoid unnecessary object allocations.
 *   - The random number added in classRandomAdd is chosen from 1 to 9 (using Next(1,10)), and it is stored for proper undo functionality.
 */

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandProcessor.Classes
{
    public class ClassDecimalProcess
    {

        /// <summary>
        /// Provides a singleton context for a shared decimal value.
        /// This class stores the numeric state that each command will operate on.
        /// Both input and output values of commands are maintained in this class.
        /// </summary>
        private static ClassDecimalProcess theInstance = null;

        /// <summary>
        /// Gets the single instance of the ClassDecimalProcess.
        /// If the instance doesn't exist, it creates one.
        /// </summary>
        /// <returns>The singleton instance of ClassDecimalProcess.</returns>
        public static ClassDecimalProcess getInstance()
        {
            if (theInstance == null)
                theInstance = new ClassDecimalProcess();
            return theInstance;
        }

        // Stores the shared number value.
        private int sharedNumber;

        /// <summary>
        /// Gets or sets the shared number that is used as input/output for command operations.
        /// </summary>
        public int funcSharedNumber
        {
            get { return sharedNumber; }
            set { sharedNumber = value; }
        }
    }


    /// <summary>
    /// Defines the contract for decimal command processing.
    /// All command classes implementing this interface must provide execution and undo functionality.
    /// </summary>
    public interface IDecimalProcess
    {
        /// <summary>
        /// Executes the command, altering the shared decimal value accordingly.
        /// </summary>
        void exec();

        /// <summary>
        /// Reverses the changes made by the exec() method, restoring the previous state.
        /// </summary>
        void undo();
    }


    /// <summary>
    /// Implements the increment command. This command increases the shared number by one.
    /// Uses a singleton instance to avoid unnecessary object creation.
    /// </summary>
    public class classIncrement : IDecimalProcess
    {
        // Internal copy of the number for processing.
        private int internalNumber;

        // Singleton instance of classIncrement.
        private static classIncrement theInstance = null;

        /// <summary>
        /// Gets the single instance of classIncrement.
        /// </summary>
        /// <returns>The singleton instance of classIncrement.</returns>
        public static classIncrement getInstance()
        {
            if (theInstance == null)
                theInstance = new classIncrement();
            return theInstance;
        }

        /// <summary>
        /// Executes the increment command by increasing the shared number by 1.
        /// </summary>
        public void exec() 
        {
            ClassDecimalProcess clsDecimalProcess = ClassDecimalProcess.getInstance();

            // Save the current value before modification.
            internalNumber = clsDecimalProcess.funcSharedNumber;

            // Increase the number.
            internalNumber++;

            // Save the new value back to the context.
            clsDecimalProcess.funcSharedNumber = internalNumber;

        }

        /// <summary>
        /// Undoes the increment command by decreasing the shared number by 1.
        /// </summary>
        public void undo() 
        {
            ClassDecimalProcess clsDecimalProcess = ClassDecimalProcess.getInstance();

            // Retrieve current value.
            internalNumber = clsDecimalProcess.funcSharedNumber;

            // Reverse the increment.
            internalNumber--;

            // Store the reverted value.
            clsDecimalProcess.funcSharedNumber = internalNumber;
        }

    }


    /// <summary>
    /// Implements the decrement command. This command decreases the shared number by one.
    /// Uses a singleton instance to optimize object allocation.
    /// </summary>
    public class classDecrement : IDecimalProcess
    {
        // Holds the temporary value during processing.
        private int internalNumber;

        // Singleton instance of classDecrement.
        private static classDecrement theInstance = null;

        /// <summary>
        /// Gets the single instance of classDecrement.
        /// </summary>
        /// <returns>The singleton instance of classDecrement.</returns>
        public static classDecrement getInstance()
        {
            if (theInstance == null)
                theInstance = new classDecrement();
            return theInstance;
        }

        /// <summary>
        /// Executes the decrement command by decreasing the shared number by 1.
        /// </summary>
        public void exec()
        {
            ClassDecimalProcess clsDecimalProcess = ClassDecimalProcess.getInstance();

            // Store current value.
            internalNumber = clsDecimalProcess.funcSharedNumber;

            // Decrease the number.
            internalNumber--;

            // Update the shared value.
            clsDecimalProcess.funcSharedNumber = internalNumber;

        }

        /// <summary>
        /// Undoes the decrement command by increasing the shared number by 1.
        /// </summary>
        public void undo()
        {
            ClassDecimalProcess clsDecimalProcess = ClassDecimalProcess.getInstance();

            // Retrieve the current value.
            internalNumber = clsDecimalProcess.funcSharedNumber;

            // Reverse the decrement.
            internalNumber++;

            // Update the shared value.
            clsDecimalProcess.funcSharedNumber = internalNumber;
        }
    }

    /// <summary>
    /// Implements the double command. This command doubles the shared number.
    /// The undo operation reverses the command by dividing the number by two (assuming an even number).
    /// Uses a singleton instance for efficiency.
    /// </summary>
    public class classDouble : IDecimalProcess
    {
        // Temporary storage for the number.
        private int internalNumber;

        // Singleton instance of classDouble.
        private static classDouble theInstance = null;

        /// <summary>
        /// Gets the singleton instance of classDouble.
        /// </summary>
        /// <returns>The singleton instance of classDouble.</returns>
        public static classDouble getInstance()
        {
            if (theInstance == null)
                theInstance = new classDouble();
            return theInstance;
        }

        /// <summary>
        /// Executes the command by doubling the shared number.
        /// </summary>
        public void exec()
        {
            ClassDecimalProcess clsDecimalProcess = ClassDecimalProcess.getInstance();

            // Get current value.
            internalNumber = clsDecimalProcess.funcSharedNumber;

            // Double the value.
            internalNumber *= 2;

            // Save the new value.
            clsDecimalProcess.funcSharedNumber = internalNumber;

        }

        /// <summary>
        /// Undoes the doubling by halving the shared number.
        /// Assumes the original value was even.
        /// </summary>
        public void undo()
        {
            ClassDecimalProcess clsDecimalProcess = ClassDecimalProcess.getInstance();

            // Retrieve the doubled value.
            internalNumber = clsDecimalProcess.funcSharedNumber;

            // Reverse doubling by halving.
            internalNumber /= 2;

            // Store the reverted value.
            clsDecimalProcess.funcSharedNumber = internalNumber;
        }
    }

    /// <summary>
    /// Implements the random addition command. This command adds a randomly generated integer (between 1 and 9) to the shared number.
    /// The random addition value is stored for the purpose of properly undoing the operation.
    /// Unlike other commands, this class is not implemented as a singleton since it relies on per-execution randomness.
    /// </summary>
    public class classRandomAdd : IDecimalProcess
    {
        // Stores the random value added during execution to enable accurate undoing.
        private int randomAmount;

        // Temporary storage for the current number.
        private int internalNumber;

        /// <summary>
        /// Executes the random add command by generating a random number and adding it to the shared number.
        /// </summary>
        public void exec()
        {
            ClassDecimalProcess clsDecimalProcess = ClassDecimalProcess.getInstance();

            // Capture the current shared number.
            internalNumber = clsDecimalProcess.funcSharedNumber;

            // Generate a random number between 1 and 9.
            Random rnd = new Random();
            randomAmount = rnd.Next(1, 10);

            // Add the random number.
            internalNumber += randomAmount;

            // Update the shared value.
            clsDecimalProcess.funcSharedNumber = internalNumber;

        }

        /// <summary>
        /// Undoes the random addition by subtracting the previously added random number from the shared number.
        /// </summary>
        public void undo()
        {
            ClassDecimalProcess clsDecimalProcess = ClassDecimalProcess.getInstance();

            // Retrieve the modified value.
            internalNumber = clsDecimalProcess.funcSharedNumber;

            // Reverse the addition by subtracting the random number.
            internalNumber -= randomAmount;

            // Update the shared value.
            clsDecimalProcess.funcSharedNumber = internalNumber;

        }
    }
}
