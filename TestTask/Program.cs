using System;

public class MySolution
{
    public int LongestValidParentheses(string s)
    {
        if (string.IsNullOrEmpty(s)) return 0; // проверка на null

        int maxLen = 0; //начальное значение
        int[] lengths = new int[s.Length]; //массив для хранения
        for (int i = 1; i < s.Length; i++) //пробегаемся по длине строки(начинаем с 1 потому что при s[i-1] должно быть валидным)
        {
            if (s[i] == ')') //просто провекри
            {
                if (s[i - 1] == '(')
                {
                    lengths[i] = (i >= 2 ? lengths[i - 2] : 0) + 2; //если i-1 валидный то прибавляем 2 к длине
                }
                else
                {
                    int prevLen = lengths[i - 1]; //длина предыдущего валидного выражения 
                    int start = i - prevLen - 1; //индекс начала 
                    if (start >= 0 && s[start] == '(') 
                    {
                        lengths[i] = prevLen + 2 + (start > 0 ? lengths[start - 1] : 0); // выбираем сумму значение если начальное(start) >0
                    }
                }
                maxLen = Math.Max(maxLen, lengths[i]); // максимальное значение 
            }
        }
        return maxLen;
    }
}

public class Program
{
    public static void Main()
    {
        MySolution sol = new MySolution();

        Console.WriteLine("Ввод: \"(()\"");
        Console.WriteLine("Вывод: " + sol.LongestValidParentheses("(()")); // Ожидается 2

        Console.WriteLine("\nВвод: \")()())\"");
        Console.WriteLine("Вывод: " + sol.LongestValidParentheses(")()())")); // Ожидается 4

        Console.WriteLine("\nВвод: \"\"");
        Console.WriteLine("Вывод: " + sol.LongestValidParentheses("")); // ничего 

        Console.WriteLine("\nВвод: \"()(()\"");
        Console.WriteLine("Вывод: " + sol.LongestValidParentheses("()(()")); // Ожидается 2

        Console.WriteLine("\nВвод: \"((()))\"");
        Console.WriteLine("Вывод: " + sol.LongestValidParentheses("((()))")); // Ожидается 6
    }
}