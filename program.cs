using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace lang
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Label:
                Console.Write("Enter Command>");
                String[] command = Console.ReadLine().Split(' ');
                if (command[0] == "start")
                {
                    if (command.Length == 1)
                    {
                        commander.MAIN("program.txt");
                        goto Label;
                    }
                    else
                    {
                        commander.MAIN(command[1]);
                    }
                }
            }
        }
    }
}
