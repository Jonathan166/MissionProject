using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MissionProject.Models
{
    public class Mission
    {
        public int MissionId { get; set; }
        public string MissionName { get; set; }
        public string MissionDescription { get; set; }
        public DateTime AssignDate { get; set; }
        public int MutantId { get; set; }
        public int StatusId { get; set; }
        public virtual Mutant mutant { get; set; }
        public virtual Status status { get; set; }
    }
}