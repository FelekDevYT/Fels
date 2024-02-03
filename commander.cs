using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lang
{
    public class commander
    {
        public static void MAIN(String path)
        {
            String[] str = File.ReadAllLines(path);
            for (int i = 0; i < str.Length; i++)
            {
                String[] line = str[i].Split(' ');//writeln[0] "11"[1]
                switch (line[0])
                {
                    case "writeln":
                        String[] l = str[i].Split('"','"');
                        Console.WriteLine(l[1]);
                        break;
                    case "color":
                        if (line[1] == "red") Console.ForegroundColor = ConsoleColor.Red;
                        if (line[1] == "green") Console.ForegroundColor = ConsoleColor.Green;
                        if (line[1] == "blue") Console.ForegroundColor = ConsoleColor.Blue;
                        if (line[1] == "yellow") Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    case "readKey":
                        Console.ReadKey();
                        Console.WriteLine();
                        break;
                }
            }
            Console.ReadKey();
        }
    }
}
