using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using XaviersSchool.Models;

namespace MissionProject.Models
{
    public class MissionInitializer : DropCreateDatabaseIfModelChanges<MissionContext>
    {
        protected override void Seed(MissionContext context)
        {
            var mutants = new List<Mutant>
            {
                new Mutant {MutantName = "Charles Xavier", ImagePath = "proX.jpeg"},
                new Mutant {MutantName = "Scott Summers", ImagePath = "cyclops.jpeg"},
                new Mutant {MutantName = "Bobby Drake", ImagePath = "iceman.jpeg"},
                new Mutant {MutantName = "Warren Worthington", ImagePath = "archangel.jpeg"},
                new Mutant {MutantName = "Hank McCoy", ImagePath = "beast.jpeg"},
                new Mutant {MutantName = "Jean Grey", ImagePath = "jeanGrey.jpeg"}
            };
            foreach (var temp in mutants)
            {
                context.Mutants.Add(temp);
            }
            context.SaveChanges();

            var statuses = new List<Status>
            {
                new Status{StatusName = "Completed"},
                new Status{StatusName = "Needs Assistance"},
                new Status{StatusName = "Assistance In Route"},
                new Status{StatusName = "In Progress"},

            };
            foreach (var temp in statuses)
            {
                context.Statuses.Add(temp);
            }
            context.SaveChanges();

            var missions = new List<Mission>
            {
                new Mission{MissionName = "Community clean up", AssignDate = DateTime.Parse("2015-11-11"), MutantId = 6, StatusId = 4},
                new Mission{MissionName = "Stop Magneto in New York", AssignDate = DateTime.Parse("2015-11-10"), MutantId = 2, StatusId = 3},
                new Mission{MissionName = "Search for lost Person", AssignDate = DateTime.Parse("2015-01-09"), MutantId = 1, StatusId = 1},
                new Mission{MissionName = "Rebuild Monument", AssignDate = DateTime.Parse("2015-10-08"), MutantId = 4, StatusId = 4},
                new Mission{MissionName = "Complete Entrance Training", AssignDate = DateTime.Parse("2015-05-07"), MutantId = 3, StatusId = 4},
                new Mission{MissionName = "Defend Incoming Attack", AssignDate = DateTime.Parse("2015-03-08"), MutantId = 5, StatusId = 2}
            };
            foreach (var temp in missions)
            {
                context.Missions.Add(temp);
            }
            context.SaveChanges();
        }
    }
}