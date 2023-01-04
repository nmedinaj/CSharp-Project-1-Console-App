using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp___Project_1___Console_App
{
    public class ProjectTeam
    { 
        public ProjectTeam() { }
        public ProjectTeam(string name, ProjectTeamType type) 
        {
            this.Name = name;
            this.TeamType = type;            
        }

        public List<ProgrammerInCharge> programmersInCharge { get; set; } = new List<ProgrammerInCharge>(); 
        public string Name { get; set; }
        public ProjectTeamType TeamType { get; set; }


        public void setProgrammersInCharge(ProgrammerInCharge programmer)
        {
            programmersInCharge.Add(programmer);
        }
        public void setProgrammersInCharge(List<ProgrammerInCharge> programmers)
        {
            programmersInCharge.AddRange(programmers);
        }

        public void setProgrammersSalary()
        {
            var salaryBase = 45;

            if (this.TeamType == ProjectTeamType.HALF_PAID)
                salaryBase = salaryBase / 2;

            programmersInCharge.ForEach(s => s.Salary = (salaryBase * s.CurrentMonthDuration));
        }
    }
}
