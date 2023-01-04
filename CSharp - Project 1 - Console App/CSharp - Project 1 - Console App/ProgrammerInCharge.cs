using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp___Project_1___Console_App
{
    public class ProgrammerInCharge : Employee
    {
        public ProgrammerInCharge(string lastName, string firstName, DateTime initialDate, DateTime finalDate, string activity)
        {
            LastName = lastName;
            FirstName = firstName;
            InitialDate = initialDate;
            FinalDate = finalDate;
            Activity = activity;
        }

        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime FinalDate { get; set; }
        public int TotalDuration { get => (int)(FinalDate - InitialDate).TotalDays; }
        public int CurrentMonthDuration
        {
            get
            {
                var days = 0;

                if (InitialDate.Month == FinalDate.Month && InitialDate.Year == DateTime.Now.Year && FinalDate.Year == DateTime.Now.Year)
                {
                    days = FinalDate.Day - InitialDate.Day;
                }
                else if (InitialDate.Month == DateTime.Now.Month && InitialDate.Year == DateTime.Now.Year)
                {
                    days = DateTime.DaysInMonth(InitialDate.Year, InitialDate.Month) - InitialDate.Day;
                    
                }
                else if (FinalDate.Month == DateTime.Now.Month && FinalDate.Year == DateTime.Now.Year)
                {
                    days = FinalDate.Day;                    
                }
                else
                {
                    DateTime current = InitialDate.AddMonths(1);
                    while (current <= FinalDate.AddMonths(-1))
                    {
                        if(current.Year == FinalDate.Year)
                            days = DateTime.DaysInMonth(current.Year, current.Month);

                        current = current.AddMonths(1);
                    }
                }

                return days;
            }
        }
        public decimal Salary { get; set; }
        public string Activity { get; set; }

        public void assingActivitytoEmployee(string activity, Employee employee, DateTime initialDate, DateTime finalDate)
        {
        }

        public void IncreaseDuration()
        {
            FinalDate = FinalDate.AddDays(1);
        }
    }
}
