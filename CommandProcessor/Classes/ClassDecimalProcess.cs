using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandProcessor.Classes
{
    internal class ClassDecimalProcess
    {
        public static int sharedNumber { get; set; }

        public ClassDecimalProcess(int initial)
        {
            sharedNumber = initial;
        }
    }

    public interface IDecimalProcess
    {
        void exec();
        void undo();
    }

    public class classIncrement : IDecimalProcess
    {
        private int number;
        public int funcUserID
        {
            get { return number; }
            set { number = value; }
        }

        public void exec() 
        {
            number++;
        }
        public void undo() 
        {
            number--;
        }

    }

    public class classDecrement : IDecimalProcess
    {
        private int number;
        public int funcUserID
        {
            get { return number; }
            set { number = value; }
        }

        public void exec()
        {
            number--;
        }
        public void undo()
        {
            number++;
        }
    }

    public class classDouble : IDecimalProcess
    {
        private int number;
        public int funcUserID
        {
            get { return number; }
            set { number = value; }
        }

        public void exec()
        {
            number *= 2;
        }
        public void undo()
        {
            number /= 2;
        }
    }
}
