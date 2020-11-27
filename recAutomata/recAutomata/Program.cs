using System;
using System.Text.RegularExpressions;

namespace recAutomata
{
    class Automata
    {
        string input;
        int i = 0;

        public string simple(string st)
        {
            return Regex.Replace(st, @"([0-9]+)", "i");
            //return Regex.Replace(st, "^[0 - 999]$", "i");
            //return Regex.Replace(st, "^([1-9][0-9]{0,2}|1000)$", "i");
        }

        public Automata(string input)
        {
            Console.WriteLine("Eredeti input: {0}", input);
            this.input = $"{simple(input)}#";
            Console.WriteLine("Egyszerűsített input: {0}",this.input);
        }

        public void elfogad(char ch)
        {
            if (input[i] != ch)
            {
                Console.WriteLine("Hibás kifejezés: {0}. Helytelen karakter: {1}", input,input[i]);
            }
            i++;
        }

        //Szabályok:
        public void S()
        {
            E();
            elfogad('#');
            Console.WriteLine("Az elemzés lefutott");
        }

        void E()
        {
            T();
            Ev();
        }

        void T()
        {
            F();
            Tv();
        }

        void Ev()
        {
            if (input[i] == '+')
            {
                elfogad('+');
                T();
                Ev();
            }
        }

        void Tv()
        {
            if (input[i] == '*')
            {
                elfogad('*');
                F();
                Tv();
            }
        }

        void F()
        {
            if (input[i] == '(')
            {
                elfogad('(');
                E();
                elfogad(')');
            } else
            {
                elfogad('i');
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Automata A = new Automata("(756+544)*433");
            A.S();
        }
    }
}
