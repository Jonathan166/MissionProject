using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MissionProject.Models
{
    public class Mutant
    {
        public int MutantId { get; set; }
        public string MutantName { get; set; }
        public byte[] Picture { get; set; }
        public string ImagePath { get; set; }
    }
}