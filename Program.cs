

using System;
using System.Text.RegularExpressions;


class Solution
{
    public static void Main(string[] args)
    {
        //Console.WriteLine(Add("12,2"));
        //Console.WriteLine(DelimiterParsing("//;#11;5"));
        //Console.WriteLine(AddPositiveNums(("//;#11;-5;-12")));
        //Console.WriteLine(AddPositiveNums(("//;#1;2;3")));
        //Console.WriteLine(IgonorThousandNums("//;#23;1001;11"));
       
        Console.WriteLine(anyDelimiter("//**%*#11**%*20**%*3"));

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
            //var match = Regex.Match(s, @"^//(.+?)#");
            var match = Regex.Match(s, @"^//(\*+)\#");
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
                //Console.WriteLine(delimiter);
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

    /*
     *3. Calling Add with a negative number will throw Exception
     *Exception should contain a message “Negatives not allowed” - and the negative number that was passed. If there are multiple negatives, show all of them in the exception message; comma delimited.
     *This step is not part of automatic evaluation Unit Test and will be only evaluated manually.
     *Input: “//;#16;51;-2”
     *Output: Exception with message “Negatives not allowed -51,-2”
     **/
    
    /*
     * slipt the string into array, foreach the array to check negative nums, record negative ones in a new array 
     * use ',' as delimiter to combine the negative nums into a string
     * return it in an exception
     * 
     */ 


    private static int AddPositiveNums(string s)
    {
       string delimiter = ",";
       string numberString = s;

        if (s.StartsWith("//"))
        {
            var match = Regex.Match(s, @"^//(.+?)#");
            if (match.Success)
            {
                delimiter = Regex.Escape(match.Groups[1].Value);
                numberString = s.Substring(match.Value.Length);

            }

        }
        string[] numArray = numberString.Split(new string[] { delimiter }, StringSplitOptions.None);

        var positiveNums = numArray.Select(int.Parse).ToList();

        var negativeNums = numArray.Select(int.Parse).Where(num => num < 0).ToList();

        if (negativeNums.Any())
        {
            throw new Exception($"Negative numbers are not allowed: {string.Join(",", negativeNums)}");

            //throw new Exception($"Negative numbers are not allowed: {string.Join(",", negativeNums.Select(n => n.ToString()))}");
        }

        // Return the list of negative numbers
        return positiveNums.Sum();

       
      
    }
     /*"4. Numbers bigger than 1000 should be ignored, so adding 23 + 1001 = 23
         * Input: "//;#23;1001;11" Output: 34"
         */
    /* slipt the numbers, pick out the ones larger than 1000*/
    private static int IgonorThousandNums(string s)
    {
        string delimiter = ",";
        string numberString = s;

        if (s.StartsWith("//"))
        {
            var match = Regex.Match(s, @"^//(.+?)#");
            if (match.Success)
            {
                delimiter = Regex.Escape(match.Groups[1].Value);
                numberString = s.Substring(match.Value.Length);

            }

        }
        string[] numArray = numberString.Split(new string[] { delimiter }, StringSplitOptions.None);

        var lessThan1000Nums = numArray.Select(int.Parse).Where(num => num < 1000).ToList();
        
        return lessThan1000Nums.Sum();

    }
    /*5. Delimiters can be of any length; take a look at the example below
     * "//[delimiter]#" for example:
     * "//***#11***20***3" should return 34
     * Input: "//#11203" Output: 34
     */

    private static int anyDelimiter(string s)
    {

        string delimiter = ",";
        string numberString = s;

        if (s.StartsWith("//"))
        {
            var match = Regex.Match(s, @"^//(.+?)#");
           // var match = Regex.Match(s, @"^//(\*+)\#");

                //Use Regex.Escape when you want to treat a string
                //that may contain special characters as literal characters in a regular expression.

            if (match.Success)
            {
                
                //delimiter = Regex.Escape(match.Groups[1].Value);

                delimiter = match.Groups[1].Value;
               // Console.WriteLine(delimiter);
                Console.WriteLine(delimiter);
                numberString = s.Substring(match.Value.Length);
                Console.WriteLine("Matched Length: " + match.Value.Length);//output 4
            }
        }

        string[] numArray = numberString.Split(new string[] { delimiter }, StringSplitOptions.None);

        int sum = numArray.Select(int.Parse).Sum();

        return sum;
    }


    /*6. Allow multiple delimiters
     * "//[delim1][delim2]#" for example:
     * "//[][%]#112%17" should return 30.
     * Multiple delimiters should be enclosed by [].
     * 
     * Input: "//[][%]#112%17" Output: 30
     */




    /*7. Make sure you can also handle multiple delimiters with length longer than one char
     * Input: "//[abc][%%]#11abc2%%17"
     * Output: 30
 
     */
}



