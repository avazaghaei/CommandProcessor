﻿using System;
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

    public class classIncrement
    {
        private static int number;
        public static int funcUserID
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

    public class classDecrement()
    {
        public void exec(int value)
        {
            value++;
        }
        public void undo(int value)
        {
            value--;
        }
    }
}
