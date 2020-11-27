using System;
using System.Collections.Generic;
using System.IO;

namespace finitAutomat
{
    class Program
    {

        class automata
        {
            string state = "A";
            //string input = "+110";
            Dictionary<String, String> D = new Dictionary<String, String>();

            public void prepare()
            {
                D.Add("A+","B");
                D.Add("A-", "B");
                D.Add("Ad", "C");
                D.Add("Bd", "C");
                D.Add("Cd", "C");
            }

            public void unPrepare()
            {
                D.Clear();
            }

            public char convert(char c)
            {
                if (Char.IsDigit(c))
                {
                    return 'd';
                }
                return c;
            }

            public string delta(string st, char akt)
            {
                if (D.ContainsKey(st + convert(akt)))
                {
                    return D[st + convert(akt)];
                }
                return "Error";
            }

            #region RégiDelta
            //public string delta(string st, char akt)
            //{
            //    string ex = st + convert(akt);
            //    switch (ex)
            //    {
            //        case "A+": return "B";
            //        case "A-": return "B";
            //        case "Ad": return "C";
            //        case "Bd": return "C";
            //        case "Cd": return "C";
            //        default: return "Error";
            //    } 
            //}
            #endregion

            public void main(string input)
            {
                prepare();
                int i = 0;
                while (i < input.Length && state != "Error")
                {
                    state = delta(state, input[i]);
                    i++;
                }

                if (state != "Error")
                {
                    Console.WriteLine("{0} helyes bemenet", input);
                } else
                {
                    Console.WriteLine("{0} nem helyes bemenő adat. Hibás karakter található a {1}. helyen",input,i);
                }
                state = "A";
                i = 0;
                unPrepare();
            }
        }

        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            StreamReader sr = new StreamReader("input.txt");
            string helper = "";
            while (!sr.EndOfStream)
            {
                helper += sr.ReadLine();
            }
            String[] sArray = helper.Split(" ");
            automata A = new automata();

            foreach (string i in sArray)
            {
                A.main(i);
            }
        }
    }
}
