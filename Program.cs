using System;

using System.Text.RegularExpressions;

namespace helloRegEx
{
    class Program
    {
        static void Main(string[] args)
        {
            string instring = "";

            string iron_pattern1 = @"([1-9]{1}-[1-9]{1})";
            string iron_pattern2 = @"([pPuUsSlL][wW]){1,4}";

            Regex rg1 = new Regex(iron_pattern1);
            Regex rg2 = new Regex(iron_pattern2);

            while (true)
            {
                Console.WriteLine("\n*** ENTER STRING TO PARSE: ");
                instring = Console.ReadLine();

                // these are my lazyness strings
                if (instring.ToUpper() == "EXIT")
                {
                    break;
                } 
                else if (instring == "1")
                {
                    instring = "7-9PWUWLWSW";
                }
                else if (instring == "2")
                {
                    instring = ";alkjffa1-4UWLWPWSW;;klsajdf3-5;as4-9LWUWSWa;slkdfj";
                }
                else if (instring == "3")
                {
                    instring = "6-4PWUWLWSW";
                }
                else if (instring == "4")
                {
                    instring = "sal!@!()*dfkjasfd;klaj5-9PWLWS3-9asjlkf.2645489dLWSWPWPWPWPWPW1-04-7-2-8PWUWSWLWhha4-8sfadsf";
                }
                else if (instring == "5")
                {
                    Console.WriteLine("\nEnter comma seperated string: ");
                    string teststr = Console.ReadLine();

                    string[] tester = teststr.Split(",");

                    for (int i = 0; i < tester.Length; ++i)
                    {
                        Console.WriteLine("tester #" + (i + 1) + ": " + tester[i]);
                    }
                }

                Console.WriteLine("\nString to parse: " + instring + "\n");
                MatchCollection findings1 = rg1.Matches(instring);
                MatchCollection findings2 = rg2.Matches(instring);

                Console.WriteLine("\n*****************************" +
                                  "\nFindings1 Count: " + findings1.Count);
                
                if (findings1.Count < 0)
                {
                    Console.WriteLine("problem!");
                    return;
                }

                for(int i = 0; i < findings1.Count; ++i)
                {
                    Console.WriteLine("\nFinding1 #" + (i+1) + ": " + findings1[i].Value);
                    string tmp = findings1[i].Value;

                    // initialize
                    int iron1 = -1;
                    int iron2 = -1;

                    int.TryParse(findings1[i].Value.Substring(0, 1), out iron1);
                    int.TryParse(findings1[i].Value.Substring(2, 1), out iron2);

                    //Console.WriteLine("\n1st-" + iron1 + " || 2nd-" + iron2 + " || added: " + (iron1+iron2) + "\n");

                    string resultslist = "";

                    if (iron1 <= iron2)
                    {
                        for (i = iron1; i <= iron2; ++i)
                        {
                            if (i != iron1)
                            {
                                resultslist = resultslist + "," + i.ToString();
                            }
                            else if (i == iron1)
                            {
                                resultslist = i.ToString();
                            }
                            else
                            {
                                resultslist = resultslist + "howdidwegethere";
                            }
                            
                        }

                        Console.WriteLine("Club array: " + resultslist);
                    }
                }



                Console.WriteLine("\n*****************************" +
                    "              \nFindings2 Count: " + findings2.Count);
                for(int i = 0; i < findings2.Count; ++i)
                {
                    Console.WriteLine("\nFinding2 #" + (i + 1) + ": " + findings2[i].Value);
                }

            }
        }
    }
}
