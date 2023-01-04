using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp___Project_1___Console_App
{
    public interface Employee
    {
        string LastName { get; set; }
        string FirstName { get; set; }
        DateTime InitialDate { get; set; }
        DateTime FinalDate { get; set; }
        int TotalDuration { get; }
        int CurrentMonthDuration { get; }
        decimal Salary { get; set; }
        string Activity { get; set; }

    }
}
