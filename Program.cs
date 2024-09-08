

using System;


class Solution
{
    public static void Main(string[] args)
    {
        Console.WriteLine(Add("12,2"));
      
        Console.ReadLine();

    }

    private static int Add(string s)
    {
        if (string.IsNullOrEmpty(s))
        {
            return 0;
        }

        string[] numbers = s.Split(',');

        int sum = 0;

        foreach (string n in numbers)
          {
            sum += int.Parse(n);
        }

        return sum;

    }

}
