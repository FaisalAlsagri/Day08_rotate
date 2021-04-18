using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Day08
{
    class Program
    {
        static void Main(string[] args)
        {
            Searchable obj = new Searchable("1 20 20 2 3 4");
            Console.WriteLine(obj.numOfWords());
            Console.WriteLine(obj.numOfChars());
            Console.WriteLine(obj.numofXWord("fas"));
            Console.WriteLine(obj.numofXChar('2'));
            Console.WriteLine(obj.lastIndexOf('2'));
            Console.WriteLine(obj.mostFWord());
            Console.WriteLine(obj.swap());
            int[] value = { 1, 2, 3, 4, 5 };
            string word1 = string.Join(" ",obj.rotate(value,3,true));
            string word2 = string.Join(" ",obj.rotate(value,3,false));
            Console.WriteLine(word1);
            Console.WriteLine(word2);
        }

        class EasyMath
        {
            private int firstValue;
            private int secondValue;
        }

        class Searchable
        {
            string value;

            public Searchable(string val)
            {
                this.value = val;
            }
            public int numOfWords()
            {
                String[] w = this.value.Split(" ");
                return w.Length;
            }
            public int numOfChars()
            {
                int count = 0;
                String[] w = this.value.Split(" ");
                foreach (var item in w)
                {
                    foreach (var i in item)
                    {
                        count++;
                    }
                }
                return count;
            }
            public int numofXWord(string word)
            {
                String[] w = this.value.Split(" ");
                int count = 0;
                for (int i = 0; i < w.Length; i++)
                {
                    if (w[i].Equals(word))
                    {
                        count++;
                    }
                }
                return count;
            }
            public int numofXChar(char c)
            {
                int count = 0;
                for(int i = 0; i < this.value.Length; i++)
                {
                    if(this.value[i] == c)
                    {
                        count++;
                    }
                }
                return count;
            }
            public int lastIndexOf(char c)
            {
                int count = -1;
                for (int i = 0; i < this.value.Length; i++)
                {
                    if (this.value[i] == c)
                    {
                        count = i;
                    }
                }
                return count;
            }
            public string mostFWord()
            {
                int big = 0;
                string str = "";
                String[] arr = this.value.Split(" ");
                foreach (var item in arr)
                {
                    if (numofXWord(item) > big)
                    {
                        big = numofXWord(item);
                        str = item;
                    }
                }
                return str;
            }
            public string swap()
            {
                String[] w = this.value.Split(" ");
                for (int i = 0; i < w.Length; i++)
                {
                    string temp = w[i];
                    if(i <= w.Length -2)
                    {
                        w[i] = w[i + 1];
                        i++;
                    }
                    
                    w[i] = temp;
                }

                string word = string.Join(" ",w);
                
                return word;
                
            }

            public int[] rotate(int[] arr, int count, bool y)
            {
                if (y)
                {
                    int[] val = new int[arr.Length];
                    int c = 0;
                    for (int i = arr.Length - count; i < arr.Length; i++)
                    {
                        val[c++] = arr[i];
                    }
                    for (int j = 0; j < arr.Length - count; j++)
                    {
                        val[c++] = arr[j];
                    }
                    foreach (var item in val)
                    {
                        Console.WriteLine(item);
                    }
                    return val;
                }
                int[] val1 = new int[arr.Length];
                int c1 = 0;
                for (int i = count; i < arr.Length; i++)
                {
                    val1[c1++] = arr[i];
                }
                for (int j = 0; c1 < arr.Length; j++)
                {
                    val1[c1++] = arr[j];
                }
                foreach (var item in val1)
                {
                    Console.WriteLine(item);
                }
                return val1;
            }
            /*public bool check(string str)
            {

            }*/
        }
        static bool match(string source)
        {
            List<char> open = new List<char>();
            List<char> close = new List<char>();
            for (int i =0; i< source.Length; i++)
            {
                if(source[i] == '{')
                {
                    open.Add(source[i]);
                }else if (source[i] == '}')
                {
                    if (close.Count == open.Count)
                    {
                        Console.WriteLine("error");
                        return false;
                    }
                    close.Add(source[i]);
                }
            }
            if (close.Count != open.Count)
            {
                return false;
            }
                return true;
        }
    }
}