namespace tasks;
using System.Collections; 
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
    
    
}