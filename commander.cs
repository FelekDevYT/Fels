using System;
using System.IO;
using langg;
using System.Windows.Forms;
using System.Xml.Schema;

namespace lang
{
    public class commander
    {
        public static void MAIN(String path)
        {
            String[] str = str = File.ReadAllLines(path); ;
            String[] var_value = new String[1024];
            String[] var_names = new String[1024];
            String st1;
            String st2;
            int uses = 0;
            int zc = 0;
            int use = 0;
            bool is_html = false;
            for (int i = 0; i < str.Length; i++)
            {
                String[] line = str[i].Split(' ');
                switch (line[0])
                {
                    case "writeln":
                        String[] l = str[i].Split('"', '"');
                        if(line.Length == 4)
                        {
                            Console.WriteLine(Parser.NumericExpression(Convert.ToInt32(line[1]), line[2], Convert.ToInt32(line[3])));
                        }
                        if(l.Length > 1)
                        {
                            Console.WriteLine(l[1]);
                        }
                        else
                        {
                            use = 0;
                            foreach(String el in var_names)
                            {
                                String g;
                                g = line[1];
                                if (el == g)
                                {
                                    Console.WriteLine(var_value[use]);
                                    break;
                                }
                                use++;
                            }
                        }
                        break;
                    case "write":
                        String[] ln = str[i].Split('"', '"');
                        if (line.Length == 4)
                        {
                            Console.Write(Parser.NumericExpression(Convert.ToInt32(line[1]), line[2], Convert.ToInt32(line[3])));
                        }
                        if (ln.Length > 1)
                        {
                            Console.Write(ln[1]);
                        }
                        else
                        {
                            use = 0;
                            foreach (String el in var_names)
                            {
                                String g;
                                g = line[1];
                                if (el == g)
                                {
                                    Console.Write(var_value[use]);
                                    break;
                                }
                                use++;
                            }
                        }
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
                    case "var":
                        String[] eq = str[i].Split('=');
                        var_value[uses] = eq[1];
                        var_names[uses] = line[1];
                        break;
                    case "read":
                        uses = 0;
                        zc = 0;
                        foreach(String el in var_names)
                        {
                            String gl = line[1];
                            if(gl == el)
                            {
                                var_value[use] = Console.ReadLine();
                                use = 0;
                                zc = 0;
                                break;
                            }
                            zc++;
                            use++;
                        }
                        if(zc == 0){
                            break;
                        }
                        else
                        {
                            Exceptions.NonVarException();
                        }
                        break;
                    case "beep":
                        Console.Beep(Convert.ToInt32(line[1]), Convert.ToInt32(line[2]));
                        break;
                    case "fif":
                        /*
                         *fif a > b
                         *fif 1 > 2
                         */
                        Console.WriteLine(Parser.EQExpression(Convert.ToInt32(line[1]), line[2], Convert.ToInt32(line[3])));
                        break;
                    case ";":
                        break;
                    case "if":
                        /*
                         * if 5 > 5 1
                         * if var1 > var2
                         */
                        bool ansver = Parser.EQExpression(Convert.ToInt32(line[1]), line[2], Convert.ToInt32(line[3]));
                        if (ansver)
                        {
                            ;
                        }
                        else
                        {
                            i += Convert.ToInt32(line[4]);
                        }
                        break;
                    case "goto":
                        i+= Convert.ToInt32(line[1]);
                        break;
                    case "message":
                        switch (line[1])
                        {
                            case "info":
                                MessageBox.Show(line[3], line[2],MessageBoxButtons.OK, MessageBoxIcon.Information);
                                break;
                            case "error":
                                MessageBox.Show(line[3], line[2], MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            case "war":
                                MessageBox.Show(line[3], line[2], MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                break;
                            case "qu":
                                MessageBox.Show(line[3], line[2], MessageBoxButtons.OK, MessageBoxIcon.Question);
                                break;
                            case "exc":
                                MessageBox.Show(line[3], line[2], MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                break;
                            case "stop":
                                MessageBox.Show(line[3], line[2], MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                break;
                        }
                        break;
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
        }
    }
}
