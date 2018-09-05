using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevReadyAcademy.BLL
{
    public class GpaConvertor
    {
        //How Do You Calculate Your GPA https://blog.prepscholar.com/how-do-you-calculate-gpa
        public static string ConvertNumberToLetter(int GPA)
        {
            var GpaLetter = "NA";

            if (GPA >= 93)
                GpaLetter = "A";
            else if (GPA >= 83)
                GpaLetter = "B";
            else if (GPA >= 73)
                GpaLetter = "C";
            else if (GPA >= 65)
                GpaLetter = "D";
            else if (GPA >= 65)
                GpaLetter = "D";
            else if (GPA >= 0)
                GpaLetter = "F";

            return GpaLetter;
        }
    }
}