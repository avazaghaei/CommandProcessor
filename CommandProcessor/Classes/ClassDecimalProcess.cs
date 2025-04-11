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
        public static ClassDecimalProcess getInstance()
        {
            if (theInstance == null)
                theInstance = new ClassDecimalProcess();
            return theInstance;
        }

        private int sharedNumber;
        public int funcSharedNumber
        {
            get { return sharedNumber; }
            set { sharedNumber = value; }
        }
    }

    public interface IDecimalProcess
    {
        void exec();
        void undo();
    }

    public class classIncrement : IDecimalProcess
    {
        private int internalNumber;

        private static classIncrement theInstance = null;
        public static classIncrement getInstance()
        {
            if (theInstance == null)
                theInstance = new classIncrement();
            return theInstance;
        }
        public void exec() 
        {
            ClassDecimalProcess clsDecimalProcess = ClassDecimalProcess.getInstance();

            internalNumber = clsDecimalProcess.funcSharedNumber;

            internalNumber++;

            clsDecimalProcess.funcSharedNumber = internalNumber;

        }
        public void undo() 
        {
            ClassDecimalProcess clsDecimalProcess = ClassDecimalProcess.getInstance();

            internalNumber = clsDecimalProcess.funcSharedNumber;

            internalNumber--;

            clsDecimalProcess.funcSharedNumber = internalNumber;
        }

    }

    
    public class classDecrement : IDecimalProcess
    {
        private int internalNumber;

        private static classDecrement theInstance = null;
        public static classDecrement getInstance()
        {
            if (theInstance == null)
                theInstance = new classDecrement();
            return theInstance;
        }
        public void exec()
        {
            ClassDecimalProcess clsDecimalProcess = ClassDecimalProcess.getInstance();

            internalNumber = clsDecimalProcess.funcSharedNumber;

            internalNumber--;

            clsDecimalProcess.funcSharedNumber = internalNumber;

        }
        public void undo()
        {
            ClassDecimalProcess clsDecimalProcess = ClassDecimalProcess.getInstance();

            internalNumber = clsDecimalProcess.funcSharedNumber;

            internalNumber++;

            clsDecimalProcess.funcSharedNumber = internalNumber;
        }
    }

    public class classDouble : IDecimalProcess
    {
        private int internalNumber;

        private static classDouble theInstance = null;
        public static classDouble getInstance()
        {
            if (theInstance == null)
                theInstance = new classDouble();
            return theInstance;
        }
        public void exec()
        {
            ClassDecimalProcess clsDecimalProcess = ClassDecimalProcess.getInstance();

            internalNumber = clsDecimalProcess.funcSharedNumber;

            internalNumber *= 2;

            clsDecimalProcess.funcSharedNumber = internalNumber;

        }
        public void undo()
        {
            ClassDecimalProcess clsDecimalProcess = ClassDecimalProcess.getInstance();

            internalNumber = clsDecimalProcess.funcSharedNumber;

            internalNumber /= 2;

            clsDecimalProcess.funcSharedNumber = internalNumber;
        }
    }
    public class classRandomAdd : IDecimalProcess
    {
        private int randomAmount;
        private int internalNumber;
        public void exec()
        {
            ClassDecimalProcess clsDecimalProcess = ClassDecimalProcess.getInstance();

            internalNumber = clsDecimalProcess.funcSharedNumber;

            Random rnd = new Random();
            randomAmount = rnd.Next(1, 10);
            internalNumber += randomAmount;

            clsDecimalProcess.funcSharedNumber = internalNumber;

        }
        public void undo()
        {
            ClassDecimalProcess clsDecimalProcess = ClassDecimalProcess.getInstance();

            internalNumber = clsDecimalProcess.funcSharedNumber;

            internalNumber -= randomAmount;

            clsDecimalProcess.funcSharedNumber = internalNumber;

        }
    }
}
