using System;
using System.Threading;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestClass test = new TestClass();
            //test.ThreadTest();
            EnClass.Process("ysfdsfsdwetrttyhtqwqailckeudxdx");
            Console.ReadKey();
        }
    }

    public class TestClass
    {
        public void ThreadTest()
        {
            Thread t = new Thread(()=>CountTo(10));
            t.Start();
            new Thread(()=> {
                CountTo(5);
                CountTo(6);
            }).Start();
        }

        public void CountTo(int v)
        {
            for(int i = 0; i <= v; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
    public static class EnClass
    {
        private static string[] code = { "de", "f", "w", "z", "sd", "dx", "x" };
        public static void Process(string text)
        {
            string result = "";
            for (int i=0;i< text.Length; i++)
            {
                int twolettersIndex = GetMatch(text.Substring(i, 2));
                if (twolettersIndex != 0)
                {
                    result += twolettersIndex;
                    i++;
                }
                else
                {
                    int onelettersIndex = GetMatch(text.Substring(i, 1));
                    if (onelettersIndex != 0)
                    {
                        result += onelettersIndex;
                    }
                    else
                    {
                        result += text.Substring(i, 1);
                    }
                }
            };
            Console.WriteLine(result);
        }

        private static int GetMatch(string text)
        {
            for (int i = 0; i < code.Length; i++)
            {
                if (text == code[i])
                {
                    return i + 1;
                }
            };
            return 0;
        }
    }
}
