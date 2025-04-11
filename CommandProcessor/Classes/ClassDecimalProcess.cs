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

        private static ClassDecimalProcess theInstance = null;
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
