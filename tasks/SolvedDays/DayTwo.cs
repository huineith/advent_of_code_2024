using System.Diagnostics;

namespace tasks;

public class DayTwo
{
    public DayTwo()
    {
        
    }

    public void ProblemOne(string file)
    {
        var data =SimpleFunctions.GetIntData(file) ;

        int validReports = 0;
        int validityCode;
         
        foreach (List<int> report in data)
        {
            validityCode = checkReportValidity(report); 
            if (validityCode<0)
            { 
                validReports += 1; 
            }
            
        }


        Console.WriteLine(validReports);
         
    }


    public void ProblemTwo(string file)
    {
        var data = SimpleFunctions.GetIntData(file);

        int validReports = 0;
        int validityCode;


        int Index = -1;
        foreach (List<int> report in data)
        {
            Index += 1;
            validityCode = checkReportValidity(report);
          
            if (validityCode < 0)
            {
                validReports += 1;
                
            }
            else
            {

                if (validityCode == 1)
                {
                    var specialCase1 = contractList(report, validityCode);
                    var specialCase2 = contractList(report, validityCode+1);
                    var specialCase3 = contractList(report, validityCode-1); // due to possiblity of changing increasing or decreasing makeing (report[1],report[2]) valid 
                    
                    if (checkReportValidity(specialCase1) < 0 || checkReportValidity(specialCase2) < 0 ||checkReportValidity(specialCase3) < 0 )
                    {
                        validReports += 1;
                    }
                }
                else
                {
                    var altList1 = contractList(report, validityCode);
                    var altList2 = contractList(report, validityCode+1);

                    if (checkReportValidity(altList1) < 0 || checkReportValidity(altList2) < 0)
                    {
                        validReports += 1;
                    }

                }
               
                
                
            }

           
        }
        Console.WriteLine(validReports);
    }

    #region ReportLogic
    
        
       public int checkReportValidity(List<int> report)
        { 
            int i;
            bool valid=true;
            bool increasing;
            int invalidIndex;

           
        
            if (report[0] == report[1])
            {
                invalidIndex = 0;
            }
            else
            {
                invalidIndex = -1;
                increasing = report[1] > report[0]; 
                for(  i=0; i<report.Count-1; i++ )
                {
                    valid = CheckStepVality(report[i], report[i + 1], increasing);
                    if (!valid)
                    {
                        invalidIndex = i;
                        break; 
                    }
                }
            }
            return invalidIndex; 

        }
       
       
       
        public int checkReportValidityV2(List<int> report)
        { 
            int i;
            bool valid=true;
            bool increasing;
            int invalidIndex;

            if (report.Count == 0)
            {
                return 0; 
            }
        
            if (report[0] == report[1] && report[0]==report[2]  )
            {
                    invalidIndex = 0;    
                
            }
            else
            {
                if (report[0] == report[1])
                {
                    increasing = report[2] > report[0]; 
                }
                else
                {
                    increasing = report[1] > report[0]; 
                }
                invalidIndex = -1;
               
                for(  i=0; i<report.Count-2; i+=2)
                {
                    valid = CheckStepVality(report[i], report[i + 1],report[i+2], increasing);
                    if (!valid)
                    {
                        invalidIndex = i;
                        break; 
                    }
                }

                if (valid)
                {
                    valid = CheckStepVality(report[report.Count - 2], report[report.Count - 1], increasing);
                    if (!valid)
                    {
                        invalidIndex = report.Count;
                    }
                }
                
            }
            return invalidIndex; 

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
                valid= (a > b) &&   (b-a) > -4  ;  
            }

            return valid; 

        }
        
        
        
        public bool CheckStepVality(int a, int b,int c, bool increasing )
        {

            bool valid = CheckStepVality(a, b, increasing);
            if (!valid)
            {
                if (CheckStepVality(a, c, increasing) || CheckStepVality(b, c, increasing))
                {
                    valid = true; 
                }
                
            }

            return valid;
        }
        
        #endregion

        public List<int> contractList(List<int> report, int index)
        {
            var newList= report.GetRange(0,index) ;
            newList.AddRange(report.GetRange(index+1, report.Count-(index+1)));
            return newList;
        }
}