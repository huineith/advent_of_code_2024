namespace tasks;

public class DayTwo
{
    public DayTwo()
    {
        
    }

    public int ProblemOne()
    {
        var data =SimpleFunctions.GetIntData("d2_p1.txt") ;

     
        
        return -1; 
    }


    public bool CheckStepVality(int a, int b, bool increasing )
    {

        bool valid; 
        if (increasing)
        {
            valid = (b > a) && (b - a) < 4; 
        }
        else
        {
            valid= !(b > a) &&   (b-a) > 4 ;  
        }

        return valid; 

    }
    
}