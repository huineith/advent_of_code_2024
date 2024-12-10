namespace tasks;
using System.Collections; 
using System.Linq; 
public static class SimpleFunctions
{
    public static int simpleNorm(List<int> x,List<int> y)
    {
        if (x.Count != y.Count)
        {
            return -1; 
        }

        int  NormValue = 0; 
        for (int i = 0; i < x.Count; i++)
        {
            NormValue+=Math.Abs(x[i] - y[i]);
        }

        return NormValue; 
    }

    public static Dictionary<int, int> getOccurences(List<int> mylist)
    {
        Dictionary<int, int> dict = new();
        foreach (int element in mylist)
        {
            if (dict.ContainsKey(element))
            {
                dict[element] += 1;
            }
            else
            {
                dict.Add(element,1);
            }
        }

        return dict; 
    }



    public static List<int>[] GetIntData(string filename)
    {

        string filePath = "C:\\Users\\westh\\repos\\c#\\adventofcode2024\\tasks\\in_data\\" + filename; 
        string[] fileContents =
            File.ReadAllLines(filePath);
        List<int>[] dataLists = Enumerable.Range(0, fileContents.Length).Select(_ => new List<int>()).ToArray();
 
        
        
        for (int index=0; index<fileContents.Length;index++)
        {
            var line = fileContents[index]; 
            var data = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            foreach (var element in data)
            {
                
                dataLists[index].Add( int.Parse(element));
            }
        }
        return dataLists;
    }

    public static string[] GetStringData(string filename)
    {

        string filePath = "C:\\Users\\westh\\repos\\c#\\adventofcode2024\\tasks\\in_data\\" + filename; 
        string[] fileContents =
            File.ReadAllLines(filePath);
       
        return fileContents;
    }
    public static string intListToString(List<int> myList)
    {
        string listRepresentation = ""; 
        foreach (var number in myList)
        {
            listRepresentation += $"{number},"; 
        }

        return listRepresentation; 
    }

}