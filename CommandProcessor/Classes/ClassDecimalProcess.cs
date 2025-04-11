using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandProcessor.Classes
{
    //internal class ClassDecimalProcess
    //{
    //    public static int sharedNumber { get; set; }

    //    public ClassDecimalProcess(int initial)
    //    {
    //        sharedNumber = initial;
    //    }
    //}

    //public interface IDecimalProcess
    //{
    //    void exec();
    //    void undo();
    //}

    public static class classIncrement
    {
        private static int number;
        public static int funcNumber
        {
            get { return number; }
            set { number = value; }
        }

        public static void exec() 
        {
            number++;
        }
        public static void undo() 
        {
            number--;
        }

    }

    public static class classDecrement
    {
        private static int number;
        public static int funcNumber
        {
            get { return number; }
            set { number = value; }
        }

        public static void exec()
        {
            number--;
        }
        public static void undo()
        {
            number++;
        }
    }

    public static class classDouble
    {
        private static int number;
        public static int funcNumber
        {
            get { return number; }
            set { number = value; }
        }

        public static void exec()
        {
            number *= 2;
        }
        public static void undo()
        {
            number /= 2;
        }
    }
}
