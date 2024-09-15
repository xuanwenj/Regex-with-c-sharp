

using System;
using System.Text.RegularExpressions;


class Solution
{
    public static void Main(string[] args)
    {
        //Console.WriteLine(Add("12,2"));
        Console.WriteLine(DelimiterParsing("//;#11;5"));
            
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

    /*
     * Allow the Add method to handle different delimiters

    To change a delimiter, the beginning of the string will contain // following with 
    the delimiter and # (hash sign) that looks like this: “//[delimiter]#[numbers…]”. 
    For example, "//;#1;2" should return 3 where the default delimiter is ';'.

    Input: "//;#11;5"
    Output: 16
    
    */

    /* Delimiter parsing(custom rules) could be used for:
     * data processing and parsing(e.g. files, APIs or databases)
     * allowing felxible user input
     * for String Manipulation and Regex Experience
     
     */

    /*steps
     * Check for Custom Delimiter
     * Split the Numbers
     * Convert Strings to Integers
     * Sum the Numbers
     * Handle Additional Constraints
     * Return the Result
     * */

    private static int DelimiterParsing(string s)
    {
        if (string.IsNullOrEmpty(s)) {
            return 0;
        }

            string delimiter = ",";
            string numberString = s;

        if (s.StartsWith("//"))
            {
            var match = Regex.Match(s, @"^//(.+?)#");
            /*
             *  ^:This symbol represents the beginning of the string. 
             *  This part is a capturing group, meaning it captures the text that matches the pattern inside the parentheses,
             *  so you can extract it later.
             *  
             *  .: A dot (.) means "match any single character" (except newlines).
             *  +: This means "one or more of the previous character or pattern." So .+ means "match one or more of any character."
             *  ?: This makes the + non-greedy, meaning it will match the smallest possible number of characters (i.e., it stops as soon as it finds the #).
             *  
             */
            if (match.Success)
            {
                delimiter = Regex.Escape(match.Groups[1].Value);
                numberString = s.Substring(match.Value.Length);
                /*
                 * match.Value returns the portion of the input string that the regular expression pattern matched.
                 * match.Value.Length returns the length of the matched portion.
                 * s.Substring(index) means "start from the xth index(including x) in the string s and take everything after that."
                 * */
                Console.WriteLine("Matched Length: " + match.Value.Length);//output 4
            }
        }

                /*
                 * Group Indexing
                 * Groups[0]: Represents the entire match of the pattern.
                 * Groups[1]: Represents the first capturing group, which is the first part of the regular expression enclosed in parentheses ().
                 * Groups[2]: Represents the second capturing group, if there is a second set of parentheses.
                 * /
                 * 
                */
              

        // Split the string by the custom delimiter
        string[] numArray = numberString.Split(new string[] { delimiter }, StringSplitOptions.None);

        // Convert the string array to integers and sum them
        int sum = numArray.Select(int.Parse).Sum();

        return sum;


    } 
}


