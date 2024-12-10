using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.Intrinsics.Arm;
using System.Text.RegularExpressions;

namespace tasks;

public class DayThree
{
    public DayThree()
    {
        
    }


    public void Problem1(string fileName)
    {
        var input = SimpleFunctions.GetStringData(fileName);
        var inputString = String.Join("",input);
        string pattern = @"mul\([0-9]+,[0-9]+\)";

        var matches = Regex.Matches( inputString, pattern);
        int sum = 0; 
        foreach (var match in matches )
        {
            
            sum += Mul(match.ToString());
        }

        Console.WriteLine(sum);
    }

    public void Problem2(string fileName)
    {
        bool mulEnabled = true; 
        var input = SimpleFunctions.GetStringData(fileName);
        var inputString = String.Join("",input);
        string pattern = @"(mul\([0-9]+,[0-9]+\))|(do\(\))|(don't\(\))";
       

        var matches = Regex.Matches( inputString, pattern);
        int sum = 0; 
        foreach (var match in matches )
        {

            if ( match.ToString().CompareTo("do()") != 0)
            {
                
            }
            // sum += Mul(match.ToString());
            Console.WriteLine(match.ToString());
        }

        Console.WriteLine(sum);
    }

    private int Mul(string mulString)
    {
        string pattern = @"[0-9]+";
        var matches = Regex.Matches(mulString,pattern);
        int[] numbers = new int[2];
        int iterator = -1; 
        foreach (var match in matches)
        {
            iterator++;
            numbers[iterator]=int.Parse(match.ToString());
        }
        
        return numbers[0] * numbers[1]; 
    }
}