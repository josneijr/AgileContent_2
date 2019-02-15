using System;
using System.Linq;

namespace AgileContent1
{
    public class Solution
    {
        public int solution(int number)
        {
            //Iniciamos o array zerado
            int[] digitsCount = Enumerable.Repeat(0, 10).ToArray();

            //Vamos descobrir quanto de cada dígito (0-9) temos no número
            while (number > 0)
            {
                digitsCount[number % 10]++;
                number = number / 10;
            }

            //O número será formado pelos dígitos encontrados, em ordem decrescente
            for (int i = 9; i >= 0; i--)
            {
                while (digitsCount[i] != 0)
                {
                    number = number * 10 + i;
                    digitsCount[i]--;
                }
            }

            if (number > 100000000)
            {
                return -1;
            }

            return number;
        }
    }

    class MainClass
    {
        public static void Main(string[] args)
        {
           
        }
    }
}
