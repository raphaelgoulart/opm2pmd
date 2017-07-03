using System;
using System.IO;

namespace opm2pmd {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("opm2pmd by raphaelgoulart");
            if (args.Length > 0) {
                foreach (var path in args) {
                    if (File.Exists(path)) Convert(path);
                    else Console.WriteLine("File " + path + " does not exist - skipping it.");
                }
                Console.WriteLine("Finished. Press any button to exit...");
            } else {
                Console.WriteLine("Usage: Drag and drop your .opm files into this executable file, and it will output a .mml file accordingly.");
                Console.WriteLine("Press any button to exit...");
            }
            Console.ReadKey();
        }

        static void Convert(string path) {
            Console.WriteLine("Converting " + path + "...");
            StreamReader file = new StreamReader(path);
            StreamWriter output = new StreamWriter(path + ".mml");
            string line;
            try {
                while ((line = file.ReadLine()) != null) {
                    string num = "", name = "", alg = "", fb = "",
                    line2 = "", line3 = "", line4 = "", line5 = "";
                    var count = 0;
                    while(count < 7 && line != null) {
                        if (line.Trim() == "" || line.Substring(0, 2) == "//") {
                        } else {
                            string[] strArr;
                            switch (count) {
                                case 0:
                                    strArr = line.Split(' ');
                                    num = strArr[0].Substring(2);
                                    name = strArr[1];
                                    break;
                                case 1:
                                    break;
                                case 2:
                                    line = line.Substring(3).Trim();
                                    strArr = CleanArray(line.Split(' '));
                                    fb = strArr[1];
                                    alg = strArr[2];
                                    break;
                                case 3:
                                    line2 = Format(line);
                                    break;
                                case 4:
                                    line3 = Format(line);
                                    break;
                                case 5:
                                    line4 = Format(line);
                                    break;
                                case 6:
                                    line5 = Format(line);
                                    break;
                                default:
                                    Console.WriteLine("Something has gone wrong (reading past seventh line)");
                                    break;
                            }
                            count++;
                        }
                        line = file.ReadLine();
                    }
                    output.WriteLine("@" + GreaterThanTen(num) + " " + GreaterThanTen(alg) + " " + GreaterThanTen(fb) + "  =" + name.ToUpper());
                    output.WriteLine(line2);
                    output.WriteLine(line3);
                    output.WriteLine(line4);
                    output.WriteLine(line5);
                    output.WriteLine();
                }
            } catch (Exception e) {
                Console.WriteLine("An error ocurred: ");
                Console.WriteLine(e);
            } finally {
                file.Close();
                output.Close();
            }
        }

        private static string Format(string line) {
            line = line.Substring(3).Trim();
            var strArr = CleanArray(line.Split(' '));
            return " " + GreaterThanTen(strArr[0]) + " " 
                + GreaterThanTen(strArr[1]) + " " 
                + GreaterThanTen(strArr[2]) + " " 
                + GreaterThanTen(strArr[3]) + " " 
                + GreaterThanTen(strArr[4]) + " " 
                + GreaterThanTen(strArr[5]) + " "
                + GreaterThanTen(strArr[6]) + " "
                + GreaterThanTen(strArr[7]) + " " 
                + GreaterThanTen(strArr[8]) + " "
                + GreaterThanTen(strArr[10]);
        }

        private static string[] CleanArray(string[] strArr) {
            return Array.FindAll(strArr, IsNotEmpty);
        }

        private static bool IsNotEmpty(string s) {
            return s.Trim() != "";
        }

        private static string GreaterThanTen(string s) {
            int num;
            if (Int32.TryParse(s, out num)) {
                if (num < 10) return "  " + s;
                if (num < 100) return " " + s;
                else return s;
            } else return s;
        }
    }
}