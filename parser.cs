using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace langg
{
    public class Parser
    {
        public static int NumericExpression(int st1,String el,int st2)
        {
            switch (el)
            {
                case "+":
                    return st1 + st2;
                case "-":
                    return st1 - st2;
                case "*":
                    return st1 * st2;
                case "/":
                    return st1 / st2;
                case "%":
                    return st1 % st2;
                case "**":
                    return (int) Math.Pow(st1,st2);
            }
            return 0;
        }
        public static Boolean EQExpression(int st1,String el,int st2)
        {
            switch (el)
            {
                case ">":
                    return st1 > st2;
                case "<":
                    return st1 < st2;
                case "!=":
                    return st1 != st2;
                case "==":
                    return st1 == st2;
                case ">=":
                    return st1 >= st2;
                case "<=":
                    return st1 == st2;
            }
            return false;
        }
    }
    public class Exceptions
    {
        public static void OperathorNotFound() { Console.WriteLine("Operathor not found!"); Console.ReadKey(); Environment.Exit(-111); }
        public static void NonVarException() { Console.WriteLine("Variable not found!");Console.ReadKey();Environment.Exit(-112); }
        public static void WritelnException() { Console.WriteLine("Variable or String not found!");Console.ReadKey();Environment.Exit(-113); }
    }
}
