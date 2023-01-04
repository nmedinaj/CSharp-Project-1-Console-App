using System.IO;
using System.Text.Json;

namespace CSharp___Project_1___Console_App
{
    class ITCompany
    {
        static void Main(string[] args)
        {
            //Initialize the system
            string path = @"F:\";
            string fileName = "ITCompany.txt";
            
            var document = getOrCreateDocument(Path.Combine(path + fileName));
           

            //Load the system
            List<ProjectTeam> listTeams = new List<ProjectTeam>();
            var amountProgrammers = 0;
            var daysConsummed = 0;
            var daysInCharged = 0;

            foreach (var team in document)
            {
                var projectTeam = JsonSerializer.Deserialize<ProjectTeam>(team);
                projectTeam.setProgrammersSalary();
                listTeams.Add(projectTeam);
                amountProgrammers += projectTeam.programmersInCharge.Count();
                foreach(var programmer in projectTeam.programmersInCharge)
                {
                    daysConsummed += programmer.CurrentMonthDuration;
                    daysInCharged += (programmer.TotalDuration - programmer.CurrentMonthDuration);
                }
            }


            //Update the system
            listTeams.ForEach(x =>
            {
                x.programmersInCharge.ForEach(p => p.IncreaseDuration());
                x.setProgrammersSalary();
            });


            //Save the system
            string fileName2 = "ITCompanyModified.txt";

            using (StreamWriter sw = File.CreateText(Path.Combine(path + fileName2)))
            {
                listTeams.ForEach(x =>
                {
                    var jsonString = JsonSerializer.Serialize(x);
                    sw.WriteLine(jsonString);
                });
            }


            //Report the system
            Console.WriteLine("IT COMPANY - Report:");
            Console.WriteLine($"IT Company is actually composed of {listTeams.Count} project teams, and {amountProgrammers} programmers.");
            Console.WriteLine($"This month, {daysConsummed} days have been consummed by {amountProgrammers} programmers, and {daysInCharged} days still in charge.");

            Console.WriteLine("PROJECT TEAMS DETAILS:");
            listTeams.ForEach(t =>
            {
                Console.WriteLine($"Project Team - {t.Name}:");
                t.programmersInCharge.ForEach(p => Console.WriteLine($"{p.LastName} {p.FirstName}, in  charge of {p.Activity} " +
                    $"from {String.Format("{0:dd-MM-yyyy}", p.InitialDate)} to {String.Format("{0:dd-MM-yyyy}", p.FinalDate)} (duration {p.TotalDuration}), " +
                    $"this month : {p.CurrentMonthDuration} days (total cost = {p.Salary}$)"));
            });
        }

        private static string[] getOrCreateDocument(string path)
        {
            try
            {
                var doc = File.ReadAllLines(path);
                return doc;
            }
            catch (FileNotFoundException ex)
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    //Create two project teams
                    var projectTeam1 = new ProjectTeam(name: "Web development", type: ProjectTeamType.HALF_PAID);
                    var projectTeam2 = new ProjectTeam(name: "Web design", type: ProjectTeamType.FULL_PAID);

                    //Create programmers in charge
                    var programmer1 = new ProgrammerInCharge("Robert", "Pattinson", DateTime.Parse("01-1-2023"), DateTime.Parse("23-1-2023"), "Analistic code");
                    var programmer2 = new ProgrammerInCharge("Mariah", "Carey", DateTime.Parse("10-1-2023"), DateTime.Parse("17-2-2023"), "writing code");
                    var programmer3 = new ProgrammerInCharge("Sarah", "Dickson", DateTime.Parse("07-1-2023"), DateTime.Parse("23-1-2023"), "Design style");
                    var programmer4 = new ProgrammerInCharge("Louis", "Clark", DateTime.Parse("06-1-2023"), DateTime.Parse("22-2-2023"), "Design structure website");

                    //Assign programmers in charge to the teams
                    projectTeam1.setProgrammersInCharge(new List<ProgrammerInCharge>() { programmer1, programmer2 });
                    projectTeam2.setProgrammersInCharge(new List<ProgrammerInCharge>() { programmer3, programmer4 });

                    //Complete programmers data
                    projectTeam1.setProgrammersSalary();
                    projectTeam2.setProgrammersSalary();

                    //Save in text file as json
                    var list = new List<ProjectTeam>() { projectTeam1, projectTeam2 };
                    list.ForEach(x =>
                    {
                        var jsonString = JsonSerializer.Serialize(x);
                        sw.WriteLine(jsonString);
                    });                    
                }

                return getOrCreateDocument(path);
            }
        }

    }
}


