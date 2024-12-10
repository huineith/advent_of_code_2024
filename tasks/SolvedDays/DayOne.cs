namespace tasks;
using System.IO; 
public  class DayOne
{
    public DayOne()
    {
        
    }

    public void FirstProblem()
    {
        var dataLists = GetData();
        var list1 = dataLists[0];
        var list2 = dataLists[1];
        list1.Sort((x, y) => x.CompareTo(y)); 
        list2.Sort((x, y) => x.CompareTo(y)); 
        var similarityScore=SimpleFunctions.simpleNorm(list1,list2);
        Console.WriteLine("dist:"+similarityScore );
    }


    public void SecondProblem()
    {
        int similarityScore = 0; 
        var dataLists = GetData();
        var list1 = dataLists[0];
        var list2 = dataLists[1];
        var occurrencesListTwo = SimpleFunctions.getOccurences(list2);

        foreach (var el in list1 )
        {
            if (occurrencesListTwo.ContainsKey(el))
            {
                similarityScore += el * occurrencesListTwo[el]; 
            }
            
        }

        Console.WriteLine("simScore:"+similarityScore);
        
    }

    public List<List<int>> GetData()
    {
        List<List<int>> dataLists = new();
        string[] fileContents =
            File.ReadAllLines("C:\\Users\\westh\\repos\\c#\\adventofcode2024\\tasks\\in_data\\day1_input.txt");
        List<int> list1 = new();
        List<int> list2 = new();
        
        foreach (var line in fileContents)
        {
                var data = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                list1.Add(int.Parse(data[0]));
                list2.Add(int.Parse(data[1]));
        }

        dataLists.Add(list1);
        dataLists.Add(list2);
        return dataLists;
        
    }


}